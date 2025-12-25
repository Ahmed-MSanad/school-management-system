using School.Data.Entities;

namespace School.Repository.RepoInterfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public Task AddAsync(TEntity entity);
        public Task<IEnumerable<TEntity>> GetAllAsync(bool isTrak = false);
        public Task<TEntity> GetByIdAsync(int Id);
        public void Delete(TEntity entity);
        public void Update(TEntity entity);
    }
}
