using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Develhope.DataAccess.Interfaces;
using Develhope.Models;
using Develhope.Shared;
using Microsoft.Extensions.Options;

namespace Develhope.DataAccess
{
    public class JobRepository : IRepository<Job>
    {
        private static readonly string _PROJECT_DATA_PATH = Constants.DATA_PATH + "jobs.json";

        public async Task CreateAsync(Job item)
        {
            var json = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var jobs = JsonSerializer.Deserialize<List<Job>>(json, options);

            jobs.Add(item);

            var jsonJobs= JsonSerializer.Serialize(jobs, options);

            await File.WriteAllTextAsync(_PROJECT_DATA_PATH, jsonJobs);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var json = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var jobs = JsonSerializer.Deserialize<List<Job>>(json, options);
            var jobsToUpdate = jobs.Where(jobs => jobs.Id == id).First();

            jobs.Remove(jobsToUpdate);

            var jsonJobs = JsonSerializer.Serialize(jobs, options);

            await File.WriteAllTextAsync(_PROJECT_DATA_PATH, jsonJobs);
        }

        public async Task<List<Job>> GetAllAsync()
        {
            var json = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var jobs = JsonSerializer.Deserialize<List<Job>>(json, options);
            return jobs;

        }

        public async Task<Job> GetByIdAsync(int id)
        {
            var json = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var jobs = JsonSerializer
                .Deserialize<List<Job>>(json, options)
                .Where(item => item.Id == id).First();
            return jobs;
        }

        public async Task UpdateAsync(Job item)
        {
            var json = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var jobs = JsonSerializer.Deserialize<List<Job>>(json, options);
            var jobsToUpdate = jobs.Where(jobs => jobs.Id == item.Id).First();

            jobsToUpdate.Title = item.Title;
            jobsToUpdate.ProjectId = item.ProjectId;

            var jsonJobs= JsonSerializer.Serialize(jobs, options);

            await File.WriteAllTextAsync(_PROJECT_DATA_PATH, jsonJobs);
        }
    }
}