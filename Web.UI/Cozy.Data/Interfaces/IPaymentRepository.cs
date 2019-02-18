using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    public interface IPaymentRepository
    {
        //CRUD Payment

        //Create
        Payment Create(Payment newPayment);

        //Read
        Payment GetById(int paymentId);
        ICollection<Payment> GetByTenantId(string tenantId);
        ICollection<Payment> GetByLeaseId(int leaseId);

        //Update
        Payment Update(Payment updatedPayment);

        //Delete
        bool DeleteById(int paymentId);
    }
}
