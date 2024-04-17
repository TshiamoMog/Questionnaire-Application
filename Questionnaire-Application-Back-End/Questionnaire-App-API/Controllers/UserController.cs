using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionnaireCreationApplicationAPI.DataTransferObjects.UserDTOs.UserGetDTOs;
using QuestionnaireCreationApplicationAPI.DataTransferObjects.UserDTOs.UserPostDTOs;
using QuestionnaireCreationApplicationAPI.DataTransferObjects.UserDTOs;
using System.Security.Cryptography;
using Questionnaire_App_API.DataTransferObjects.UserDTOs;

namespace Questionnaire_App_API.Controllers
{
    /// <summary>
    /// Handles the interaction between the DTOs and the entities that manipulate the 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;

        #region Constructor
        /// <summary>
        /// Accepts the <see cref="DataContext"/> and acts as a default constructor
        /// </summary>
        /// <param name="context">The context to parse</param>
        public UserController(DataContext context)
        {
            _dataContext = context;
        }
        #endregion

        #region Create POST

        #region Register User
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterRequestDTO userRegisterRequest)
        {
            if (_dataContext.Users.Any(u => u.Email == userRegisterRequest.Email) || _dataContext.Users.Any(u => u.PhoneNumber == userRegisterRequest.PhoneNumber))
            {
                return BadRequest("User already exists.");
            }

            if (_dataContext.Users.Any(u => u.UserName == userRegisterRequest.UserName))
            {
                return BadRequest("That username is already taken!");
            }

            CreatePasswordHash(userRegisterRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                PhoneNumber = userRegisterRequest.PhoneNumber,
                Email = userRegisterRequest.Email,
                Name = userRegisterRequest.FullName,
                UserName = userRegisterRequest.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return Ok("User successfully created!");
        }
        #endregion

        #region Login User
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginRequestDTO userLoginRequest)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(u => u.Email == userLoginRequest.Email || u.PhoneNumber == userLoginRequest.PhoneNumber || u.UserName == userLoginRequest.UserName);

            if (user == null)
            {
                return BadRequest("Invalid Credentials. Use not found or does not exist.");
            }

            if (!VerifyPasswordHash(userLoginRequest.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password is incorrect.");
            }

            if (user.VerifiedAt == null)
            {
                return BadRequest("Not verified!");
            }
            return Ok($"Welcome, {user.Name}!");
        }


        #endregion

        #region Verify User
        [HttpPost("Verify")]
        public async Task<IActionResult> Verify(string token)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);

            if (user == null)
            {
                return BadRequest("Invalid token.");
            }

            user.VerifiedAt = DateTime.Now;
            await _dataContext.SaveChangesAsync();

            return Ok("User verified!");
        }
        #endregion

        #region Forgot Password
        [HttpPost("Forgot Password")]
        public async Task<IActionResult> ForgotPassword(string? email, string? phone, string? username)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(u => u.Email == email || u.PhoneNumber == phone || u.UserName == username);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            user.PasswordResetToken = CreateRandomToken();
            user.ResetExpiryTime = DateTime.Now.AddMinutes(15);
            await _dataContext.SaveChangesAsync();

            return Ok("Reset password token has been sent");
        }
        #endregion
        
        #region Send Token
        [HttpPost("Send Token")]
        public async Task<IActionResult> SendToken(UserTokenRequestDTO userTokenRequest)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(u => u.PasswordResetToken == userTokenRequest.Token);

            if (user == null)
            {
                return BadRequest("Invalid Token.");
            }

            return Ok("You may now reset your password.");
        }
        #endregion

        #region Reset Password
        [HttpPost("Reset Password")]
        public async Task<IActionResult> ResetPassword(UserPasswordResetRequestDTO passwordResetRequest)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == passwordResetRequest.Token);

            if (user == null || user.ResetExpiryTime < DateTime.Now)
            {
                return BadRequest("Invalid Token");
            }

            CreatePasswordHash(passwordResetRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetExpiryTime = null;

            await _dataContext.SaveChangesAsync();

            return Ok("Password successfully reset.");
        }
        #endregion

        #region Private Helpers
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedPasswordHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateRandomToken()
        {
            string token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
            if (_dataContext.Users.Any(u => u.VerificationToken == token) || _dataContext.Users.Any(u => u.PasswordResetToken == token))
            {
                CreateRandomToken();
            }
            return token;
        }
        #endregion

        #endregion

        #region Read GET

        #region Get All Users
        [HttpGet()]
        public async Task<ActionResult<User>> GetUsers()
        {
            if (_dataContext.Users == null)
            {
                return NotFound();
            }

            var user = await _dataContext.Users.ToListAsync();

            var userDetailsRequestDTO = user.Select(user => new UserDetailsRequestDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            });

            return Ok(userDetailsRequestDTO);
        }
        #endregion

        #region Get One User By Id
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (_dataContext.Users == null)
            {
                return NotFound();
            }


            if (user == null)
            {
                return BadRequest("Not Found");
            }

            UserDetailsRequestDTO userDetailsRequestDTO = new UserDetailsRequestDTO();
            userDetailsRequestDTO.Id = id;
            userDetailsRequestDTO.Name = user.Name;
            userDetailsRequestDTO.Email = user.Email;

            return Ok(userDetailsRequestDTO);
        }
        #endregion

        #endregion

        #region Update PUT
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUserDetails([FromRoute] int id, UserUpdateRequestDTO userUpdateRequestDTO)
        {
            var user = await _dataContext.Users.FindAsync(userUpdateRequestDTO.Id);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }

            user.Name = userUpdateRequestDTO.Name;
            user.Email = userUpdateRequestDTO.Email;



            await _dataContext.SaveChangesAsync();

            return Ok(userUpdateRequestDTO);
        }
        #endregion

        #region Delete DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _dataContext.Users.FindAsync(id);

            if (user == null)
            {
                return BadRequest("User Not Found");
            }

            _dataContext.Users.Remove(user);
            await _dataContext.SaveChangesAsync();

            return Ok("User Successfully Deleted");
        }
        #endregion

        // HttpPut("NOT adviced"),
        // HttpGet("GETS FROM API AND CAN BE USED AS A TRIGER"),
        // HttpPost,
        // HttpPatch("EXIST IN THE ENCRYPTED AREA. BEST WAY TO SEND DATA OVER WEB. SENDS TO API")
    }
}
