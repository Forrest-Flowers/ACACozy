using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Domain.Models
{
    public class Tenant
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Income { get; set; }
        public string PhoneNumber { get; set; }
    }
}
