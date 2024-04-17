namespace QuestionnaireCreationApplicationAPI.DataTransferObjects.UserDTOs.UserPostDTOs
{
    public class UserRegisterRequestDTO
    {
        [EmailAddress]// Data Annotations
        public string? Email { get; set; } = string.Empty;
        [Phone]
        public string? PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required, MinLength(7, ErrorMessage = "Please enter at least 7 characters")]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
