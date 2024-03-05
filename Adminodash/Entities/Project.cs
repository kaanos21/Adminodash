using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adminodash.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int ProjectCategoryId { get; set; }
        public int ProjectStatusId { get; set; }
        public int ProjectProgress { get; set; }
        public virtual ProjectCategory projectcategory { get; set; }
        public virtual ProjectStatus projectstatus { get; set; }

    }
}