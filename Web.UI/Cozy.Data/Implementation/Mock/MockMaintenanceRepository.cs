using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    public class MockMaintenanceRepository : IMaintenanceStatusRepository
    {
        private List<Maintenance> Maintenances = new List<Maintenance>();

        public Maintenance Create(Maintenance newMaintenance)
        {
            newMaintenance.Id = Maintenances.OrderByDescending(m => m.Id).Single().Id + 1;
            Maintenances.Add(newMaintenance);

            return newMaintenance;
        }

        public bool DeleteById(int maintenanceId)
        {
            var maintenance = GetById(maintenanceId);
            Maintenances.Remove(maintenance);

            return true;
        }

        public ICollection<MaintenanceStatus> GetAll()
        {
            var maintenanceStatusAll = Maintenances.Select(m => m.MaintenanceStatusId).ToList();
            return maintenanceStatusAll as ICollection<MaintenanceStatus>;
        }

        public ICollection<Maintenance> GetByHomeId(int homeId)
        {
            return Maintenances.FindAll(m => m.HomeId == homeId);
        }

        public Maintenance GetById(int maintenanceId)
        {
            return Maintenances.Single(m => m.Id == maintenanceId);
        }

        public ICollection<Maintenance> GetByMaintenanceStatusId(int msId)
        {
            return Maintenances.FindAll(m => m.MaintenanceStatusId == msId);
        }

        public ICollection<Maintenance> GetByTenantId(string tenantId)
        {
            return Maintenances.FindAll(m => m.TenantId == tenantId);
        }

        public Maintenance Update(Maintenance updatedMaintenance)
        {
            DeleteById(updatedMaintenance.Id);
            Maintenances.Add(updatedMaintenance);

            return updatedMaintenance;
        }

        MaintenanceStatus IMaintenanceStatusRepository.GetById(int msId)
        {
            //TODO
            throw new NotImplementedException();
        }

    }
}
