using Microsoft.AspNetCore.Authentication;
using OCS.DataAccessLayer.Entites;
using OCS.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.RepositoryLayer.Interface
{
    public interface IUserCommonRepository
    {
        User GetUserByUserName(string userName);
        DataAccessLayer.Models.AuthenticationToken AuthenticationToken(DataAccessLayer.Models.AuthenticationToken authenticationToken, int id = 0);
        JsonModel UpdateAccessFailedCount(int userID, TokenModel tokenModel);
        void ResetUserAccess(int userID, TokenModel tokenModel);
    }
}
