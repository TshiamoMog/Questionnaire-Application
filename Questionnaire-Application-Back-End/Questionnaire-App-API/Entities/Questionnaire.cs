using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire_App_API.Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Published { get; set; } = false;

        //// Navigation property for the one-to-many relationship
        ////[InverseProperty("Questionnaire")]
        //public virtual ICollection<Question>? Questions { get; set; }

        //// Foreign key property for the one-to-many relationship
        //public int UserId { get; set; }

        //// Navigation property for the one-to-many relationship
        //[ForeignKey("UserId")]
        //public User? User { get; set; }
    }
}
