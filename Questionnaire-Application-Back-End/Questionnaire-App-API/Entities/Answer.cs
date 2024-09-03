namespace Questionnaire_App_API.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        

        #region Connection to the Question Table

        #region Foreign key for the one-to-many relationship With the Question Table
        // Foreign key property for the one-to-many relationship
        public int QuestionId { get; set; }
        #endregion
        public Question Question { get; set; }

        #endregion
    }
}
