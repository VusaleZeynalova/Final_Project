using AutoMapper;
using BLL.Abstract;
using BLL.BusinessAspects.Autofac;
using BLL.Contants;
using Core.Utilities.Results;
using DAL.Abstract;
using DAL.UnitOfWorks;
using Entities.Concrete;
using Entities.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    [SecuredOperation("admin")]

    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork departmentRepository, IMapper mapper)
        {
            _unitOfWork = departmentRepository;
            _mapper = mapper;

        }
        public async Task Add(DepartmentToAddDto departmentToAddDto)
        {

            Department department = _mapper.Map<Department>(departmentToAddDto);
            await _unitOfWork.DepartmentRepository.Add(department);
            await _unitOfWork.Commit();

        }

        public async Task Delete(int id)
        {
            Department department =await _unitOfWork.DepartmentRepository.Get(d => d.DepartmentId == id);

             _unitOfWork.DepartmentRepository.Delete(department);
            await _unitOfWork.Commit();
        }

        public async Task<List<DepartmentToListDto>> Get()
        {

            List<Department> departments = await _unitOfWork.DepartmentRepository.GetAll();
            List<DepartmentToListDto> departmentToListDtos = _mapper.Map<List<DepartmentToListDto>>(departments);
            return departmentToListDtos;
        }

        public async Task Update(DepartmentToUpdateDto departmentToUpdateDto)
        {
            Department department = _mapper.Map<Department>(departmentToUpdateDto);
            _unitOfWork.DepartmentRepository.Update(department);
            await _unitOfWork.Commit();
        }
    }
}
