using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    class EFCorePaymentRepository : IPaymentRepository
    {
        public Payment Create(Payment newPayment)
        {
            using (var context = new CozyDbContext())
            {
                context.Payments.Add(newPayment);
                context.SaveChanges();

                return newPayment;
            }
        }

        public bool DeleteById(int paymentId)
        {
            using (var context = new CozyDbContext())
            {
                var payment = GetById(paymentId);
                context.Remove(payment);
                context.SaveChanges();

                if(GetById(paymentId) == null)
                {
                    return true;
                }
                return false;
            }
        }

        public Payment GetById(int paymentId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Payments.Single(p => p.Id == paymentId);
            }
        }

        public ICollection<Payment> GetByLeaseId(int leaseId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Payments.Where(p => p.LeaseId == leaseId).ToList();
            }
        }

        public ICollection<Payment> GetByTenantId(string tenantId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Payments.Where(p => p.TenantId == tenantId).ToList();
            }
        }

        public Payment Update(Payment updatedPayment)
        {
            using (var context = new CozyDbContext())
            {
                var existingPayment = GetById(updatedPayment.Id);
                context.Entry(existingPayment).CurrentValues.SetValues(updatedPayment);
                context.SaveChanges();

                return existingPayment;
            }
        }
    }
}
