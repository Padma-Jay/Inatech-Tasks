using System.ComponentModel.DataAnnotations.Schema;

namespace WingTruck.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        
        
        public string? FromAddr { get; set; }
        public string? ToAddr { get; set; }
        public string? City { get; set; }
        public int Weight { get; set; }

        [ForeignKey("Order")]
        public int OrderTypeId { get; set; }
        public Order? Order { get; set; }
        public float Price { get; set; }    

    }
}
