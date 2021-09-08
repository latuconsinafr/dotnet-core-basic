using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_basic.Data;
using dotnet_basic.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_basic.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext _context;
        public ProductRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            Product productToUpdate = await _context.Products.FindAsync(product.ProductId);
            if (productToUpdate == null)
                throw new NullReferenceException();

            productToUpdate.DateUpdated = DateTime.Now;
            _context.Products.Update(productToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Product productToDelete = await _context.Products.FindAsync(id);
            if (productToDelete == null)
                throw new NullReferenceException();

            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }
    }
}