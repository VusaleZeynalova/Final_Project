using BLL.Abstract;
using Entities.DTOs.PaymentDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahammadFinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IEmployeeService _employeeService;
        public PaymentController(IPaymentService paymentService, IEmployeeService employeeService)
        {
            _paymentService = paymentService;
            _employeeService = employeeService;

        }

        [HttpPost]
        public async Task<IActionResult> Add(PaymentToAddDto paymentToAddDto)
        {
            try
            {
                await _paymentService.Add(paymentToAddDto);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _employeeService.GetPaymentList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetArchiveEmployeeSalary")]
        public async Task<IActionResult> GetArchiveEmployeeSalary(int empId)
        {
            try
            {
                return Ok(await _paymentService.Get(empId));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
