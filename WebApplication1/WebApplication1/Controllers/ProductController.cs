using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;
using WebApplication1.Data.DTOs;


namespace WebApplication1.Contollers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _context;

        public ProductController(ProductService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            return await _context.GetProducts();
        }

        [HttpGet("/incomplete")]
        public async Task<ActionResult<IEnumerable<IncompleteProductDTO>>> GetProductIncomplete()
        {
            return await _context.GetProductsIncomplete();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _context.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> PutProduct(int id, [FromBody] ProductDTO productDTO)
        {
            var result = await _context.UpdateProduct(id, productDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct([FromBody] ProductDTO productDTO)
        {
            var result = await _context.AddProduct(productDTO);
            if (result == null)
            {
                BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.DeleteProduct(id);
            if (product)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}