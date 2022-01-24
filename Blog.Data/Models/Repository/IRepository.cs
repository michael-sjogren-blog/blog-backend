using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Data.Models.Repository
{
    public interface IRepository<TEntity , TKey> where TEntity :class
    {
        public Task<TEntity> GetOne(TKey id);
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<bool> DeleteOne(TKey id);
        public Task<TEntity> UpdateOne(TEntity entity , TKey id);
        public Task<TEntity> Create(TEntity entity);

        public Task SaveChanges();
    }
}