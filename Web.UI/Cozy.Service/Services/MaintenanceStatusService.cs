using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Service.Services
{
    public interface IMaintenanceStatusService
    {
        MaintenanceStatus GetById(int maintenanceStatusId);
        ICollection<MaintenanceStatus> GetAll();
    }
    class MaintenanceStatusService : IMaintenanceStatusService
    {
        private readonly IMaintenanceStatusRepository _maintenanceStatusRepository;

        public MaintenanceStatusService(IMaintenanceStatusRepository maintenanceStatusRepository) =>
            _maintenanceStatusRepository = maintenanceStatusRepository;

        public ICollection<MaintenanceStatus> GetAll() =>
            _maintenanceStatusRepository.GetAll();

        public MaintenanceStatus GetById(int maintenanceStatusId) =>
            _maintenanceStatusRepository.GetById(maintenanceStatusId);

    }
}
