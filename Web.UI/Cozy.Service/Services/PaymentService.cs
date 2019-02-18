using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Service.Services
{
    public interface IPaymentService
    {
        Payment Create(Payment newPayment);
        Payment GetById(int paymentId);
        ICollection<Payment> GetByTenantId(string tenantId);
        ICollection<Payment> GetByLeaseId(int leaseId);
    }
    class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository) =>
            _paymentRepository = paymentRepository;

        public Payment Create(Payment newPayment) =>
            _paymentRepository.Create(newPayment);

        public bool DeleteById(int paymentId) =>
            _paymentRepository.DeleteById(paymentId);


        public Payment GetById(int paymentId) =>
            _paymentRepository.GetById(paymentId);


        public ICollection<Payment> GetByLeaseId(int leaseId) =>
            _paymentRepository.GetByLeaseId(leaseId);

        public ICollection<Payment> GetByTenantId(string tenantId) =>
            _paymentRepository.GetByTenantId(tenantId);

        public Payment Update(Payment updatedPayment) =>
            _paymentRepository.Update(updatedPayment);
    }
}
