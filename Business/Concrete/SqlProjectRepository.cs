using Business.Abstract;
using DataAccess.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SqlProjectRepository : IProjectRepository
    {
        private ApplicationDbContext _dbContext;

        public SqlProjectRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Project Add(Project project)
        {
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return project;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _dbContext.Projects.Include(x=>x.Users).ThenInclude(x=>x.ApplicationUser);
        }
    }
}
