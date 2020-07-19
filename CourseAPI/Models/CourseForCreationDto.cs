
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Models
{
    public class CourseForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
