namespace QuestionnaireCreationApplicationAPI.DataTransferObjects.UserDTOs.UserPostDTOs
{
    public class UserLoginRequestDTO
    {
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        [Phone]
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
