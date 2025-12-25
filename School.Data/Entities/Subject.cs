using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Subject : BaseEntity
    {
        public string? Name { get; set; }
        public School_Class School_Class { get; set; }
        [ForeignKey("School_Class")]
        public int? ClassId { get; set; }
    }
}
