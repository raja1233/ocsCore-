using OCS.DataAccessLayer.Entites;
using OCS.DataAccessLayer.Models;
using OCS.RepositoryLayer.Common.Interface;
using OCS.RepositoryLayer.Interface;
using OCS.SerivceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCS.SerivceLayer.Service
{
    public class UserService : IUserService
    {
        #region Global Variables
        private readonly IUserCommonRepository _userCommonRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommonService _commonService;
        private readonly IRepositoryBase<UserRoles> _userRolesRepository;
        private readonly IRepositoryBase<User> _userInfoRepositry;
        private JsonModel response;
        #endregion
        public UserService(IUserCommonRepository userCommonRepository, IUserRepository userRepository, ICommonService commonService, IRepositoryBase<UserRoles> userRolesRepository, IRepositoryBase<User> userInfoRepositry)
        {
            this._userCommonRepository = userCommonRepository;
            this._userRepository = userRepository;
            this._commonService = commonService;
            _userRolesRepository = userRolesRepository;
            _userInfoRepositry = userInfoRepositry;
        }

        public User GetUserByUserName(string userName)
        {
            return _userCommonRepository.GetUserByUserName(userName);
        }

        public AuthenticationToken AuthenticationToken(AuthenticationToken authenticationToken, int id = 0)
        {
            return _userCommonRepository.AuthenticationToken(authenticationToken, id);
        }

        public JsonModel UpdateAccessFailedCount(int userID, TokenModel tokenModel)
        {
            return _userCommonRepository.UpdateAccessFailedCount(userID, tokenModel);
        }
        public void ResetUserAccess(int userID, TokenModel tokenModel)
        {
            _userCommonRepository.ResetUserAccess(userID, tokenModel);
        }


        

        #region--Save User Details--
        /// <summary>
        /// Save User Details
        /// </summary>
        /// <param name="UserDetails"></param>
        /// <returns>JsonModel</returns>
        public long SaveUserDetails(User UserDetails)
        {
            JsonModel jsonResponse = new JsonModel();
            try
            {
                UserDetails.IsActive = true;
                UserDetails.IsDeleted = false;
                UserDetails.CreatedDate = DateTime.Now;
                UserDetails.RoleID = 2;
                _userRepository.Create(UserDetails);
                _userRepository.SaveChanges();


                if (UserDetails.Id > 0)
                {
                    return UserDetails.Id;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;
        }


        #endregion
        /// <summary>
        /// method to get all roles
        /// </summary>
        /// <returns></returns>
        public JsonModel GetAllRoles()
        {
           JsonModel responseModel = new JsonModel();
            try
            {
                var rolesList = _userRolesRepository.GetAll().Where(x => x.IsDeleted == false).ToList();
                if (rolesList == null)
                {
                    responseModel.isSuccess = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = "Internal Server Error";
                    return responseModel;
                }
                else
                {
                    responseModel.isSuccess = true;
                    responseModel.StatusCode = 200;
                    responseModel.Message = "Success";
                    responseModel.data = rolesList;
                    return responseModel;
                }
            }
            catch (Exception ex)
            {
                responseModel.isSuccess = false;
                responseModel.StatusCode = 500;
                responseModel.Message = "Internal Server Error";
                return responseModel;
            }

        }

        public JsonModel GetRoleByName(string roleName)
        {
            JsonModel responseModel = new JsonModel();
            try
            {
                UserRoles roleDetails = _userRolesRepository.GetAll().Where(x => x.IsDeleted == false && x.RoleName == roleName).SingleOrDefault();
                //UserRoles userRole = new UserRoles()
                //{
                //    Id = roleDetails.Id,
                //    RoleName=roleDetails.RoleName,
                //    IsActive=roleDetails.IsActive,
                //    IsDeleted=roleDetails.IsDeleted,
                //    UserType=roleDetails.UserType
                //};

                if (roleDetails == null)
                {
                    responseModel.isSuccess = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = "Internal Server Error";
                    return responseModel;
                }
                else
                {
                    responseModel.isSuccess = true;
                    responseModel.StatusCode = 200;
                    responseModel.Message = "Success";
                    responseModel.data = roleDetails;
                    return responseModel;
                }
            }
            catch (Exception ex)
            {
                responseModel.isSuccess = false;
                responseModel.StatusCode = 500;
                responseModel.Message = "Internal Server Error";
                return responseModel;
            }

        }

        public User GetUserInfoByUserName(string userName)
        {
            return _userInfoRepositry.AllIncluding(x => x.UserRoles).Where(x => x.UserName.ToLower() == userName.ToLower()).FirstOrDefault();
        }
    }
}
