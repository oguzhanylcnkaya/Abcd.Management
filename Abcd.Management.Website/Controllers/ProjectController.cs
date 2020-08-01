using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Helper;
using DataAccess.Data;
using Entities.Enums;
using Entities.Helper;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Abcd.Management.Website.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "User")]
    public class ProjectController : Controller
    {
        private IProjectRepository _projectRepository;
        private  ApplicationDbContext _dbContext;
        private IHostingEnvironment _hostingEnvironment;
        private IMapper _mapper;

        public ProjectController(IProjectRepository projectRepository,
                                 ApplicationDbContext dbContext,
                                 IHostingEnvironment hostingEnvironment,
                                 IMapper mapper)
        {
            _projectRepository = projectRepository;
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
            
        }
        public IActionResult ListProjects()
        {
            var allProjects = _projectRepository.GetAllProjects().ToList();
            ProjectListVM m = new ProjectListVM()
            {
                projects = _mapper.Map<List<Project>, List<ProjectVM>>(allProjects)
            };
            //var model = _projectRepository.GetAllProjects();
            return View(m);
        }

        [HttpGet]
        public IActionResult CreateProjects()
        {
            CategoryManager categoryManager = new CategoryManager();
            ProjectCreateVM model = new ProjectCreateVM()
            {
                UserFullName = _dbContext.Users.Select(x => new MySelectListItem<string,string>
                {
                    Label = (x.FirstName + " " + x.LastName),
                    Id = x.Id
                }).ToList(),
                Categories= CategoryManager.Categories
            };
            return View(model);
        }
        
        [HttpPost]
        public IActionResult CreateProjects(ProjectCreateIM model)
        {
            if (ModelState.IsValid)
            {
                string filePath = FileManagement.AddFile(model.Icon, _hostingEnvironment,"Project");

                //Project newProject = new Project
                //{
                //    ProjectName = model.ProjectName,
                //    Description = model.Description,
                //    Categories = model.Categories,
                //    Progress = model.Progress,
                //    IconPath = uniqueFileName,
                //    FullName = model.FullName

                //};
                Project newProject = _mapper.Map<ProjectCreateIM, Project>(model);
                newProject.IconPath = filePath;
                _projectRepository.Add(newProject);
                return RedirectToAction("ListProjects", "Project");
            }
            return RedirectToAction("CreateProjects");
        }

        
        

        

    }
}