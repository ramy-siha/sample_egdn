using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policy.Framework.Data.Entities
{
    [Table("Service", Schema = "dbo")]
    public class ServiceEntity
    {
        [Key] public int ServiceId { get; set; }
        public string Name { get; set; }
        
       public double Price { get; set; }

       public decimal Period { get; set; }
    }
}
