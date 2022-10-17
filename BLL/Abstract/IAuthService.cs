using Core.CoreEntities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IAuthService
    {
        Task<User> Register(UserRegisterDto userForRegisterDto, string password);
        Task<IDataResult<User>> Login(UserLoginDto userForLoginDto);
        Task<AccessToken> CreateAccessToken(User user);
    }
}
