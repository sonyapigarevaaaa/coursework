using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models {
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<Shipment> Shipments { get; set; }
    }
}


