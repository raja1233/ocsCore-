using OCS.DataAccessLayer;
using OCS.DataAccessLayer.Models;
using OCS.RepositoryLayer.Common.Repository;
using OCS.RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCS.RepositoryLayer.Repositories
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        private OnlineCatalogueSystemContext _context;
        public UserRepository(OnlineCatalogueSystemContext context) : base(context)
        {
            this._context = context;
        }

        public User GetUserByID(long UserID)
        {
            try
            {
                return _context.User.Where(x => x.Id == UserID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _context.User.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
