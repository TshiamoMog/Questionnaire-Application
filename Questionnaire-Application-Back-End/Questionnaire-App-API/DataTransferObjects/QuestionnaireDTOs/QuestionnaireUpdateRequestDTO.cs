namespace QuestionnaireCreationApplicationAPI.DataTransferObjects.QuestionnaireDTOs
{
    public class QuestionnaireUpdateRequestDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Published { get; set; } = false;
    }
}
