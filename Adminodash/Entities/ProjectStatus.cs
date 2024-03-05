using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adminodash.Entities
{
    public class ProjectStatus
    {
        [Key]
        public int ProjectStatusId { get; set; }
        public string ProjectStatusName { get; set; }
        
        public List<Project> projects { get; set; }
    }
}