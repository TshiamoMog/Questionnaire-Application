namespace Questionnaire_App_API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string? VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetExpiryTime { get; set; }

        #region Connection to the Questionnaire Table
        // Navigation property for the one-to-many relationship With Questionnaire Table
        public virtual List<Questionnaire> Questionnaires { get; set; }
        #endregion
    }
}
