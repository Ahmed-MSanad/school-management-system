using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Fees : BaseEntity
    {
        public School_Class School_Class { get; set; }
        [ForeignKey("School_Class")]
        public int? ClassId { get; set; }
        public int? FeesAmount { get; set; }
    }
}