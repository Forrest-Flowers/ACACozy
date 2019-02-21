using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreMaintenanceRepository : IMaintenanceRepository
    {
        public Maintenance Create(Maintenance newMaintenance)
        {
            using (var context = new CozyDbContext())
            {
                context.Add(newMaintenance);
                context.SaveChanges();

                return newMaintenance;
            }
        }

        public bool DeleteById(int maintenanceId)
        {
            using (var context = new CozyDbContext())
            {
                var maintenance = GetById(maintenanceId);
                context.Remove(maintenance);
                context.SaveChanges();

                if (GetById(maintenanceId) == null)
                {
                    return true;
                }
                return false;
            }
        }

        public ICollection<Maintenance> GetByHomeId(int homeId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Maintenances.Where(m => m.HomeId == homeId).ToList();
            }
        }

        public Maintenance GetById(int maintenanceId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Maintenances.Single(m => m.Id == maintenanceId);
            }
        }

        public ICollection<Maintenance> GetByMaintenanceStatusId(int msId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Maintenances.Where(m => m.MaintenanceStatusId == msId).ToList();
            }
        }

        public ICollection<Maintenance> GetByTenantId(string tenantId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Maintenances.Where(m => m.TenantId == tenantId).ToList();
            }
        }

        public Maintenance Update(Maintenance updatedMaintenance)
        {
            using (var context = new CozyDbContext())
            {
                var existingMaitenance = GetById(updatedMaintenance.Id);
                context.Entry(existingMaitenance).CurrentValues.SetValues(updatedMaintenance);
                context.SaveChanges();

                return existingMaitenance;
            }
        }
    }
}
