using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRUD_Task.BLL.DTO;

namespace CRUD_Task.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(int? id);
        Task<IEnumerable<UserDTO>> GetUsers();
        void Dispose();
    }
}
