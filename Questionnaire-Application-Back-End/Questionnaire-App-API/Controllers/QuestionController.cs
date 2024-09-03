using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Questionnaire_App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        #region Read

        #region Get All Questionnaires
        [HttpGet()]
        public async Task<ActionResult<List<Question>>> GetQuestions()
        {
            return new List<Question>
            {
                new Question
                {

                },
            };
        }
        #endregion
        #endregion
    }
}
