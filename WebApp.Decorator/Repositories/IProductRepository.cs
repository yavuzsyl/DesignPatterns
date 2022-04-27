using WebApp.Decorator.Models;

namespace WebApp.Decorator.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> GetAll(string userId);
        Task<Product> GetById(int id);
        Task Save(Product product);
        Task Update(Product product);
        Task Remove(Product product);
    }
}
