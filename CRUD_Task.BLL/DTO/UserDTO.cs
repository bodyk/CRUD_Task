using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Task.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public IEnumerable<ProjectDTO> Projects { get; set; }
    }
}
