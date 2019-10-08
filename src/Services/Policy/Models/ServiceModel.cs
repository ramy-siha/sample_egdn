using System;

namespace Policy.WebApi.Models
{
    public class ServiceModel
    {   
        public string Name { get; set; }
        
       public double Price { get; set; }

       public decimal Period { get; set; } 

        public int ServiceId { get; set; }
    }
}
