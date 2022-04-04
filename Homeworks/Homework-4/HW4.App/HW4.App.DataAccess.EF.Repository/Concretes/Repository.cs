using HW4.App.DataAccess.EntityFramework.Repository.Abstracts;
using HW4.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HW4.App.DataAccess.EntityFramework.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly IUnitOfWork unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<T> GetAll()
        {
            return unitOfWork.Context.Set<T>().Where(x => !x.IsDeleted).AsQueryable();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            // SingleOrDefault() -> It returns a single specific element from a collection of elements if element match found.
            return unitOfWork.Context.Set<T>().Where(x => !x.IsDeleted).SingleOrDefault(filter);
                    
        }

            public void Insert(T entity)
        {
            unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            T exist = unitOfWork.Context.Set<T>().Find(entity.Id);
            if (exist != null)
            {
                exist.IsDeleted = true;
                unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}