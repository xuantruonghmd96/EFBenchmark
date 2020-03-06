using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models_Lib.Models
{
    public class Log
    {
        public string RequestContentBody { get; set; }
        public string RequestURL { get; set; }
        public string RequestMethod { get; set; }
        public string Cookies { get; set; }
        public int ResponseStatusCode { get; set; }
        public string ResponseContentBody { get; set; }
        public string ShortSummary { get; set; }
        public string LongSummary { get; set; }
        public string BranchId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
    }
}
