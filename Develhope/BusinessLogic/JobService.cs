using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Develhope.BusinessLogic.Interfaces;
using Develhope.DataAccess.Interfaces;
using Develhope.Models;
using Develhope.Models.DTOs;

namespace Develhope.BusinessLogic
{
    public class JobService : IJobService
    {
        private readonly IRepository<Job> _jobRepository;

        public JobService(IRepository<Job> repository)
        {
            _jobRepository = repository;
        }

        public async Task CreateAsync(Job project)
        {
            await _jobRepository.CreateAsync(project);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _jobRepository.DeleteByIdAsync(id);
        }

        public async Task<List<JobListDto>> GetAllAsync()
        {
            return (await _jobRepository.GetAllAsync())
                .ConvertAll(x => new JobListDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    ProjectId = x.ProjectId,
                });
        }

        public async Task UpdateAsync(Job project)
        {
            await _jobRepository.UpdateAsync(project);
        }
    }
}