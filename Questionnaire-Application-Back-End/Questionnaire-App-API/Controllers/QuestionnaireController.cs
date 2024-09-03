using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionnaireCreationApplicationAPI.DataTransferObjects.QuestionnaireDTOs;

namespace Questionnaire_App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnaireController : ControllerBase
    {
        private readonly DataContext _dataContext;

        #region Constructor
        public QuestionnaireController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        #endregion

        #region Create
        [HttpPost("Create Questionaire")]
        //public async Task<ActionResult<List<Questionnaire>>> CreateQuestionnaire(QuestionnaireCreateRequestDTO questionnaireCreateRequestDTO)
        //{
        //    if (_dataContext.Questionnaires.Any(qnr => qnr.Title == questionnaireCreateRequestDTO.Title))
        //    {
        //        return BadRequest("Questionnaire already exits.");
        //    }
        //    var questionnaire = new Questionnaire
        //    {
        //        Title = questionnaireCreateRequestDTO.Title,
        //    };

        //    _dataContext.Questionnaires.Add(questionnaire);
        //    await _dataContext.SaveChangesAsync();

        //    return Ok(await _dataContext.Questionnaires.ToListAsync());
        //}

        public async Task<IActionResult> CreateQuestionnaire([FromBody] Questionnaire questionnaireRequest)
        {
            questionnaireRequest.Id = Guid.NewGuid();
            
            _dataContext.Questionnaires.Add(questionnaireRequest);
            await _dataContext.SaveChangesAsync();

            return Ok(questionnaireRequest);
        }
        #endregion

        #region Read

        #region Get All Questionnaires
        [HttpGet()]
        //public async Task<ActionResult<List<Questionnaire>>> GetQuestionnaires()
        //{
        //    if (_dataContext.Questionnaires == null)
        //    {
        //        return NotFound();
        //    }

        //    var questionnaire = await _dataContext.Questionnaires.ToListAsync();

        //    var questionnaireCreateRequestDTO = questionnaire.Select(questionnaire => new QuestionnaireCreateRequestDTO
        //    {
        //        Title = questionnaire.Title,
        //        Description = questionnaire.Description,
        //        SubTitle = questionnaire.SubTitle,
        //        Published = questionnaire.Published,

        //    });

        //    return Ok(await _dataContext.Questionnaires.ToListAsync());
        //}
        public async Task<IActionResult> GetAllEmployees()
        {
            var questionnaire = await _dataContext.Questionnaires.ToListAsync();
            return Ok(questionnaire);
        }
        #endregion

        //[HttpGet]
        //[Route("id")]
        //public async Task<ActionResult<Questionnaire>> GetQuestionnaire(int id)
        //{
        //    return new Questionnaire
        //    {
        //        Title = "Family Lineage Documentation Form",
        //        //SubTitle = "Preserving Generational Legacies for Future Generations",
        //        SubTitle = "Preserving Generational Legacies",
        //        Description = "The Form serves as a comprehensive tool for capturing essential details about familial ancestry and heritage.",
        //        Published = false,
        //    };
        //}
        #endregion

        #region Update
        [HttpPut("id")]
        public async Task<ActionResult<List<Questionnaire>>> UpdateQuestionnaire(QuestionnaireUpdateRequestDTO questionnaireUpdateRequestDTO)
        {
            var questionnaire = await _dataContext.Questionnaires.FindAsync(questionnaireUpdateRequestDTO.Id);
            if (questionnaire == null)
            {
                return BadRequest("User Not Found");
            }

            questionnaire.Title = questionnaireUpdateRequestDTO.Title;
            questionnaire.SubTitle = questionnaireUpdateRequestDTO.SubTitle;
            questionnaire.Description = questionnaireUpdateRequestDTO.Description;
            questionnaire.Published = questionnaireUpdateRequestDTO.Published;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Questionnaires.ToListAsync());
        }
        #endregion

        #region Delete
        [HttpDelete("id")]
        public async Task<ActionResult<List<Questionnaire>>> DeleteQuestionnaire(int id)
        {
            var questionnaire = await _dataContext.Questionnaires.FindAsync(id);

            if (questionnaire == null)
            {
                return BadRequest("Questionnaire Not Found");
            }

            _dataContext.Questionnaires.Remove(questionnaire);
            await _dataContext.SaveChangesAsync();

            return (await _dataContext.Questionnaires.ToListAsync());
        }
        #endregion
    }
}
