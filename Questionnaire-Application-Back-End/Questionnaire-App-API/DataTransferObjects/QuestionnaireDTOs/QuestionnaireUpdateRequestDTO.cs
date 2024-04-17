namespace QuestionnaireCreationApplicationAPI.DataTransferObjects.QuestionnaireDTOs
{
    public class QuestionnaireUpdateRequestDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Published { get; set; }
        public int User { get; set; }
    }
}
