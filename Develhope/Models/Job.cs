using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Develhope.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Title { get; set; }
    }
}