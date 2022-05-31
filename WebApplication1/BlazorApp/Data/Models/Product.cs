namespace BlazorApp.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Fullname { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Store { get; set; }
        public IEnumerable<Shipment> Shipments { get; set; }
        public IEnumerable<Delivery> Deliveries { get; set; }
        public string SrcPicture { get; set; }
    }
}
