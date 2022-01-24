using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Data.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Models.Repository
{
    public class BaseRepository<TEntity , TKey> : IRepository<TEntity , TKey> where TEntity :class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entities;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetOne(TKey id)
        {
            var entity = await _entities.FindAsync(id);
            
            return entity ?? throw new Exception("Not Found");
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<bool> DeleteOne(TKey id)
        {
            var entity = await GetOne(id);
            _entities.Remove(entity);
            await SaveChanges();
            return true;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateOne(TEntity entity , TKey id)
        {
            if ( (await _entities.FindAsync(id)) == null) throw new Exception("Not Found");
            var updatedEntity = _entities.Update(entity).Entity;
            await SaveChanges();
            return updatedEntity;
        }
        
        
        public async Task<TEntity> Create(TEntity entity)
        {
            var newEntry = await _entities.AddAsync(entity);
            await SaveChanges();
            return newEntry.Entity;
        }
    }
}