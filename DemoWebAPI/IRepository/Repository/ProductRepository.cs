using DemoWebAPI.DB.Model;
using DemoWebAPI.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.DB.IRepository.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateProduct(Product product)
        {
            try
            {
               _context.Products.Add(product);
                await _context.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteProduct(int id)
        {
            try
            {
                var findProduct = await _context.Products.FindAsync(id);
                if (findProduct != null)
                {
                    _context.Products.Remove(findProduct);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateProduct(int id, Product product)
        {
            try
            {
                var findproduct = await _context.Products.FindAsync(id);
                if (findproduct != null)
                {
                    findproduct.Name = product.Name;
                    findproduct.Price = product.Price;
                    findproduct.quantity = product.quantity;

                    await _context.SaveChangesAsync();

                }
                await Task.FromResult(product);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
