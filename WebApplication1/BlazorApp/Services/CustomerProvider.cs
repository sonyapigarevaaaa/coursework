using System.Net.Http.Json;
using Newtonsoft.Json;
using BlazorApp.Data.Models;



namespace BlazorApp.Services;

public class CustomerProvider : ICustomerProvider
{
    private HttpClient _httpClient;
    public CustomerProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Customer>> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<List<Customer>>("/api/Customer");
    }

    public async Task<Customer> GetOne(int id)
    {
        return await _httpClient.GetFromJsonAsync<Customer>($"/api/Customer/{id}");
    }

    public async Task<bool> Add(Customer item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _httpClient.PostAsync($"/api/Customer", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Customer> Edit(Customer item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _httpClient.PutAsync($"/api/Customer", httpContent);
        Customer customer = JsonConvert.DeserializeObject<Customer>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(customer);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _httpClient.DeleteAsync($"/api/Customer/${id}");
        return await Task.FromResult(delete.IsSuccessStatusCode);
    }
}