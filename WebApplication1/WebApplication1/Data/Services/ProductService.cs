using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Data.Services
{
    public class ProductService
    {
        private EducationContext _context;
        public ProductService(EducationContext context)
        {
            _context = context;
        }
        public async Task<ProductDTO?> AddProduct(ProductDTO productDTO)
        {
            Product product = new Product
            {
                Fullname = productDTO.Fullname,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Quantity = productDTO.Quantity,
                Store = productDTO.Store,
                Shipments = new List<Shipment>(),
                Deliveries = new List<Delivery>(),
                SrcPicture = productDTO.SrcPicture,
            };
            var result = _context.Products.Add(product);
            await _context.SaveChangesAsync();
            var productDTO1 = new ProductDTO
            {
                ProductId = result.Entity.ProductId,
                Fullname = result.Entity.Fullname,
                Description = result.Entity.Description,
                Price = result.Entity.Price,
                Quantity = result.Entity.Quantity,
                Store = result.Entity.Store,
                ShipmentsIds = productDTO.ShipmentsIds,
                DeliveriesIds = productDTO.DeliveriesIds,
                SrcPicture = product.SrcPicture
            };
            return await Task.FromResult(productDTO);
        }


        public async Task<ProductDTO?> GetProduct(int id)
        {

            var product = await _context.Products.Include(product => product.Deliveries).Include(product => product.Shipments).FirstOrDefaultAsync(product => product.ProductId == id);
            if (product == null)
                return null;
            var productDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                Fullname = product.Fullname,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Store = product.Store,
                ShipmentsIds = product.Shipments.Select(b => b.ShipmentId).ToArray(),
                DeliveriesIds = product.Deliveries.Select(b => b.DeliveryId).ToArray(),
                SrcPicture = product.SrcPicture,
            };
            return await Task.FromResult(productDTO);
        }


        public async Task<List<ProductDTO>> GetProducts()
        {
            var product = await _context.Products.Include(a => a.Deliveries).Include(b => b.Shipments).Select(product => new ProductDTO
            {
                ProductId = product.ProductId,
                Fullname = product.Fullname,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Store = product.Store,
                ShipmentsIds = product.Shipments.Select(b => b.ShipmentId).ToArray(),
                DeliveriesIds = product.Deliveries.Select(b => b.DeliveryId).ToArray(),
                SrcPicture = product.SrcPicture,
            }).ToListAsync();
            return product;
        }

        public async Task<List<IncompleteProductDTO>> GetProductsIncomplete()
        {
            var products = await _context.Products.ToListAsync();
            List<IncompleteProductDTO> result = new List<IncompleteProductDTO>();
            products.ForEach(au => result.Add(new IncompleteProductDTO { ProductId = au.ProductId, Fullname = au.Fullname, Description = au.Description, Price = au.Price }));
            return await Task.FromResult(result);
        }

        public async Task<ProductDTO?> UpdateProduct(int id, ProductDTO productDTO)
        {
            var product = await _context.Products.Include(a => a.Deliveries).Include(au => au.Shipments).FirstOrDefaultAsync(b => b.ProductId == id);
            if (product != null)
            {
                product.Fullname = productDTO.Fullname;
                product.Description = productDTO.Description;
                product.Price = productDTO.Price;
                product.Quantity = productDTO.Quantity;
                product.Store = productDTO.Store;
                product.SrcPicture = productDTO.SrcPicture;
                _context.Update(product);
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                var productDTO1 = new ProductDTO
                {
                    ProductId = product.ProductId,
                    Fullname = product.Fullname,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Store = product.Store,
                    DeliveriesIds = product.Deliveries.Select(b => b.DeliveryId).ToArray(),
                    ShipmentsIds = product.Shipments.Select(b => b.ShipmentId).ToArray(),
                    SrcPicture = product.SrcPicture
                };
                return await Task.FromResult(productDTO1);
            }
            return null;
        }


        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(au => au.ProductId == id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}