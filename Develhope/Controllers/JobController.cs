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
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<List<JobListDto>> GetAllAsync()
        {
            return await _jobService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<JobListDto> GetByIdAsync(int id)
        {
            return (await _jobService
                .GetAllAsync())
                .Where(job => job.Id == id).First();
        }

        [HttpPost]
        public async Task CretateAsync([FromBody] Job job)
        {
            await _jobService.CreateAsync(job);
        }

        [HttpPut]
        public  async Task UpdateAsync([FromBody] Job job)
        {
            await _jobService.UpdateAsync(job);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _jobService.DeleteByIdAsync(id);
        }
    }
}