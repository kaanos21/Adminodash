using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adminodash.Entities
{
    public class StatusWorker
    {
        [Key]
        public int StatusWorkerId { get; set; }
        public string StatusActivity { get; set; }

        public List<Workers> workers { get; set; }
    }
}