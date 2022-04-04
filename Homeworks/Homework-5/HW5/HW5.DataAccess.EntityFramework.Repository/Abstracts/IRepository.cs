using HW5.Domain.Entities;

namespace HW5.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IRepository<T> where T : Post
    {
        void Add(T entity);
    }
}