using HW5.DataAccess.EntityFramework.Repository.Abstracts;
using HW5.Domain.Entities;

namespace HW5.DataAccess.EntityFramework.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : Post
    {
        public readonly IUnitOfWork unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            unitOfWork.Context.Set<T>().Add(entity);
        }
    }
}