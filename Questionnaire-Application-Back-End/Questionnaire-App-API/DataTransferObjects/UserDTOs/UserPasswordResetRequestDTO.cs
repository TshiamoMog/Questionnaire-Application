namespace QuestionnaireCreationApplicationAPI.DataTransferObjects.UserDTOs.UserPostDTOs
{
    public class UserPasswordResetRequestDTO
    {
        [Required]// Data Annotations
        public string Token { get; set; } = string.Empty;
        [Required, MinLength(7, ErrorMessage = "Please enter at least 7 characters")]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
