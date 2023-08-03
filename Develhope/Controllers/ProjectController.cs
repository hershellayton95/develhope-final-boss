using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Develhope.BusinessLogic.Interfaces;
using Develhope.Models;
using Develhope.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Develhope.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<List<ProjectListDto>> GetAllAsync()
        {
            return await _projectService.GetAllAsync();
        }

        [HttpGet]
        [Route("Ongoing")]
        public async Task<List<ProjectListDto>> GetOnGoing()
        {
            return (await _projectService.GetAllAsync())
                .Where(project => DateTime
                .Compare(project.DeliveryDate, DateTime.Now) > 0 )
                .ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ProjectListDto> GetByIdAsync(int id)
        {
            return (await _projectService
                .GetAllAsync())
                .Where(project => project.Id == id).First();
        }

        [HttpPost]
        public async Task CretateAsync([FromBody] Project project)
        {
            await _projectService.CreateAsync(project);
        }

        [HttpPut]
        public  async Task UpdateAsync([FromBody] Project project)
        {
            await _projectService.UpdateAsync(project);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _projectService.DeleteByIdAsync(id);
        }
    }
}