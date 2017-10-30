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
    public class ProjectService : IProjectService
    {
        IUnitOfWork Database { get; set; }

        public ProjectService(IUnitOfWork database)
        {
            Database = database;
        }


        public async Task<ProjectDTO> GetProject(int? id)
        {
            if (id == null)
                throw new ValidationException("Project id not set", "");
            var project = await Database.ProjectRepository.GetByIdAsync(id.Value);
            if (project == null)
                throw new ValidationException("Project not found", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectDTO>());
            return Mapper.Map<Project, ProjectDTO>(project);
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjects()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectDTO>());
            return Mapper.Map<IEnumerable<Project>, List<ProjectDTO>>(await Database.ProjectRepository.GetAllAsync());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
