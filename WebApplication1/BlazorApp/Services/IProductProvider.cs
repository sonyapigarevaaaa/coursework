﻿using BlazorApp.Data.Models;

namespace BlazorApp.Services;

public interface IProductProvider
{
    Task<List<Product>> GetAll();
    Task<Product> GetOne(int id);
    Task<bool> Add(Product item);
    Task<Product> Edit(Product item);
    Task<bool> Remove(int id);
}
