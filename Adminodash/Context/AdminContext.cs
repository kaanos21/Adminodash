using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Adminodash.Entities;
using System.Data.Entity;
using Adminodash.Context;

namespace Adminodash.Context
{
    public class AdminContext :DbContext
    {
        public AdminContext() : base("name=Context")
        {

        }
        public DbSet<Admin> admins { get; set; }
        public DbSet<PageVisit> pageVisits { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<ProjectCategory> projectCategories { get; set; }
        public DbSet<ProjectStatus> projectStatuses { get; set; }
        public DbSet<StatusWorker> statusWorkers { get; set; }
        public DbSet<Workers> workers { get; set; }
    }
}