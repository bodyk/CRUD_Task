using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Task.DAL.Interfaces
{
    public interface IRepositoryFactory
    {
        IGenericRepository<T> CreateRepository<T>(DbContext context) where T : class, IEntity;
    }
}
