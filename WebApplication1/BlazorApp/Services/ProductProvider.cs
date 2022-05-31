﻿using System.Net.Http.Json;
using Newtonsoft.Json;
using BlazorApp.Data.Models;



namespace BlazorApp.Services;

public class ProductProvider : IProductProvider
{
    private HttpClient _httpClient;
    public ProductProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<List<Product>>("/api/Product");
    }

    public async Task<Product> GetOne(int id)
    {
        return await _httpClient.GetFromJsonAsync<Product>($"/api/Product/{id}");
    }

    public async Task<bool> Add(Product item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _httpClient.PostAsync($"/api/Product", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Product> Edit(Product item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _httpClient.PutAsync($"/api/Product", httpContent);
        Product product= JsonConvert.DeserializeObject<Product>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(product);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _httpClient.DeleteAsync($"/api/Product/${id}");
        return await Task.FromResult(delete.IsSuccessStatusCode);
    }
}