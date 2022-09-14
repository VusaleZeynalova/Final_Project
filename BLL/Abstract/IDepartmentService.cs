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
        void Add(DepartmentToAddDto departmentToAddDto);
        void Update(DepartmentToUpdateDto departmentToUpdateDto);
        void Delete(int id);
        List<DepartmentToListDto> Get();
    }
}
