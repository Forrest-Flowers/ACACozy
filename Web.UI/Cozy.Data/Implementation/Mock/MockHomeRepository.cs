using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    public class MockHomeRepository : IHomeRepository
    {
        private List<Home> Homes = new List<Home>()
        {
            new Home
            {
                Id = 1,
                ImageURL ="https://cdn.houseplans.com/product/q5qkhirat4bcjrr4rpg9fk3q94/w800x533.jpg?v=8",
                Address = "123 Main Street Mocked",
                City = "Austin",
                State = "TX"
            }
        };

        public Home Create(Home newHome)
        {
            //var homesOrdered = Homes.OrderByDescending(h => h.Id);
            //var firstHome = homesOrdered.First();
            //var newId = firstHome.Id;
            //newHome.Id = newId + 1;

            newHome.Id = Homes.OrderByDescending(h => h.Id).Single().Id + 1;
            Homes.Add(newHome);

            return newHome;
        }

        public bool DeleteById(int homeId)
        {
            var home = GetById(homeId);
            Homes.Remove(home);

            return true;
        }

        public Home GetById(int homeId)
        {
            return Homes.Single(h => h.Id == homeId);
        }

        public ICollection<Home> GetByLandlordId(string landlordId)
        {
            return Homes.FindAll(h => h.LandlordId == landlordId);
        }

        public Home Update(Home updatedHome)
        {
            DeleteById(updatedHome.Id); //Delete the existing home
            Homes.Add(updatedHome);

            return updatedHome;
        }
    }
}
