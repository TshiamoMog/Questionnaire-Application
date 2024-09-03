namespace Questionnaire_App_API.Entities
{
    public class Questionnaire
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Published { get; set; } = false;

        #region Connections

        #region Connection to the Questions Table
        // Navigation property for the one-to-many relationship With the Questions Table
        public virtual List<Question> Questions { get; set; }
        #endregion

        #region Connection to the Users Table

        #region Foreign key for the one-to-many relationship With the Users Table
        // Foreign key property for the one-to-many relationship
        public int UserId { get; set; }
        #endregion

        public User User { get; set; }

        #endregion

        #endregion
    }
}
