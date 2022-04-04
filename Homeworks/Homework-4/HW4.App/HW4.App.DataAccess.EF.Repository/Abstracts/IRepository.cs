using HW4.App.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HW4.App.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}