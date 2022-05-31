using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models {
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int ProductId { get; set; }
        public string Fullname { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Store { get; set; }
        public IEnumerable<Shipment> Shipments { get; set; }
        public IEnumerable<Delivery> Deliveries{ get; set; }
        public string SrcPicture { get; set; }

    }
}
