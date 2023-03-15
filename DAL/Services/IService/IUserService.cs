using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Services.IService
{
    public interface IUserService
    {
        bool IsUniqueUser(string username);
        User Authenticate(string username, string password);
        User Register(string username, string password);
    }
}
