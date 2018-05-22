using OCS.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.RepositoryLayer.Interface
{
    public interface ITokenRepository
    {
        User GetUserByUserName(string userName);
        void ResetUserAccess(int userID);
    }

}
