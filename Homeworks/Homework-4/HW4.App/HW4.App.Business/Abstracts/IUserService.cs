using HW4.App.Domain.Entities;
using System.Collections.Generic;

namespace HW4.App.Business.Abstracts
{
    public interface IUserService
    {
        List<User> GetUsers();
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
