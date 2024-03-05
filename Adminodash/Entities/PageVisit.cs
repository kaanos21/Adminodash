using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adminodash.Entities
{
    public class PageVisit
    {
        [Key]
        public int PageId { get; set; }
        public string PageName { get; set; }
        public int PageViews { get; set; }
        public int PageValue { get; set; }
        public double BounceRate { get; set; }
        public bool PageStatus { get; set; }
    }
}