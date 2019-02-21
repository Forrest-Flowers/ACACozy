using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Domain.Models
{
    public class AppUser : IdentityUser
    {
        //No Distinction between Landlord and Tenant
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public double Income { get; set; }

        //Navigation Properties
        public ICollection<Home> Homes { get; set; } //Landlord Only.
        public ICollection<Lease> Leases { get; set; }//Tenant Only.
        public ICollection<Maintenance> Maintenances { get; set; }//Tenant Only.

    }
}
