using System;

namespace HW4.App.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        AppDbContext Context { get; }
        void Commit();

    }
}