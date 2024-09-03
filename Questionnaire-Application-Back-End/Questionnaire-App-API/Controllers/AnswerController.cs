using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Questionnaire_App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        #region Read

        #region Get All Questionnaires
        [HttpGet()]
        public async Task<ActionResult<List<Answer>>> GetAnswers()
        {
            return new List<Answer>
            {
                new Answer
                {
                    
                },
            };
        }
        #endregion
        #endregion
    }
}
