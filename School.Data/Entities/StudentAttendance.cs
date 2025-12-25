using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class StudentAttendance : BaseEntity
    {
        public School_Class School_Class { get; set; }
        [ForeignKey("School_Class")]
        public int? ClassId { get; set; }
        public Subject Subject { get; set; }
        [ForeignKey("Subject")]
        public int? SubjectId { get; set; }
        public string? RollNo { get; set; }
        public bool? Status { get; set; }
        public DateOnly? Date { get; set; }
    }
}
