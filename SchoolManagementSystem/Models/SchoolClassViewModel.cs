using School.Data.Entities;

namespace SchoolManagementSystem.Models
{
    public class SchoolClassViewModel
    {
        public School_Class Class { get; set; } = new();
        public IEnumerable<School_Class> Classes { get; set; } = Enumerable.Empty<School_Class>();
        public int? EditingId { get; set; }
    }
}
