using BLL.Abstract;
using BLL.Contants;
using Entities.DTOs.EmployeeDTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MahammadFinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _environment;
        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment webHost)
        {
            _employeeService = employeeService;
            _environment = webHost;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _employeeService.GetWithInclude());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] EmployeeToAddDto employeeToAddDto)
        {
            try
            {
                var originalFileName = employeeToAddDto.ImagePath.FileName;
                string fileExtension = employeeToAddDto.ImagePath.FileName.Substring(employeeToAddDto.ImagePath.FileName.LastIndexOf('.') + 1);
                Guid guid = Guid.NewGuid();
                var uploads = Path.Combine(_environment.WebRootPath, "files");
                string fileName = guid.ToString() + "-fileName-" + employeeToAddDto.ImagePath.FileName;
                string filePath = "/" + fileName;
                if (!Directory.Exists(Path.Combine(uploads)))
                    Directory.CreateDirectory(Path.Combine(uploads));

                if (employeeToAddDto.ImagePath.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await employeeToAddDto.ImagePath.CopyToAsync(fileStream);
                    }
                }
                return Ok(await _employeeService.Add(employeeToAddDto, fileName));

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int empId)
        {
            try
            {
                await _employeeService.Delete(empId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EmployeeToUpdateDto employeeToUpdate)
        {
            try
            {
                var originalFileName = employeeToUpdate.ImagePath.FileName;
                string fileExtension = employeeToUpdate.ImagePath.FileName.Substring(employeeToUpdate.ImagePath.FileName.LastIndexOf('.') + 1);
                Guid guid = Guid.NewGuid();
                var uploads = Path.Combine(_environment.WebRootPath, "files");
                string fileName = guid.ToString() + "-fileName-" + employeeToUpdate.ImagePath.FileName;
                string filePath = "/" + fileName;
                if (!Directory.Exists(Path.Combine(uploads)))
                    Directory.CreateDirectory(Path.Combine(uploads));

                if (employeeToUpdate.ImagePath.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await employeeToUpdate.ImagePath.CopyToAsync(fileStream);
                    }
                }
                await _employeeService.Update(employeeToUpdate, fileName);
                return Ok();

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPatch("UptadeWithImage")]
        public async Task<IActionResult> UpdateWithImage([FromForm]EmployeeToUpdateDtoWithImage employeeToUpdate)
        {
            try
            {
                var originalFileName = employeeToUpdate.ImagePath.FileName;
                string fileExtension = employeeToUpdate.ImagePath.FileName.Substring(employeeToUpdate.ImagePath.FileName.LastIndexOf('.') + 1);
                Guid guid = Guid.NewGuid();
                var uploads = Path.Combine(_environment.WebRootPath, "files");
                string fileName = guid.ToString() + "-fileName-" + employeeToUpdate.ImagePath.FileName;
                string filePath = "/" + fileName;
                if (!Directory.Exists(Path.Combine(uploads)))
                    Directory.CreateDirectory(Path.Combine(uploads));

                if (employeeToUpdate.ImagePath.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await employeeToUpdate.ImagePath.CopyToAsync(fileStream);
                    }
                }
                await _employeeService.UpdateWithImage(employeeToUpdate, fileName);
                return Ok();

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UptadeWithoutImage")]
        public async Task<IActionResult> UptadeWithPatch(JsonPatchDocument employeeToUpdateDto,int id)
        {
            try
            {
              await  _employeeService.UpdateOnlyChanged(id,employeeToUpdateDto);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
