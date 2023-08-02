using System;
using System.Collections.Generic;
using System.Linq;
using Develhope.DataAccess.Interfaces;
using Develhope.Models;
using Develhope.Shared;

namespace Develhope.DataAccess
{
    public class ProjectRepository : IRepository<Project>
    {
        private static readonly string _PROJECT_DATA_PATH = Constants.DATA_PATH + "projects.json";

        public Task CreateAsync(Project item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Project item)
        {
            throw new NotImplementedException();
        }
    }
}