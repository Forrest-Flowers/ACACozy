using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    public interface IHomeRepository
    {
        // CRUD Homes

        //Create
        Home Create(Home newHome);

        //Read
        Home GetById(int homeId);
        ICollection<Home> GetByLandlordId(string landlordId);

        //Update
        Home Update(Home updatedHome);

        //Delete
        bool DeleteById(int homeId);
        
    }
}
