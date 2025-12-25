using School.Data.Entities;
using School.Repository.RepoInterfaces;
using School.Service.ServiceInterfaces;
using System.Data;

namespace School.Service.ServiceImplementations
{
    public class SchoolClassService(IUnitOfWork unitOfWork) : ISchoolClassService
    {
        public async Task AddAsync(School_Class school_Class)
        {
            if (await unitOfWork.School_ClassesRepo.ExistsByNameAsync(school_Class.Name))
            {
                throw new DuplicateNameException("Class name already exists. Please choose a unique name.");
            }
            await unitOfWork.School_ClassesRepo.AddAsync(school_Class);
            await unitOfWork.SaveTheChangeAsync();
        }

        public async Task<IEnumerable<School_Class>> GetAllAsync(bool isTrak = false)
        {
            return await unitOfWork.School_ClassesRepo.GetAllAsync(isTrak);
        }

        public async Task<School_Class> GetByIdAsync(int id)
        {
            return await unitOfWork.School_ClassesRepo.GetByIdAsync(id);
        }

        public async Task Update(School_Class school_Class)
        {
            if (await unitOfWork.School_ClassesRepo.ExistsByNameAsync(school_Class.Name, school_Class.Id))
            {
                throw new DuplicateNameException("Class name already exists. Please choose a unique name.");
            }
            unitOfWork.School_ClassesRepo.Update(school_Class);
            await unitOfWork.SaveTheChangeAsync();
        }

        public async Task Delete(School_Class school_Class)
        {
            unitOfWork.School_ClassesRepo.Delete(school_Class);
            await unitOfWork.SaveTheChangeAsync();
        }
    }
}
