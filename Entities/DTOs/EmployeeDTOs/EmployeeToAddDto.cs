﻿using Core.CoreEntities.Abstract;
using Entities.Concrete;
using Entities.DTOs.DepartmentDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EmployeeDTOs
{
    public class EmployeeToAddDto:IDto
    {
        public int DepartmentId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime? LastDay { get; set; }
        public IFormFile ImagePath { get; set; }
    }
}
