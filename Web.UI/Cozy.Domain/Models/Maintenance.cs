using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Domain.Models
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }

        public int HomeId { get; set; }
        public string TenantId { get; set; }
    }
}
