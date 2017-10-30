using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Task.DAL.Models;

namespace CRUD_Task.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Project> ProjectRepository { get; }
    }
}
