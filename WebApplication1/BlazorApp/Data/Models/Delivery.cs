namespace BlazorApp.Data.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }
        public int ProductId { get; set; }
    }
}
