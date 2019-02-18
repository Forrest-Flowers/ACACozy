using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    public interface ILeaseRepository
    {
        //CRUD Lease

        //Create
        Lease Create(Lease newLease);
        //Read
        Lease GetById(int leaseId);
        ICollection<Lease> GetByTenantId(string tenantId);
        ICollection<Lease> GetByHomeId(int homeId);

        //Update
        Lease Update(Lease updatedLease);

        //Delete
        bool DeleteById(int leaseId);
    }
}
