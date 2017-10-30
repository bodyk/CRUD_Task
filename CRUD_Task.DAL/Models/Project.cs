using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Task.DAL.Interfaces;

namespace CRUD_Task.DAL.Models
{
    public class Project : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
