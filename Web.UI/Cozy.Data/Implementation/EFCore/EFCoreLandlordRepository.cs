using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreLandlordRepository : ILandlordRepository
    {
        public Landlord Create(Landlord newLandlord)
        {
            using (var context = new CozyDbContext())
            {
                context.Landlords.Add(newLandlord);
                context.SaveChanges();

                return newLandlord;
            }
        }

        public bool DeleteById(string landlordId)
        {
            using (var context = new CozyDbContext())
            {
                var landlord = GetById(landlordId);
                context.Remove(landlord);
                context.SaveChanges();

                if(GetById(landlordId) == null)
                {
                    return true;
                }
                return false;
            }
        }

        public Landlord GetById(string landlordId)
        {
            using (var context = new CozyDbContext())
            {
                return context.Landlords.Single(l => l.Id == landlordId);
            }
        }

        public Landlord Update(Landlord updatedLandlord)
        {
            using (var context = new CozyDbContext())
            {
                var existingLandlord = GetById(updatedLandlord.Id);
                context.Entry(existingLandlord).CurrentValues.SetValues(updatedLandlord);
                context.SaveChanges();

                return existingLandlord;
            }
        }
    }
}
