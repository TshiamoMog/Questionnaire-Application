namespace QuestionnaireCreationApplicationAPI.DataTransferObjects.UserDTOs.UserGetDTOs
{
    public class UserDetailsRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Role { get; set; }
    }
}
