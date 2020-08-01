using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class ProjectUser
    {
        public int Id { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
