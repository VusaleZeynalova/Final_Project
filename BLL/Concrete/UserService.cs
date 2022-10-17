using AutoMapper;
using BLL.Abstract;
using Core.CoreEntities.Concrete;
using Core.Utilities.Results;
using DAL.Abstract;
using DAL.UnitOfWorks;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork userRepository, IMapper mapper)
        {
            _unitOfWork = userRepository;
            _mapper = mapper;
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _unitOfWork.UserRepository.GetClaims(user);
        }

        public void Add(UserToAddDto userToAddDto)
        {
            User user = _mapper.Map<User>(userToAddDto);
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Commit();

        }

        public async Task<User> GetByMail(string email)
        {
            return await _unitOfWork.UserRepository.Get(x => x.Email == email);
        }
    }
}
