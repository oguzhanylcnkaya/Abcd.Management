
using Entities.Helper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Entities.ViewModels
{
    public class ProjectCreateVM
    {
        public ProjectCreateVM()
        {
            UserFullName = new List<MySelectListItem<string, string>>();
        }
        public List<MySelectListItem<string, string>> UserFullName { get; set; }
        public Dictionary<int, string> Categories { get; set; }
    }
    public class ProjectCreateIM: ProjectVM
    {
        public IFormFile Icon { get; set; }
        
    }
}
