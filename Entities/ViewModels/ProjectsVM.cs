
using System.Collections.Generic;
using Entities.Enums;

namespace Entities.ViewModels
{
    

    public class ProjectVM
    {
        public int ProjectId { get; set; }
        public string IconPath { get; set; }
        public string ProjectName { get; set; }
        public int? Category { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public List<string> Users { get; set; }
    }
    public class ProjectListVM
    {
        public List<ProjectVM> projects { get; set; }
    }

    
}
