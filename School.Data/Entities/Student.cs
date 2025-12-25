using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Student : BaseEntity
    {
        public string? Name { get; set; }
        public DateOnly? DOB { get; set; }
        public string? Gender { get; set; }
        public string? Mobile { get; set; }
        public string? RollNo { get; set; }
        public string? Address { get; set; }
        public School_Class School_Class { get; set; }
        [ForeignKey("School_Class")]
        public int? ClassId { get; set; }
    }
}
