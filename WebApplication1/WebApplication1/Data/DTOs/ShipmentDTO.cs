using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public class ShipmentDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int ShipmentId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
