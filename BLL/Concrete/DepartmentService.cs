using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using Entities.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;

        }
        public void Add(DepartmentToAddDto departmentToAddDto)
        {
            Department department = _mapper.Map<Department>(departmentToAddDto);
            _departmentRepository.Add(department);
        }

        public void Delete(int id)
        {
            Department department = _departmentRepository.Get(d => d.DepartmentId == id);

            _departmentRepository.Delete(department);
        }

        public List<DepartmentToListDto> Get()
        {
            List<Department> departments = _departmentRepository.GetALL();
            List<DepartmentToListDto> departmentToListDtos = _mapper.Map<List<DepartmentToListDto>>(departments);
            return departmentToListDtos;
        }

        public void Update(DepartmentToUpdateDto departmentToUpdateDto)
        {
            Department department = _mapper.Map<Department>(departmentToUpdateDto);
            _departmentRepository.Update(department);
        }
    }
}
