using Microsoft.EntityFrameworkCore;
using OCS.DataAccessLayer;
using OCS.DataAccessLayer.Models;
using OCS.RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCS.RepositoryLayer.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly OnlineCatalogueSystemContext _context;
        //private readonly HCMasterContext _masterContext;

        public TokenRepository(OnlineCatalogueSystemContext context)//, HCMasterContext masterContext)
        {
            this._context = context;
            //this._masterContext = masterContext;
        }

        /// <summary>
        /// get user detail for their name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUserByUserName(string userName)
        {
            try
            {
                return _context.User.Where(m => m.UserName.ToUpper() == userName.ToUpper() && m.IsActive == true && m.IsDeleted == false && m.IsBlock == false).Include(x => x.UserRoles).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        /// <summary>
        /// To reset user
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="tokenModel"></param>
        public void ResetUserAccess(int userID)
        {
            try
            {
                var user = _context.User.Where(p => p.Id == userID && p.IsActive == true && p.IsBlock == false && p.IsDeleted == false).FirstOrDefault();
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
