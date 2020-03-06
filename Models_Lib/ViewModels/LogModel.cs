using Models_Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models_Lib.ViewModels
{
    public class LogModel
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
        public virtual long Id { get; set; }

        public LogModel(Log log)
        {
            this.RequestContentBody = log.RequestContentBody;
            this.RequestURL = log.RequestURL;
            this.RequestMethod = log.RequestMethod;
            this.Cookies = log.Cookies;
            this.ResponseStatusCode = log.ResponseStatusCode;
            this.ResponseContentBody = log.ResponseContentBody;
            this.ShortSummary = log.ShortSummary;
            this.LongSummary = log.LongSummary;
            this.BranchId = log.BranchId;
            this.CreatedDate = log.CreatedDate;
            this.CreatedBy = log.CreatedBy;
            this.Deleted = log.Deleted;
            this.Active = log.Active;
            this.Id = log.Id;
        }
    }
}
