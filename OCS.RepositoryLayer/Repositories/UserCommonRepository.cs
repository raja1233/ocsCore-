using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using OCS.CommonLayer;
using OCS.DataAccessLayer;
using OCS.DataAccessLayer.Entites;
using OCS.DataAccessLayer.Models;
using OCS.RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static OCS.CommonLayer.Enum.CommonEnum;

namespace OCS.RepositoryLayer.Repositories
{
    public class UserCommonRepository : IUserCommonRepository
    {
        private readonly OnlineCatalogueSystemContext _context;
        //private readonly HCMasterContext _masterContext;
        public UserCommonRepository(OnlineCatalogueSystemContext context)//, HCMasterContext masterContext)
        {
            this._context = context;
            // this._masterContext = masterContext;
        }

        /// <summary>
        /// get user by user name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUserByUserName(string userName)
        {
            try
            {
                return _context.User.Where(m => m.UserName.ToUpper() == userName.ToUpper()).Include(x => x.UserRoles).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        /// <summary>
        /// save token into database
        /// </summary>
        /// <param name="authenticationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataAccessLayer.Models.AuthenticationToken AuthenticationToken(DataAccessLayer.Models.AuthenticationToken authenticationToken, int id = 0)
        {
            try
            {
                if (id > 0)
                {
                    var tokenInfo = _context.AuthenticationToken.Find(id);
                    tokenInfo.ResetPasswordToken = authenticationToken.ResetPasswordToken;
                    tokenInfo.Token = authenticationToken.Token;
                    tokenInfo.IsDeleted = authenticationToken.IsDeleted;
                    tokenInfo.DeletedBy = authenticationToken.DeletedBy;
                    tokenInfo.DeletedDate = authenticationToken.DeletedDate;
                    tokenInfo.IsActive = authenticationToken.IsActive;
                    _context.SaveChanges();
                    return tokenInfo;
                }
                else
                {
                    _context.AuthenticationToken.Add(authenticationToken);
                    _context.SaveChanges();
                    return authenticationToken;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        ///  To update failed access count
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        public JsonModel UpdateAccessFailedCount(int userID, TokenModel tokenModel)
        {
            try
            {
                string Message = string.Empty;
                var user = _context.User.Where(p => p.Id == userID).FirstOrDefault();
                if (user.UserRoles.RoleName == OrganizationRoles.Admin.ToString())
                {
                    Message = StatusMessage.InvalidUserOrPassword;//If Admin login with wrong credentials
                }
                else if (user.AccessFailedCount >= 2) // if user attemped 3 time with wrong credentials
                {
                    user.IsBlock = true;
                    user.BlockDateTime = DateTime.UtcNow;
                    user.AccessFailedCount = user.AccessFailedCount + 1;
                    Message = UserAccountNotification.AccountDeactiveOrExpirePass;//block
                }
                else // if wrong attemped increase the failed count
                {
                    if (user.BlockDateTime == null)
                    {
                        Message = UserAccountNotification.AccountDeactive;
                        user.AccessFailedCount = user.AccessFailedCount + 1;
                        Message = UserAccountNotification.InvalidPassword;//Invaild Password
                    }
                    else
                    {
                        user.AccessFailedCount = user.AccessFailedCount + 1;
                        Message = UserAccountNotification.InvalidPassword;//Invaild Password
                    }
                }
                //save
                _context.User.Update(user);
                _context.SaveChanges();
                //return
                return new JsonModel()
                {
                    data = new object(),
                    Message = Message,
                    StatusCode = (int)HttpStatusCodes.Unauthorized//(Invalid credentials)
                };
            }
            catch (Exception ex)
            {
                return new JsonModel()
                {
                    data = new object(),
                    Message = ex.Message,
                    StatusCode = (int)HttpStatusCodes.Unauthorized//(Invalid credentials)
                };
            }
        }

        /// <summary>
        /// To reset user
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="tokenModel"></param>
        public void ResetUserAccess(int userID, TokenModel tokenModel)
        {
            try
            {
                var user = _context.User.Where(p => p.Id == userID).FirstOrDefault();
                user.AccessFailedCount = 0;
                user.BlockDateTime = null;
                user.IsBlock = false;
                _context.User.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
