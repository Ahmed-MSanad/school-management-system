using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Expense : BaseEntity
    {
        public School_Class School_Class { get; set; }
        [ForeignKey("School_Class")]
        public int? ClassId { get; set; }
        public Subject Subject { get; set; }
        [ForeignKey("Subject")]
        public int? SubjectId { get; set; }
        public int? ChargeAmount { get; set; }
    }
}
