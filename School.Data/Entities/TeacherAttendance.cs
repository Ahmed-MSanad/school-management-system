using System.ComponentModel.DataAnnotations.Schema;
namespace School.Data.Entities
{
    public class TeacherAttendance : BaseEntity
    {
        public Teacher Teacher { get; set; }
        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public bool? Status { get; set; }
        public DateOnly? Date { get; set; }
    }
}
