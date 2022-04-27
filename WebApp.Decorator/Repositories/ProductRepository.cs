using Microsoft.EntityFrameworkCore;
using WebApp.Decorator.Models;

namespace WebApp.Decorator.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public AppIdentiyDbContext _dbContext { get; }

        public ProductRepository(AppIdentiyDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Remove(Product product)
        {
            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Product>> GetAll()
        {
            return _dbContext.Products.ToListAsync();
        }

        public Task<List<Product>> GetAll(string userId)
        {
            return _dbContext.Products.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Save(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
