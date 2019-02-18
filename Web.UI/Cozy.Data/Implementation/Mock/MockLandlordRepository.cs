using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cozy.Data.Implementation.Mock
{
    public class MockLandlordRepository : ILandlordRepository
    {
        private List<Landlord> Landlords = new List<Landlord>();

        public Landlord Create(Landlord newLandlord)
        {
            newLandlord.Id = Landlords.OrderByDescending(ll => ll.Id).Single().Id + 1;
            Landlords.Add(newLandlord);

            return newLandlord;
        }

        public bool DeleteById(string landlordId)
        {
            var landlord = GetById(landlordId);
            Landlords.Remove(landlord);

            return true;
        }

        public Landlord GetById(string landlordId)
        {
            return Landlords.Single(ll => ll.Id == landlordId);
        }

        public Landlord Update(Landlord updatedLandlord)
        {
            DeleteById(updatedLandlord.Id);
            Landlords.Add(updatedLandlord);

            return updatedLandlord;
        }
    }
}
