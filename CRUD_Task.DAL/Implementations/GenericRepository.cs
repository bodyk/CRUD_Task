using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Task.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Task.DAL.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public T GetById(long id)
        {
            return Entities.First(x => x.Id == id);
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await Entities.SingleOrDefaultAsync(i => i.Id == id);

        }

        public async Task<T> GetByIdDeletedAsync(long id)
        {
            return await Entities.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<T> Create(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                var res = Entities.Add(entity);
                await _context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                var entity = GetById(id);
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(id));
                }

                Entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        protected DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
