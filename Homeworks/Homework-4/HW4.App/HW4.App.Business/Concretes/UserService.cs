using HW4.App.Business.Abstracts;
using HW4.App.DataAccess.EntityFramework.Repository.Abstracts;
using HW4.App.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HW4.App.Business.Concretes
{
   public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public List<User> GetUsers()
        {
            return repository.GetAll().ToList();
        }
        public void InsertUser(User user)
        {
            repository.Insert(user);
            unitOfWork.Commit();
        }

        public void UpdateUser(User user)
        {
            repository.Update(user);
            unitOfWork.Commit();
        }

        public void DeleteUser(User user)
        {
            repository.Delete(user);
            unitOfWork.Commit();
        }
    }
}