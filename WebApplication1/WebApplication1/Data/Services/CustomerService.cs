using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Data.Services {
    public class CustomerService
    {
        private EducationContext _context;
        public CustomerService(EducationContext context)
        {
            _context = context;
        }
        public async Task<CustomerDTO?> AddCustomer(CustomerDTO customerDTO)
        {
            Customer customer = new Customer
            {
                CustomerName = customerDTO.CustomerName,
                Shipments = new List<Shipment>()
            };
            var result = _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            var customerDTO1 = new CustomerDTO
            {
                CustomerId = result.Entity.CustomerId,
                CustomerName = result.Entity.CustomerName,
                ShipmentsIds = customerDTO.ShipmentsIds
            };
            return await Task.FromResult(customerDTO);
        }

        public async Task<CustomerDTO> GetCustomer(int id)
        {
            var customer = await _context.Customers.Include(customer => customer.Shipments).FirstOrDefaultAsync(customer => customer.CustomerId == id);
            if (customer == null)
                return null;
            var customerDTO = new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                ShipmentsIds = customer.Shipments.Select(b => b.ShipmentId).ToArray()
            };

            return await Task.FromResult(customerDTO);
        }

        public async Task<List<CustomerDTO>> GetCustomers()
        {
            var customer = await _context.Customers.Include(a => a.Shipments).Select(customer => new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                ShipmentsIds = customer.Shipments.Select(b =>b. ShipmentId).ToArray()
            }).ToListAsync();
            return await Task.FromResult(customer);
        }

        public async Task<CustomerDTO?> UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            var customer = await _context.Customers.Include(a => a.Shipments).FirstOrDefaultAsync(au => au.CustomerId == id);
            if (customer != null)
            {
                customer.CustomerName = customerDTO.CustomerName;
                _context.Update(customer);
                _context.Entry(customer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                var customerDTO1 = new CustomerDTO
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    ShipmentsIds = customer.Shipments.Select(b => b.ShipmentId).ToArray()
                };
                return await Task.FromResult(customerDTO1);
            }
            return null;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(au => au.CustomerId == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }

}
