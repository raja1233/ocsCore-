using OCS.DataAccessLayer.Models;
using OCS.RepositoryLayer.Common.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.RepositoryLayer.Interface
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetUserByID(long UserID);
        bool UpdateUser(User user);
    }
}
