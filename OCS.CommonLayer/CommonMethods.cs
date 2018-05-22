using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using OCS.DataAccessLayer.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using static OCS.CommonLayer.Enum.CommonEnum;

namespace OCS.CommonLayer
{
    public class CommonMethods
    {
        /// <summary>
        /// this method is used to save multiple images and their thumbnails
        /// </summary>
        /// <param name="obj"></param>
        public void SaveImageAndThumb(dynamic obj)
        {
            foreach (var item in obj)
            {
                string imageURL = item.ImageUrl;
                string thumbImageURL = item.ThumbImageUrl;

                byte[] bytes = Convert.FromBase64String(item.Base64);

                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    try
                    {
                        image = Image.FromStream(ms);
                        image.Save(imageURL);
                        Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                        thumb.Save(thumbImageURL);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }


        }

        /// <summary>
        /// method to get data type from string input
        /// </summary>
        /// <param name="str">string input</param>
        /// <returns></returns>
        public DataType ParseString(string str)
        {

            bool boolValue;
            Int32 intValue;
            Int64 bigintValue;
            double doubleValue;
            DateTime dateValue;

            // Place checks higher in if-else statement to give higher priority to type.

            if (bool.TryParse(str, out boolValue))
                return DataType.System_Boolean;
            else if (Int32.TryParse(str, out intValue))
                return DataType.System_Int32;
            else if (Int64.TryParse(str, out bigintValue))
                return DataType.System_Int64;
            else if (double.TryParse(str, out doubleValue))
                return DataType.System_Double;
            else if (DateTime.TryParse(str, out dateValue))
                return DataType.System_DateTime;
            else return DataType.System_String;

        }

        /// <summary>
        ///  hash password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string HashPassword(string userName, string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(userName);
            var hashedPassword = HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt);
            return Convert.ToBase64String(hashedPassword);
        }

        /// <summary>
        /// combine
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        /// <summary>
        /// hash password with salt
        /// </summary>
        /// <param name="toBeHashed"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combinedHash = Combine(toBeHashed, salt);
                return sha256.ComputeHash(combinedHash);
            }
        }

        /// <summary>
        /// encrypt the simple text 
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Dispose();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        /// <summary>
        /// decrypt the encrypt data
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Dispose();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }




        /// <summary>
        /// get user data from token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public dynamic GetDataFromToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                return handler.ReadToken(token);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public DataAccessLayer.Models.TokenModel GetTokenDataModel(HttpContext request)
        {
            DataAccessLayer.Models.TokenModel token = null;
            StringValues authorizationToken;
            StringValues timezone;
            StringValues ipAddress;
            StringValues locationID;            
            JsonModel response = new JsonModel();
            var authHeader = request.Request.Headers.TryGetValue("Authorization", out authorizationToken);
            var authToken = authorizationToken.ToString().Replace("Bearer", "").Trim();
            request.Request.Headers.TryGetValue("Timezone", out timezone);
            request.Request.Headers.TryGetValue("IPAddress", out ipAddress);
            request.Request.Headers.TryGetValue("LocationID", out locationID);            
            try
            {
                CommonMethods commonMethods = new CommonMethods();
                if (authToken != null)
                {
                    var encryptData = GetDataFromToken(authToken);
                    if (encryptData != null && encryptData.Claims != null)
                    {
                        token = new DataAccessLayer.Models.TokenModel()
                        {
                            UserID = Convert.ToInt32(encryptData.Claims[0].Value),
                            RoleID = Convert.ToInt32(encryptData.Claims[1].Value),
                            UserName = Convert.ToString(encryptData.Claims[2].Value),
                            OrganizationID = Convert.ToInt32(encryptData.Claims[3].Value),
                            StaffID = Convert.ToInt32(encryptData.Claims[4].Value),
                            LocationID = !string.IsNullOrEmpty(locationID) ? Convert.ToInt32(locationID) : Convert.ToInt32(encryptData.Claims[5].Value), //it should be from front end
                            DomainName = Convert.ToString(encryptData.Claims[6].Value),
                            Timezone = timezone,
                            IPAddress = ipAddress,
                            
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            token = new DataAccessLayer.Models.TokenModel() { UserID = 1, OrganizationID = 1, Timezone = "India Standard Time", IPAddress = "203.129.220.76", LocationID = 1, RoleID = 1, DomainName = "4Xdn04rbUB78Gd2UDWMiUrw+LCJHi8S4yTHeyN54z8JaxQ0etkkhME8hOoImr1lt" };

            token.Request = request;
            return token;
        }

        public DateTime ConvertUtcTime(DateTime Date, string Timezone)
        {
            try
            {
                TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById(Timezone);
                DateTime userTime = TimeZoneInfo.ConvertTimeToUtc(Date, timeInfo);
                return userTime;
            }
            catch (Exception e)
            {
                TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"); //TO DO : need to fix this 
                DateTime userTime = TimeZoneInfo.ConvertTimeToUtc(Date, timeInfo);
                return userTime;
            }

        }
        public DateTime ConvertFromUtcTime(DateTime Date, string Timezone)
        {
            try
            {
                TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById(Timezone);
                DateTime userTime = TimeZoneInfo.ConvertTimeFromUtc(Date, timeInfo);
                return userTime;
            }
            catch (Exception)
            {

                TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"); //TO DO : need to fix this 
                DateTime userTime = TimeZoneInfo.ConvertTimeFromUtc(Date, timeInfo);
                return userTime;
            }

        }

        public DataTable ListToDatatable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public string CreateImageUrl(HttpContext request, string directoy, string fileName)
        {
            try
            {
                return request.Request.Scheme + "://" + request.Request.Host + request.Request.PathBase + directoy + fileName;
            }
            catch (Exception)
            {

                return string.Empty;
            }

        }

        public double GetTimezoneOffset(DateTime date, string timezone)
        {
            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById(timezone).GetUtcOffset(date).TotalMinutes;
            }
            catch
            {
                return 0;
            }
        }
    }
}
