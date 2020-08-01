using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects();

        Project Add(Project project);
        //Project Update(Project projectChanges);
        //Project Delete(int Id);
    }
}
