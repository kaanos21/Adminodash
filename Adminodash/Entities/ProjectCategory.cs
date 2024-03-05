using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adminodash.Entities
{
    public class ProjectCategory
    {
        [Key]
        public int ProjectCategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Project> projects { get; set; }
    }
}