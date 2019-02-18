using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Service.Services
{
    public interface IMaintenanceService
    {
        Maintenance Create(Maintenance newMaintenance);
        Maintenance GetByid(int maintenanceId);
        ICollection<Maintenance> GetByHomeId(int homeId);
        ICollection<Maintenance> GetByTenantId(string tenantId);
        ICollection<Maintenance> GetByMaintenanceStatusId(int msId);
        Maintenance Update(Maintenance updatedMaintenance);
        bool DeleteById(int maintenanceId);
    }

    class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public MaintenanceService(IMaintenanceRepository maintenanceRepository) =>
            _maintenanceRepository = maintenanceRepository;

        public Maintenance Create(Maintenance newMaintenance) =>
            _maintenanceRepository.Create(newMaintenance);

        public bool DeleteById(int maintenanceId) =>
            _maintenanceRepository.DeleteById(maintenanceId);

        public ICollection<Maintenance> GetByHomeId(int homeId) =>
            _maintenanceRepository.GetByHomeId(homeId);

        public Maintenance GetByid(int maintenanceId) =>
            _maintenanceRepository.GetById(maintenanceId);

        public ICollection<Maintenance> GetByMaintenanceStatusId(int msId) =>
            _maintenanceRepository.GetByMaintenanceStatusId(msId);

        public ICollection<Maintenance> GetByTenantId(string tenantId) =>
            _maintenanceRepository.GetByTenantId(tenantId);

        public Maintenance Update(Maintenance updatedMaintenance) =>
            _maintenanceRepository.Update(updatedMaintenance);
    }
}
