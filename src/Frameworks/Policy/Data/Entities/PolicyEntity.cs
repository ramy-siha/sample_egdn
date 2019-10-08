using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policy.Framework.Data.Entities
{
    [Table("Policy")]
    public class PolicyEntity
    {
        [Key] public int PolicyId { get; set; }

        [ForeignKey("Vehicle")] public int VehicleId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndtDate { get; set; }
        public VehicleEntity Vehicle { get; set; }

        public double Amount { get; set; }

    }
}
