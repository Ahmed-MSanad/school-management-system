using System.ComponentModel.DataAnnotations;

namespace School.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
