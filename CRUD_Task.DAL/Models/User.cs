using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Task.DAL.Interfaces;

namespace CRUD_Task.DAL.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<UserProject> UserProjects { get; set; }
    }
}
