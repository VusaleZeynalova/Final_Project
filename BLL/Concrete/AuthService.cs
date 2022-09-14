using AutoMapper;
using BLL.Abstract;
using BLL.Contants;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AuthService(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }
        public IDataResult<User> Login(UserLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            UserToAddDto userToAddDto = _mapper.Map<UserToAddDto>(userForRegisterDto);
            userToAddDto.PasswordHash = passwordHash;
            userToAddDto.PasswordSalt = passwordSalt;
            _userService.Add(userToAddDto);
            User user = _mapper.Map<User>(userToAddDto);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }
    }
}
