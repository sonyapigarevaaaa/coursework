using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Fullname { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Store { get; set; }
        public int[] ShipmentsIds { get; set; }
        public int[] DeliveriesIds { get; set; }
        public string SrcPicture { get; set; }

    }
}
