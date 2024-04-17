namespace QuestionnaireCreationApplicationAPI.DataTransferObjects.UserDTOs
{
    public class UserUpdateRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Role { get; set; }
    }
}
