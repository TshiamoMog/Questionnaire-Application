namespace Questionnaire_App_API.DataTransferObjects.UserDTOs
{
    public class UserTokenRequestDTO
    {
        [Required]// Data Annotations
        public string Token { get; set; } = string.Empty;
    }
}
