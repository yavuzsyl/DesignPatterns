using Microsoft.Extensions.Caching.Memory;
using WebApp.Decorator.Models;

namespace WebApp.Decorator.Repositories.Decorators
{
    public class ProductRepositoryCacheDecorator : BaseProductRepositoryDecorator
    {
        private readonly IMemoryCache _cache;
        private const string CACHE_KEY = "products";
        public ProductRepositoryCacheDecorator(
            IProductRepository productRepository,
            IMemoryCache cache) : base(productRepository)
        {
            _cache = cache;
        }

        public override async Task<List<Product>> GetAll()
        {
            if (_cache.TryGetValue(CACHE_KEY, out List<Product> products))
                return await Task.FromResult(products);

            await UpdateCache();
            return _cache.Get<List<Product>>(CACHE_KEY);
        }

        public override async Task<List<Product>> GetAll(string userId)
        {
            return (await GetAll()).Where(p => p.UserId == userId).ToList();
        }

        public override async Task Save(Product product)
        {
            await base.Save(product);
            await UpdateCache();
        }
        public override async Task Update(Product product)
        {
            await base.Update(product);
            await UpdateCache();
        }

        public override async Task Remove(Product product)
        {
            await base.Remove(product);
            await UpdateCache();
        }

        public async Task UpdateCache()
        {
            _cache.Set(CACHE_KEY, await base.GetAll());
        }

    }
}
