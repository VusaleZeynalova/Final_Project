using Core.Utilities.Results;
using Entities.DTOs.EmployeeDTOs;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IEmployeeService
    {
        Task<IResult> Add(EmployeeToAddDto employeeToAddDto, string imagePath);
        Task Delete(int empId);
        Task<List<EmployeeToListDto>> GetWithInclude();
        Task UpdateWithImage(EmployeeToUpdateDtoWithImage employeeToUpdateDto,string imagePath);
        Task Update(EmployeeToUpdateDto employeeToUpdateDto,string imagePath);
        Task UpdateOnlyChanged(int empId,JsonPatchDocument employeeToUpdateDto);
        

    }
}
