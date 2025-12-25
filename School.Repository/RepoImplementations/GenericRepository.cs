using School.Data.Contexts;
using School.Data.Entities;
using School.Repository.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace School.Repository.RepoImplementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SchoolDbContext dbContext;
        public GenericRepository(SchoolDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task AddAsync(TEntity entity)
            => await dbContext.Set<TEntity>().AddAsync(entity);
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool isTrak = false)
        {
            if (!isTrak)
            {
                return await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            return await dbContext.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(int Id)
            => await dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == Id);
        public void Delete(TEntity entity)
            => dbContext.Set<TEntity>().Remove(entity);
        public void Update(TEntity entity)
            => dbContext.Set<TEntity>().Update(entity);
    }
}
