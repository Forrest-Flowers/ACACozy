using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    public interface ILandlordRepository
    {
        //CRUD Landlord

        //Create
        Landlord Create(Landlord newLandlord);
        //Read
        Landlord GetById(string landlordId);
        //Update
        Landlord Update(Landlord updatedLandlord);
        //Delete
        bool DeleteById(string landlordId);
    }
}
