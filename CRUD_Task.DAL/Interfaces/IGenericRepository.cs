using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Task.DAL.Interfaces
{
    public interface IRepository
    { }
    public interface IGenericRepository<T> : IRepository
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> GetByIdDeletedAsync(long id);
        Task<T> Create(T item);
        Task Update(T item);
        Task Delete(long id);
    }
}
