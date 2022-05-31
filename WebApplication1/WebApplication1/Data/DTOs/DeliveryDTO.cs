using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.DTOs
{

    public class DeliveryDTO
    {
     
        public int DeliveryId { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }
        public int ProductId { get; set; }
    }
}
