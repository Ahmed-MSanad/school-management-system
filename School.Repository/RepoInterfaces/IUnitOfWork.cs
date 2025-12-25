namespace School.Repository.RepoInterfaces
{
    public interface IUnitOfWork
    {
        public ISchoolClassRepository School_ClassesRepo { get; set; }
        public Task<int> SaveTheChangeAsync();

    }
}
