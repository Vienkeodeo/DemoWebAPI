using DemoWebAPI.DB.Model;

namespace DemoWebAPI.DB.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();

        Task<Product> GetProductAsync(int id);

        Task CreateProduct(Product product);

        Task DeleteProduct(int id);

        Task UpdateProduct(int id, Product product);
    }
}
