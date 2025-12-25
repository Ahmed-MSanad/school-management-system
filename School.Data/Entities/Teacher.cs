namespace School.Data.Entities
{
    public class Teacher : BaseEntity
    {
        public string? Name { get; set; }
        public DateOnly? DOB { get; set; }
        public string? Gender { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
    }
}
