using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreHomeRepository : IHomeRepository
    {
        public Home Create(Home newHome)
        {
            using (var context = new CozyDbContext())
            {
                context.Homes.Add(newHome);
                context.SaveChanges();

                return newHome;// --> Find out if this is enough to get the Id generated in db
            }
        }

        public bool DeleteById(int homeId)
        {
            using (var context = new CozyDbContext())
            {
                var home = GetById(homeId);
                context.Remove(home);
                context.SaveChanges();

                if (GetById(homeId) == null)
                {
                    return true;
                }
                return false; 
            }
        }

        public Home GetById(int homeId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Homes.Single(h => h.Id == homeId);
            }
        }

        public ICollection<Home> GetByLandlordId(string landlordId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Homes.Where(h => h.LandlordId == landlordId).ToList();

                //Where returns IQueryable
                //IQueryable != ICollection
            }
        }

        public Home Update(Home updatedHome)
        {
            using (var context = new CozyDbContext())
            {
                var existingHome = GetById(updatedHome.Id);
                context.Entry(existingHome).CurrentValues.SetValues(updatedHome);
                context.SaveChanges();

                return existingHome;
            }
        }
    }
}
