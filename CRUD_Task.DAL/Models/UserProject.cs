using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Task.DAL.Interfaces;

namespace CRUD_Task.DAL.Models
{
    public class UserProject : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
