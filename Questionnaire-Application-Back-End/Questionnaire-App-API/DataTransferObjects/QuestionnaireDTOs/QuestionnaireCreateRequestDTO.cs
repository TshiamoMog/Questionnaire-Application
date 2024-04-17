using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionnaireCreationApplicationAPI.DataTransferObjects.QuestionnaireDTOs
{
    public class QuestionnaireCreateRequestDTO
    {
        [Required]// Data Annotation
        public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public bool Published { get; set; } = false;

        //public List<QuestionCreateRequest> Questions { get; set; }
    }
}
