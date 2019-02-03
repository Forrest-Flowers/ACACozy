using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Domain.Models
{
    public class Home
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ImageURL { get; set; }

        //Foreign Key (FK)
        public string LandlordId { get; set; }
        //Navigation Reference.
        public Landlord Landlord { get; set; }
    }
}
