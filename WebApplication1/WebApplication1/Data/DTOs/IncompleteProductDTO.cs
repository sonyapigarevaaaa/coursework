using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.DTOs
{
    public class IncompleteProductDTO
    {
        public int ProductId { get; set; }
        public string Fullname { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}