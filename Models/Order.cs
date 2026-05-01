using System.ComponentModel.DataAnnotations;

namespace TrueNetFinalProject.Models
{
    public class Order
    {
        public int orderId {  get; set; }
        public virtual User customer { get; set; }
        public int customerId { get; set; }
        public virtual List<OrderItem> orderItems { get; set; }
        public string destination { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? RecievedDate { get; set; }
    }
}
