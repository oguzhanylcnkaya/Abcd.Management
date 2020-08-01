using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Project
    {
        public Project()
        {
            Users = new List<ProjectUser>();
        }
        public int ProjectId { get; set; }
        public string IconPath { get; set; }
        public string ProjectName { get; set; }
        public int? Category { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public List<ProjectUser> Users { get; set; }
    }
}
