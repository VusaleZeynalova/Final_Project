using AutoMapper;
using BLL.Abstract;
using BLL.Contants;
using Core.Utilities.Results;
using DAL.BLL;
using DAL.UnitOfWorks;
using Entities.Concrete;
using Entities.DTOs.EmployeeDTOs;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> Add(EmployeeToAddDto employeeToAddDto, string imagePath)
        {
            Employee employee = _mapper.Map<Employee>(employeeToAddDto);
            employee.ImagePath = imagePath;
            var result = BusinessRules.Run(CheckLastday(employee.LastDay, employee.FirstDay));
            if (result == null)
            {
                await _unitOfWork.EmployeeRepository.Add(employee);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.Success);
            }
            return result;
        }

        public async Task Delete(int empId)
        {
            Employee employee = await _unitOfWork.EmployeeRepository.Get(e => e.EmployeeId == empId);
            _unitOfWork.EmployeeRepository.Delete(employee);
            await _unitOfWork.Commit();


        }

        public async Task<List<EmployeeToListDto>> GetWithInclude()
        {
            List<Employee> employees = await _unitOfWork.EmployeeRepository.GetWithInclude();
            List<EmployeeToListDto> employeeToListDtos = _mapper.Map<List<EmployeeToListDto>>(employees);
            return employeeToListDtos;
        }

        public async Task UpdateOnlyChanged(int empId, JsonPatchDocument employeeToUpdateDto)
        {
            var employee = await _unitOfWork.EmployeeRepository.Get(e => e.EmployeeId == empId);
            if (employee != null)
            {
                employeeToUpdateDto.ApplyTo(employee);
                await _unitOfWork.Commit();
            }
        }

        public async Task UpdateWithImage(EmployeeToUpdateDtoWithImage employeeToUpdateDto, string imagePath)
        {

            var employee2 = await _unitOfWork.EmployeeRepository.Get(e => e.EmployeeId == employeeToUpdateDto.EmployeeId);
            employee2.ImagePath = imagePath;
            await _unitOfWork.Commit();


        }

        public async Task Update(EmployeeToUpdateDto employeeToUpdateDto, string imagePath)
        {
            Employee employee = _mapper.Map<Employee>(employeeToUpdateDto);
            employee.ImagePath = imagePath;
            _unitOfWork.EmployeeRepository.Update(employee);
            await _unitOfWork.Commit();

        }


     

        private IResult CheckLastday(DateTime? lastDay, DateTime firstDay)
        {
            if ((firstDay > lastDay) && lastDay is not null && lastDay <= DateTime.Now)
            {
                return new ErrorResult(Messages.LastDayIsNotCorrect);
            }
            return new SuccessResult();
        }
    }
}
