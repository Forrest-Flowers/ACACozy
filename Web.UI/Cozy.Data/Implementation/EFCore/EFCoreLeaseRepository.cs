using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    class EFCoreLeaseRepository : ILeaseRepository
    {
        public Lease Create(Lease newLease)
        {
            using (var context = new CozyDbContext())
            {
                context.Leases.Add(newLease);
                context.SaveChanges();

                return newLease;
            }
        }

        public bool DeleteById(int leaseId)
        {
            using (var context = new CozyDbContext())
            {
                var lease = GetById(leaseId);
                context.Remove(lease);
                context.SaveChanges();

                if (GetById(leaseId) == null)
                {
                    return true;
                }
                return false;
            }
        }

        public ICollection<Lease> GetByHomeId(int homeId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Leases.Where(l => l.HomeId == homeId).ToList();
            }
        }

        public Lease GetById(int leaseId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Leases.Single(l => l.Id == leaseId);
            }
        }

        public ICollection<Lease> GetByTenantId(string tenantId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Leases.Where(l => l.TenantId == tenantId).ToList();
            }
        }

        public Lease Update(Lease updatedLease)
        {
            using (var context = new CozyDbContext())
            {
                var existingLease = GetById(updatedLease.Id);
                context.Entry(existingLease).CurrentValues.SetValues(updatedLease);
                context.SaveChanges();

                return existingLease;
            }
        }
    }
}
