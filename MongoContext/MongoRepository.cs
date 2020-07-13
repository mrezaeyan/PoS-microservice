using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MongoContext
{
    public abstract class MongoRepository<TEntity> : IMongoRepository<TEntity>
    {
        protected readonly MongoDbContext DbContext;

        protected MongoRepository(MongoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Task<int> AddAsync(TEntity domainEntity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(IEnumerable<TEntity> domainEntities, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TEntity domainEntity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}