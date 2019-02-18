using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    public interface ITenantRepository
    {
        //CRUD Tenant

        //Create
        Tenant Create(Tenant newTenant);

        //Read
        Tenant GetById(string tenantId);

        //Update
        Tenant Update(Tenant updatedTenant);

        //Delete
        bool DeleteById(string tenantId);
    }
}
