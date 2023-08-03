using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Develhope.BusinessLogic.Interfaces;
using Develhope.DataAccess.Interfaces;
using Develhope.Models;
using Develhope.Shared;
using Microsoft.Extensions.Options;

namespace Develhope.DataAccess
{
    public class ProjectRepository : IRepository<Project>
    {
        private static readonly string _PROJECT_DATA_PATH = Constants.DATA_PATH + "projects.json";

        private readonly IJobService _jobService; 
        public ProjectRepository(IJobService jobService)
        {
             _jobService = jobService;
        }

        public async Task CreateAsync(Project item)
        {
            var json = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var projects = JsonSerializer.Deserialize<List<Project>>(json, options);

            projects.Add(item);

            var jsonProjects = JsonSerializer.Serialize(projects, options);

            await File.WriteAllTextAsync(_PROJECT_DATA_PATH, jsonProjects);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var json = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var projects = JsonSerializer.Deserialize<List<Project>>(json, options);
            var productToUpdate = projects.Where(product => product.Id == id).First();

            await _jobService.DeleteByIdAsync(productToUpdate.Id);
            projects.Remove(productToUpdate);

            var jsonProjects = JsonSerializer.Serialize(projects, options);

            await File.WriteAllTextAsync(_PROJECT_DATA_PATH, jsonProjects);
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var json = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var projects = JsonSerializer.Deserialize<List<Project>>(json, options);
            return projects;

        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var json = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var product = JsonSerializer
                .Deserialize<List<Project>>(json, options)
                .Where(item => item.Id == id).First();
            return product;
        }

        public async Task UpdateAsync(Project item)
        {
            var json = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var projects = JsonSerializer.Deserialize<List<Project>>(json, options);
            var productToUpdate = projects.Where(product => product.Id == item.Id).First();

            productToUpdate.Title = item.Title;
            productToUpdate.Description = item.Description;
            productToUpdate.DeliveryDate = item.DeliveryDate;

            var jsonProjects = JsonSerializer.Serialize(projects, options);

            await File.WriteAllTextAsync(_PROJECT_DATA_PATH, jsonProjects);
        }
    }
}