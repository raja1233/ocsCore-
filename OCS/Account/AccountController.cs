using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OCS.CommonLayer;
using OCS.CommonLayer.Filter;
using OCS.DataAccessLayer.Entites;
using OCS.DataAccessLayer.Models;
using OCS.SerivceLayer;
using OCS.SerivceLayer.Interface;
using OCS.ViewModelLayer.UserRole;
using static OCS.CommonLayer.Enum.CommonEnum;

using Microsoft.Extensions.Configuration;
using OCS.ViewModelLayer.Common;

namespace OCS.Account
{
    [Produces("application/json")]
    [Route("api/Account")]
    //[ValidateModel]
    //[AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly ILogger _logger;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly ITokenService _tokenService;
        private readonly ICommonService _commonService;
        private readonly IUserService _userService;
        private string DomainName = OCSConnectionStringEnum.Host; //its Merging db
        CommonMethods commonMethods = null;
        public AccountController(ITokenService tokenService, IOptions<JwtIssuerOptions> jwtOptions, ILoggerFactory loggerFactory, IUserService userService, Microsoft.Extensions.Configuration.IConfiguration config, ICommonService commonService)
        {
            _config = config;
            _jwtOptions = jwtOptions.Value;
            _userService = userService;
            _commonService = commonService;
            commonMethods = new CommonMethods();
            _logger = loggerFactory.CreateLogger<AccountController>();
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            _tokenService = tokenService;
        }
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
        [HttpPost]
        [Route("loginUser")]
        public JsonModel Login([FromBody]UserViewModel dbUser)
        {
            JsonModel responseModel = new JsonModel();
            GetIPFromRequst();
            //get default location 
            try
            {
                if (dbUser != null)
                {
                    User userInfo = _userService.GetUserInfoByUserName(dbUser.UserName);
                    dbUser.Password = _commonService.MD5Hash(dbUser.Password);
                    if (userInfo != null && userInfo.UserName.ToLower() == dbUser.UserName.ToLower() && userInfo.Password.ToLower() == dbUser.Password.ToLower() && userInfo.IsDeleted == false)
                    {
                        //save IP and MAC address
                        #region save IP and MAC Address
                        bool machineData = false;
                        #endregion
                        #region get doman name                        
                        StringValues Host = string.Empty; HttpContext.Request.Headers.TryGetValue("BusinessToken", out Host);
                        #endregion
                        //create claim for login user
                        var claims = new[]
                        {
                            new Claim("UserID", userInfo.Id.ToString()),
                            new Claim("RoleID", userInfo.RoleID.ToString()),
                            new Claim("UserName", userInfo.UserName.ToString()),
                            new Claim(JwtRegisteredClaimNames.Sub, dbUser.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, _jwtOptions.JtiGenerator()),
                            new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                          };
                        //fetching secret key from appsetting.json//
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt").GetSection("Key").Value));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_config.GetSection("Jwt").GetSection("Issuer").Value,
                                      _config.GetSection("Jwt").GetSection("Issuer").Value,
                                      expires: _jwtOptions.Expiration,
                                      signingCredentials: creds,
                                      claims: claims);
                        //add login user's role in token
                        token.Payload["roles"] = userInfo.UserRoles.RoleName;
                        // reponseUserInfo.UserRoles = new UserRoles();
                        LoginPermissionViewModel loginPermissionInfo = new LoginPermissionViewModel();
                        ServiceRequest serviceRequest = new ServiceRequest()
                        {
                            Id = Convert.ToInt32(userInfo.UserRoles.Id)
                        };
                        loginPermissionInfo.RoleName = userInfo.UserRoles.RoleName;
                        loginPermissionInfo.UserId = userInfo.Id;
                        loginPermissionInfo.UserName = userInfo.UserName;
                        loginPermissionInfo.FullName = userInfo.FirstName + " " + userInfo.LastName;
                        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);
                        responseModel.isSuccess = true;
                        responseModel.StatusCode = 200;
                        responseModel.Message = "Login Successfull";
                        responseModel.data = loginPermissionInfo;
                        responseModel.access_token = encodedJwt;
                        responseModel.expires_in = (int)_jwtOptions.ValidFor.TotalSeconds;
                        return responseModel;
                    }
                    else
                    {
                        responseModel.isSuccess = false;
                        responseModel.StatusCode = 401;
                        responseModel.Message = "Invalid UserName or Password";
                        responseModel.access_token = "";
                        responseModel.expires_in = 0;
                        return responseModel;
                    }
                }
                else
                {
                    responseModel.isSuccess = false;
                    responseModel.StatusCode = 400;
                    responseModel.Message = "Login failed";
                    responseModel.access_token = "";
                    responseModel.expires_in = 0;
                    return responseModel;
                }
            }
            catch (Exception ex)
            {
                responseModel.isSuccess = false;
                responseModel.StatusCode = 500;
                responseModel.Message = "Login failed";
                responseModel.access_token = "";
                responseModel.expires_in = 0;
                return responseModel;
            }
        }
        /// <summary>
        /// this method is use to get the ip from request
        /// </summary>
        /// <returns></returns>
        private TokenModel GetIPFromRequst()
        {
            StringValues ipAddress;
            TokenModel token = new TokenModel();
            HttpContext.Request.Headers.TryGetValue("IPAddress", out ipAddress);
            if (!string.IsNullOrEmpty(ipAddress)) { token.IPAddress = ipAddress; } else { token.IPAddress = "203.129.220.76"; }
            return token;
        }
        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
        /// <summary>
        /// IMAGINE BIG RED WARNING SIGNS HERE!
        /// You'd want to retrieve claims through your claims provider
        /// in whatever way suits you, the below is purely for demo purposes!
        /// </summary>
        private static ClaimsIdentity GetClaimsIdentity(ApplicationUser user, User dbUser)
        {
            CommonMethods commonMethods = new CommonMethods();

            if (dbUser != null && (user.UserName.ToUpper() == dbUser.UserName.ToUpper() && user.Password == commonMethods.Decrypt(dbUser.Password)))
            {
                return new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"),
                  new[]
                  {
                   new Claim("HealthCare", "IAmAuthorized")
                  });
            }
            else
            {
                return null;
            }
        }
        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        //[HttpPost]
        //[Route("Register")]
        //public JsonModel registration(User user)
        //{
        //    JsonModel responseModel = new JsonModel();
        //    try
        //    {
        //        if(user!=null)
        //        {
        //            user.Password = _commonService.MD5Hash(user.Password);
        //            var roleDetail = _userService.GetRoleByName(user.RoleName);
        //            //List<object> obj= roleDetail as List<object>();
        //            UserRoles x=new UserRoles()
        //            {
                       
        //            }
        //            if (roleDetail!=null)
        //            {
        //                UserRoleViewModel ur = new UserRoleViewModel();
                       
        //            }
        //            var SaveUserDetail=_userService.SaveUserDetails(user);
                  
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return responseModel;
        //}
        
    }
   
}
