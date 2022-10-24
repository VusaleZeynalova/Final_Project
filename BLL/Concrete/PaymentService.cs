using AutoMapper;
using BLL.Abstract;
using DAL.UnitOfWorks;
using Entities.Concrete;
using Entities.DTOs.EmployeeDTOs;
using Entities.DTOs.PaymentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(PaymentToAddDto paymentToAddDto)
        {
            Payment payment = _mapper.Map < Payment >(paymentToAddDto);
            await _unitOfWork.PaymentRepository.Add(payment);
            await _unitOfWork.Commit();
        }

        public async Task<List<PaymentToListDto>> Get(int empId)
        {
            List<Payment> payments = await _unitOfWork.PaymentRepository.GetEmployee(empId);
            List<PaymentToListDto> paymentToListDtos = _mapper.Map<List<PaymentToListDto>>(payments);
            return paymentToListDtos;
        }
    } 
}
