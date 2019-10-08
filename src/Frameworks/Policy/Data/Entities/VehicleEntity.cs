﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policy.Framework.Data.Entities
{
    [Table("Vehicle")]
    public class VehicleEntity
    {
        [Key] public int VehicleId { get; set; }
        public string Model { get; set; }
        
        public string VIN { get; set; }

        public string Manufacturer { get; set; }

        public string Make { get; set; }

        public double EngineSize  { get; set; }

        public double HorsePower  { get; set; }

        public double EngineWatts  { get; set; }

        public double PurchaseAmount  { get; set; }

        public string FuelType { get; set; }
    }
}
