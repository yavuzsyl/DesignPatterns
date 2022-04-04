using Microsoft.EntityFrameworkCore;
using WebApp.Strategy.Models;

namespace WebApp.Strategy.Repositories
{
    public class ProductRepositoryFromSqlServer : IProductRepository
    {
        private readonly AppIdentiyDbContext _context;

        public ProductRepositoryFromSqlServer(AppIdentiyDbContext appIdentiyDbContext)
        {
            this._context = appIdentiyDbContext;
        }

        public async Task Delete(Product product)
        {
            //ikiside memoryde entitynin state'ini deleted olarak setler bu yüzden dolayı asenkron bir işlem yok
            //_context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.Remove(product);
            _context.SaveChanges();
        }

        public async Task<List<Product>> GetAllByUserId(string id)
        {
            return await _context.Products.Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<Product> GetById(string id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> Save(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Update(Product product)
        {
           _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
