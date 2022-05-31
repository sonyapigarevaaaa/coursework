using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models {

    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int DeliveryId { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }
        public Product Product { get; set; }
    }
}
