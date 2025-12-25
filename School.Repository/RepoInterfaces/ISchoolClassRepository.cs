using School.Data.Entities;

namespace School.Repository.RepoInterfaces
{
    public interface ISchoolClassRepository : IGenericRepository<School_Class>
    {
        public Task<bool> ExistsByNameAsync(string name, int? excludeId = null);
    }
}
