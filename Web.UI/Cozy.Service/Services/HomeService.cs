using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Service.Services
{
    public interface IHomeService
    {
        Home GetById(int homeId);
        ICollection<Home> GetByLandlordId(string landlordId);
        Home Create(Home newHome);
        Home Update(Home updatedHome);
        bool DeleteById(int homeId);

    }

    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository) =>
            _homeRepository = homeRepository;


        public Home Create(Home newHome) =>
            _homeRepository.Create(newHome);

        public bool DeleteById(int homeId) =>
            _homeRepository.DeleteById(homeId);
        

        public Home GetById(int homeId) =>
            _homeRepository.GetById(homeId);

        public ICollection<Home> GetByLandlordId(string landlordId) =>
            _homeRepository.GetByLandlordId(landlordId);

        public Home Update(Home updatedHome) =>
            _homeRepository.Update(updatedHome);
    }
}
