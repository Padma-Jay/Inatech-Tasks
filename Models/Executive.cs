using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WingTruck.Models
{
    public class Executive
    {
        [Key]
        public int ExecutiveId { get; set; }
        public string? ExecutiveName { get; set; }
        
        [ForeignKey("Order")]
        public int OrderTypeId { get; set; }
        public Order? Order { get; set; }
        public int PhnNo { get; set; }
    }
}
