using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
        {
            Projects = new List<ProjectUser>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        List<ProjectUser> Projects { get; set; }
    }
}
