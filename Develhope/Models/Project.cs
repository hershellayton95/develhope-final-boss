using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Develhope.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}