using OCS.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.SerivceLayer.Interface
{
    public interface ITokenService
    {
        User GetUserByUserName(string userName);
    }
}
