using School.Data.Contexts;
using School.Data.Entities;
using School.Repository.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace School.Repository.RepoImplementations
{
    public class SchoolClassRepository : GenericRepository<School_Class>, ISchoolClassRepository
    {
        private readonly SchoolDbContext dbContext;
        public SchoolClassRepository(SchoolDbContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<bool> ExistsByNameAsync(string name, int? excludeId = null)
        {
            return await dbContext.School_Classes.AnyAsync(sc =>
            (excludeId == null || excludeId != sc.Id) // excludeId ignores self-conflicts and queries once (fast) for updates.
            &&
            sc.Name.ToLower().Trim().Contains(name.ToLower().Trim()));
        }
    }
}
