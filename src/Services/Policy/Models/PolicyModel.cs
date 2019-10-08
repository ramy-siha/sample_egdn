using System;

namespace Policy.WebApi.Models
{
    public class PolicyModel
    {   
        public DateTime StartDate { get; set; }

        public DateTime EndtDate { get; set; }
        public double Amount { get; set; }

        public int VehicleId { get; set; }
    }
}
