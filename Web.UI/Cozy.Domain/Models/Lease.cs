using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Domain.Models
{
    public class Lease
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double RentPrice { get; set; }

        public int HomeId { get; set; }
        public string TenantId { get; set; }
    }
}
