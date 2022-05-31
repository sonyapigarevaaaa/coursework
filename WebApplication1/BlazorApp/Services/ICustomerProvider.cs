using BlazorApp.Data.Models;

namespace BlazorApp.Services;

public interface ICustomerProvider
{
    Task<List<Customer>> GetAll();
    Task<Customer> GetOne(int id);
    Task<bool> Add(Customer item);
    Task<Customer> Edit(Customer item);
    Task<bool> Remove(int id);
}
