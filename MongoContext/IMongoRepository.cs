using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MongoContext
{
    public interface IMongoRepository<TEntity>
    {
        Task<int> AddAsync(TEntity domainEntity, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(TEntity domainEntity, CancellationToken cancellationToken);
        Task<TEntity> GetAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    }
}