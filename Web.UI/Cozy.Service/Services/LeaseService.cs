using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Service.Services
{
    public interface ILeaseService
    {
        Lease Create(Lease newLease);
        Lease GetById(int leaseId);
        ICollection<Lease> GetByTenantId(string tenantId);
        ICollection<Lease> GetByHomeId(int homeId);
        Lease Update(Lease updatedLease);
        bool DeleteById(int leaseId);
    }
    public class LeaseService : ILeaseService
    {
        private readonly ILeaseRepository _leaseRepository;

        public LeaseService(ILeaseRepository leaseRepository) =>
            _leaseRepository = leaseRepository;

        public Lease Create(Lease newLease) =>
            _leaseRepository.Create(newLease);


        public bool DeleteById(int leaseId) =>
            _leaseRepository.DeleteById(leaseId);

        public ICollection<Lease> GetByHomeId(int homeId) =>
            _leaseRepository.GetByHomeId(homeId);

        public Lease GetById(int leaseId) =>
            _leaseRepository.GetById(leaseId);

        public ICollection<Lease> GetByTenantId(string tenantId) =>
            _leaseRepository.GetByTenantId(tenantId);

        public Lease Update(Lease updatedLease) =>
            _leaseRepository.Update(updatedLease);

    }
}
