using System.ComponentModel.DataAnnotations;

namespace WingTruck.Models
{
    public class Order
    {
        [Key]
        public int OrderTypeId { get; set; }

        public string? OrderType { get; set; }

    }
}
