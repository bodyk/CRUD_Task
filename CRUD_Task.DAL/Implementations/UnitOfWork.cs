using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Task.DAL.Interfaces;
using CRUD_Task.DAL.Models;
using AppContext = CRUD_Task.DAL.Models.AppContext;

namespace CRUD_Task.DAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppContext _context;
        private IRepositoryFactory _factory;

        public IGenericRepository<User> userRepository;
        public IGenericRepository<Project> projectRepository;

        public UnitOfWork(AppContext context, IRepositoryFactory factory)
        {
            this._context = context;
            this._factory = factory;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<User> UserRepository => userRepository ??
                                                          (userRepository = _factory.CreateRepository<User>(_context));

        public IGenericRepository<Project> ProjectRepository => projectRepository ??
                                                          (projectRepository = _factory.CreateRepository<Project>(_context));
    }
}
