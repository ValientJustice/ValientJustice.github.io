namespace TrueNetFinalProject.Models
{
    public class OrderItem
    {
        public int orderItemId {  get; set; }
        public int quantity { get; set; }
        public virtual Product product { get; set; }
        public int productId { get; set; }
        public int orderId { get; set; }
        public virtual Order order{  get; set; }
    }
}
