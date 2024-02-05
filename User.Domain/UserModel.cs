namespace User.Domain
{
    public class UserModel
    {
        public int Id { get; set; }
        public Name? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }

    public record Name(string? FirstName, string? MiddleName, string? LastName);
}
