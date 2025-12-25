using School.Data.Entities;

namespace School.Service.ServiceInterfaces
{
    public interface ISchoolClassService
    {
        public Task<School_Class> GetByIdAsync(int id);
        public Task<IEnumerable<School_Class>> GetAllAsync(bool isTrak = false);
        public Task AddAsync(School_Class school_Class);
        public Task Delete(School_Class school_Class);
        public Task Update(School_Class school_Class);
    }
}
