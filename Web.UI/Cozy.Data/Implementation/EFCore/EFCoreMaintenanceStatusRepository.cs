using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreMaintenanceStatusRepository : IMaintenanceStatusRepository
    {
        public ICollection<MaintenanceStatus> GetAll()
        {
            using (var context = new CozyDbContext())
            {
                var allMs = context.MaintenanceStatuses.ToList();

                return allMs;
            }
               
        }

        public MaintenanceStatus GetById(int maintenanceStatusId)
        {
            using (var context = new CozyDbContext())
            {
                return context.MaintenanceStatuses.Single(ms => ms.Id == maintenanceStatusId);
            }
        }
    }
}
