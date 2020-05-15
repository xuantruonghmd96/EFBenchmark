using System;
using System.Collections.Generic;
using System.Text;

namespace Models_Lib.Models
{
    public class Student_2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
		
		public string Last_Name { get; set; }
		public bool Deleted { get; set; }
		public bool Active { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Name2 { get; set; }
		public string PrintName { get; set; }
		public string Image { get; set; }
		public long ProductGroupId { get; set; }
		public int ProductDiscountBandId { get; set; }
		public string BranchId { get; set; }
		public string SysId { get; set; }
		public int? ValidPeriod { get; set; }
		public int ValidPeriodType { get; set; }
		public bool Capacity { get; set; }
		public bool Featured { get; set; }
		public bool SaleOnDevice { get; set; }
		public bool SaleOnWeb { get; set; }
		public string hihi1 { get; set; }
		public string hi2 { get; set; }
		public string hi3 { get; set; }
		public string hi4 { get; set; }
		public int? Age { get; set; }
    }
}
