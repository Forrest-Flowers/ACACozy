using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    public interface IMaintenanceRepository
    {
        //CRUD Maintenance

        //Create
        Maintenance Create(Maintenance newMaintenance);

        //Read
        Maintenance GetById(int maintenanceId);
        ICollection<Maintenance> GetByHomeId(int homeId);
        ICollection<Maintenance> GetByTenantId(string tenantId);
        ICollection<Maintenance> GetByMaintenanceStatusId(int msId);

        //Update
        Maintenance Update(Maintenance updatedMaintenance);

        //Delete
        bool DeleteById(int maintenanceId);
    }
}
