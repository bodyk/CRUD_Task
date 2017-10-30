using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CRUD_Task.BLL.DTO;
using CRUD_Task.BLL.Infrastructure;
using CRUD_Task.BLL.Interfaces;
using CRUD_Task.DAL.Interfaces;
using CRUD_Task.DAL.Models;

namespace CRUD_Task.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork database)
        {
            Database = database;
        }


        public async Task<UserDTO> GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("User id not set", "");

            var user = await Database.UserRepository.GetByIdAsync(id.Value);
            if (user == null)
                throw new ValidationException("User not found", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectDTO>());
            return Mapper.Map<User, UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectDTO>());
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(await Database.UserRepository.GetAllAsync());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
