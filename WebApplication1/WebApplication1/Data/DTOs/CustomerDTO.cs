using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.DTOs
{
    public class CustomerDTO
    {
       
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int[] ShipmentsIds { get; set; }
    }
}


