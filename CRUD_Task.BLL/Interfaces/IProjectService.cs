using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRUD_Task.BLL.DTO;

namespace CRUD_Task.BLL.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDTO> GetProject(int? id);
        Task<IEnumerable<ProjectDTO>> GetProjects();
        void Dispose();
    }
}
