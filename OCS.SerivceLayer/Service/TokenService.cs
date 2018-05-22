using Microsoft.Extensions.Options;
using OCS.CommonLayer;
using OCS.DataAccessLayer;
using OCS.DataAccessLayer.Entites;
using OCS.DataAccessLayer.Models;
using OCS.RepositoryLayer.Interface;
using OCS.SerivceLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using static OCS.CommonLayer.Enum.CommonEnum;

namespace OCS.SerivceLayer.Service
{
    public class TokenService : ITokenService
    {
        #region Global Variables
        private CommonMethods _commonMethods;
        private readonly ITokenRepository _tokenRepository;
        private OnlineCatalogueSystemContext _organizationContext;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IUserRepository _userRepository;

        private readonly double BlockedHour = 2;
        #endregion
        public TokenService(ITokenRepository tokenRepository, OnlineCatalogueSystemContext organizationContext,
            IOptions<JwtIssuerOptions> jwtOptions,
            IUserRepository userRepository
            )
        {
            this._tokenRepository = tokenRepository;
            _organizationContext = organizationContext;
            _jwtOptions = jwtOptions.Value;
            _userRepository = userRepository;
            _commonMethods = new CommonMethods();
        }


        public User GetUserByUserName(string userName)
        {
            return _tokenRepository.GetUserByUserName(userName);
        }


        private ClaimsIdentity CheckUserInfo(ApplicationUser user, string UserName, string password)
        {
            if (user.UserName.ToUpper() == UserName.ToUpper() && user.Password == _commonMethods.Decrypt(password))
            {
                return new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"),
                  new[]
                  {
                   new Claim("OnlinecatalogueSystem", "IAmAuthorized")
                  });
            }
            else
            {
                return null;
            }
        }

        private JsonModel LoginUser(ApplicationUser applicationUser, User dbUser, TokenModel token, ClaimsIdentity identity)
        {
            JsonModel jsonModel = new JsonModel();

            //get login user role name
            string[] userRole = { dbUser.UserRoles.RoleName };

            //save IP and MAC address
            #region save IP and MAC Address
            bool machineData = false;
            token.MacAddress = applicationUser.MacAddress;
            token.UserID = dbUser.Id;
            token.RoleID = dbUser.RoleID;
            token.UserName = dbUser.UserName;
            //token.OrganizationID = dbUser.OrganizationID;
            // token.StaffID = staff.Id;
            token.IPAddress = applicationUser.IpAddress;
            //if (!IsMachineLoggedIn(token))
            //{
            //    machineData = SaveMachineDataIPAndMac(token);
            //}
            #endregion

            var encodedJwt = GenerateToken(identity, token, userRole); //new JwtSecurityTokenHandler().WriteToken(jwt);

            // return the staff or patient response
            if (userRole[0] == OrganizationRoles.Client.ToString())
            {
                jsonModel.access_token = encodedJwt;
                jsonModel.expires_in = (int)_jwtOptions.ValidFor.TotalSeconds;
            }
            else
            {
                jsonModel.access_token = encodedJwt;
                jsonModel.expires_in = (int)_jwtOptions.ValidFor.TotalSeconds;

            }
            return jsonModel;
        }


        private static long ToUnixEpochDate(DateTime date)
         => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private JsonModel UpdateAccessFailedCount(TokenModel tokenModel)
        {

            try
            {
                string Message = string.Empty;
                var user = _userRepository.GetUserByID(tokenModel.UserID);
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
                _userRepository.UpdateUser(user);
                //return
                return new JsonModel
                {
                    Message = Message,
                    data = new object(),
                    StatusCode = (int)HttpStatusCodes.Unauthorized
                };
            }
            catch (Exception ex)
            {
                return new JsonModel
                {
                    Message = ex.Message,
                    data = new object(),
                    StatusCode = (int)HttpStatusCodes.Unauthorized
                };

            }
        }

        private string GenerateToken(ClaimsIdentity identity, TokenModel token, string[] Roles = null)
        {
            var claims = new[]
            {
             new Claim("UserID", token.UserID.ToString()),
             new Claim("RoleID", token.RoleID.ToString()),                      // not required please don't chamge
             new Claim("UserName", token.UserName.ToString()),
             new Claim("OrganizationID", token.OrganizationID.ToString()),              // not required please don't chamge
             new Claim("StaffID", token.StaffID.ToString()),                     // not required please don't chamge
             new Claim("LocationID", token.LocationID.ToString()),                  // not required please don't chamge
             new Claim("DomainName",token.DomainName),                     // Domain name always add in token
             new Claim("PatientID", token.PateintID.ToString()),
             new Claim(JwtRegisteredClaimNames.Sub, token.UserName),
             new Claim(JwtRegisteredClaimNames.Jti, _jwtOptions.JtiGenerator()),
             new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
             identity.FindFirst("HealthCare")
             };

            var jwt = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: _jwtOptions.NotBefore,
            expires: _jwtOptions.Expiration,
            signingCredentials: _jwtOptions.SigningCredentials);
            if (Roles != null)
            {
                jwt.Payload["roles"] = Roles;
            }
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

    }
}
