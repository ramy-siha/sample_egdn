using System;
using System.Collections.Generic;

namespace Policy.Framework.Domain
{
    public class Policy
    {
        public DateTime StartDate { get; set; }

        public DateTime EndtDate { get; set; }
        public Vehicle Vehicle { get; set; }

        public int VehicleId { get; set; }

        public double Amount { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
