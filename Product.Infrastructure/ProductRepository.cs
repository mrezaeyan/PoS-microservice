using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoContext;
using Product.Domain;
using Product.Domain.Interfaces;

namespace Product.Infrastructure
{
    public class ProductRepository : MongoRepository<ProductEntity>, IProductRepository
    {
        private static IEnumerable<ProductEntity> _productEntities;
        public ProductRepository(MongoDbContext dbContext) : base(dbContext)
        {
            _productEntities = new List<ProductEntity>
            {
                new ProductEntity {Id = 1, Code = "Code1", Name = "Name1", Quantity = 100, UnitPrice = 10000},
                new ProductEntity {Id = 2, Code = "Code2", Name = "Name2", Quantity = 20, UnitPrice = 20000},
                new ProductEntity {Id = 3, Code = "Code3", Name = "Name3", Quantity = 40, UnitPrice = 30000},
                new ProductEntity {Id = 4, Code = "Code4", Name = "Name4", Quantity = 50, UnitPrice = 14000},
                new ProductEntity {Id = 5, Code = "Code5", Name = "Name5", Quantity = 5, UnitPrice = 10040},
                new ProductEntity {Id = 6, Code = "Code6", Name = "Name6", Quantity = 10, UnitPrice = 10300},
                new ProductEntity {Id = 7, Code = "Code7", Name = "Name7", Quantity = 30, UnitPrice = 20000},
                new ProductEntity {Id = 8, Code = "Code8", Name = "Name8", Quantity = 12, UnitPrice = 70000},
                new ProductEntity {Id = 9, Code = "Code9", Name = "Name9", Quantity = 6, UnitPrice = 80000},
                new ProductEntity {Id = 10, Code = "Code10", Name = "Name10", Quantity = 2, UnitPrice = 100000}
            };
        }

        public Task<bool> UpdateQuantityAsync(IEnumerable<ProductEntity> products, CancellationToken cancellationToken)
        {
            foreach (var product in products)
            {
               var cachedProduct = _productEntities.Single(a => a.Id == product.Id);
               cachedProduct.Quantity -= product.Quantity;
            }
            return Task.FromResult(true);

        }
    }
}