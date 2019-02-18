using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    public class MockMaintenanceStatusRepository : IMaintenanceStatusRepository
    {
        private List<MaintenanceStatus> MaintenanceStatuses = new List<MaintenanceStatus>();

        public ICollection<MaintenanceStatus> GetAll()
        {
            var maintenanceStatusAll = MaintenanceStatuses.Select(ms => ms.Id).ToList();
            return maintenanceStatusAll as ICollection<MaintenanceStatus>;
        }

        public MaintenanceStatus GetById(int maintenanceStatusId)
        {
            return MaintenanceStatuses.Single(ms => ms.Id == maintenanceStatusId);
        }
    }
}
