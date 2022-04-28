using WebApp.Decorator.Models;

namespace WebApp.Decorator.Repositories.Decorators
{
    public class ProductRepositoryLogDecorator : BaseProductRepositoryDecorator
    {
        private readonly ILogger<ProductRepositoryLogDecorator> logger;
        public ProductRepositoryLogDecorator(
            IProductRepository productRepository, 
            ILogger<ProductRepositoryLogDecorator> logger) : base(productRepository)
        {
            this.logger = logger;
        }

        public override Task<List<Product>> GetAll()
        {
            logger.LogInformation("GetAll");
            return base.GetAll();
        }

        public override Task<List<Product>> GetAll(string userId)
        {
            logger.LogInformation("GetAll userId{0}", userId);
            return base.GetAll(userId);
        }
        //
    }
}
