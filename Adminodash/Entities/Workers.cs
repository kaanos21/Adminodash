using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adminodash.Entities
{
    public class Workers
    {
        [Key]
        public int WorkerId { get; set; }
        public string WorkerNameSurname { get; set; }
        public string StatusWorkerId { get; set; }
        public string WorkerSalary { get; set; }
        public string WorkerDescription { get; set; }

        public string Image { get; set; }

        public virtual StatusWorker statusworker { get; set; }
    }
}