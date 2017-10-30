using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Task.BLL.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<UserDTO> Users { get; set; }
    }
}
