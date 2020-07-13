using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoContext;

namespace Product.Domain.Interfaces
{
    public interface IProductRepository : IMongoRepository<ProductEntity>
    {
        Task<bool> UpdateQuantityAsync(IEnumerable<ProductEntity> products, CancellationToken cancellationToken);
    }
}