using OCS.DataAccessLayer.Entites;
using OCS.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.SerivceLayer.Interface
{
    public interface IUserService
    {
        User GetUserByUserName(string userName);
        AuthenticationToken AuthenticationToken(AuthenticationToken authenticationToken, int id = 0);
        JsonModel UpdateAccessFailedCount(int userID, TokenModel tokenModel);
        void ResetUserAccess(int userID, TokenModel tokenModel);
        long SaveUserDetails(User UserDetails);
        JsonModel GetRoleByName(string roleName);
        User GetUserInfoByUserName(string userName);
    }
}
