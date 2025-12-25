using School.Data.Contexts;
using School.Repository.RepoInterfaces;

namespace School.Repository.RepoImplementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext dbContext;
        public UnitOfWork(SchoolDbContext _dbContext)
        {
            School_ClassesRepo = new SchoolClassRepository(_dbContext);
            dbContext = _dbContext;
        }

        public ISchoolClassRepository School_ClassesRepo { get; set; }

        public async Task<int> SaveTheChangeAsync() => await dbContext.SaveChangesAsync();
    }
}
