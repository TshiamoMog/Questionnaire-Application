namespace Questionnaire_App_API.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string QuestionType { get; set; } = string.Empty;

        #region Connections

        #region Connection to the Answers Table
        // Navigation property for the one-to-many relationship With the Answers Table
        public virtual List<Answer> Answers { get; set; }
        #endregion

        #region Connection to the Questionnaires Table

        #region Foreign key for the one-to-many relationship With the Questionnaires Table
        // Foreign key property for the one-to-many relationship
        public int QuestionnaireId { get; set; }
        #endregion

        public Questionnaire Questionnaire { get; set; }

        #endregion

        #endregion 
    }
}
