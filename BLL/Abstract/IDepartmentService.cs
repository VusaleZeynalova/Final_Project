using Core.Utilities.Results;
using Entities.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IDepartmentService
    {
        Task Add(DepartmentToAddDto departmentToAddDto);
        Task Update(DepartmentToUpdateDto departmentToUpdateDto);
        Task Delete(int id);
        Task<List<DepartmentToListDto>> Get();
    }
}
