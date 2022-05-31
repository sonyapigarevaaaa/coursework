namespace BlazorApp.Data.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
