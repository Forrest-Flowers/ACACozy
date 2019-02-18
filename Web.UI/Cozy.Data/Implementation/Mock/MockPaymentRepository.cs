using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    public class MockPaymentRepository : IPaymentRepository
    {
        private List<Payment> Payments = new List<Payment>();

        public Payment Create(Payment newPayment)
        {
            newPayment.Id = Payments.OrderByDescending(p => p.Id).Single().Id + 1;
            Payments.Add(newPayment);

            return newPayment;
        }

        public bool DeleteById(int paymentId)
        {
            var payment = GetById(paymentId);
            Payments.Remove(payment);

            return true;
        }

        public Payment GetById(int paymentId)
        {
            return Payments.Single(p => p.Id == paymentId);
        }

        public ICollection<Payment> GetByLeaseId(int leaseId)
        {
            return Payments.FindAll(p => p.LeaseId == leaseId);
        }

        public ICollection<Payment> GetByTenantId(string tenantId)
        {
            return Payments.FindAll(p => p.TenantId == tenantId);
        }

        public Payment Update(Payment updatedPayment)
        {
            DeleteById(updatedPayment.Id);
            Payments.Add(updatedPayment);

            return updatedPayment;
        }
    }
}
