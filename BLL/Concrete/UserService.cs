using AutoMapper;
using BLL.Abstract;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public void Add(UserToAddDto userToAddDto)
        {
            User user = _mapper.Map<User>(userToAddDto);
            _userRepository.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(x => x.Email == email);
        }
    }
}
