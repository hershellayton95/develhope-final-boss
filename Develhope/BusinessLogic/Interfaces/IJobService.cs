using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Develhope.Models;
using Develhope.Models.DTOs;

namespace Develhope.BusinessLogic.Interfaces
{
    public interface IJobService
    {
        Task<List<JobListDto>> GetAllAsync();
        Task CreateAsync(Job job);
        Task UpdateAsync(Job job);
        Task DeleteByIdAsync(int id);
    }
}