using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Develhope.Models.DTOs
{
    public class ProjectListDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}