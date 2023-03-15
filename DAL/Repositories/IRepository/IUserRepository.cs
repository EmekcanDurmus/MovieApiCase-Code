using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.IRepository
{
    public interface IUserRepository/*:IRepository<User>*/
    {
        bool IsUniqueUser(string username);
        User Authenticate(string username, string password);
        User Register(string username, string password);
    }
}
