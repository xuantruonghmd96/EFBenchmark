using Models_Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models_Lib.ViewModels
{
    public class Student_2ViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GradeId { get; set; }
        public GradeModel GradeModel { get; set; }

		//public string Last_Name { get; set; }
		//public bool Deleted { get; set; }
		//public bool Active { get; set; }
		//public DateTime CreatedDate { get; set; }
		//public string CreatedBy { get; set; }
		//public DateTime UpdatedDate { get; set; }
		//public string UpdatedBy { get; set; }
		//public string Name2 { get; set; }
		//public string PrintName { get; set; }
		//public string Image { get; set; }
		//public long ProductGroupId { get; set; }
		//public long ProductDiscountBandId { get; set; }
		//public string BranchId { get; set; }
		//public string SysId { get; set; }
		//public int? ValidPeriod { get; set; }
		//public int ValidPeriodType { get; set; }
		//public bool Capacity { get; set; }
		//public bool Featured { get; set; }
		//public bool SaleOnDevice { get; set; }
		//public bool SaleOnWeb { get; set; }
		//public string hihi1 { get; set; }
		//public string hi2 { get; set; }
		//public string hi3 { get; set; }
		//public string hi4 { get; set; }
		//public int? Age { get; set; }

		public Student_2ViewModel() { }

        public Student_2ViewModel(Student_2 student_2)
        {
            this.Id = student_2.Id;
            this.Name = student_2.Name;
            this.GradeId = student_2.Id;
            //this.GradeModel = new GradeModel(student_2.Grade);

			//this.Last_Name = student_2.Last_Name;
			//this.Deleted = student_2.Deleted;
			//this.Active = student_2.Active;
			//this.CreatedDate = student_2.CreatedDate;
			//this.CreatedBy = student_2.CreatedBy;
			//this.UpdatedDate = student_2.UpdatedDate;
			//this.UpdatedBy = student_2.UpdatedBy;
			//this.Name2 = student_2.Name2;
			//this.PrintName = student_2.PrintName;
			//this.Image = student_2.Image;
			//this.ProductGroupId = student_2.ProductGroupId;
			//this.ProductDiscountBandId = student_2.ProductDiscountBandId;
			//this.BranchId = student_2.BranchId;
			//this.SysId = student_2.SysId;
			//this.ValidPeriod = student_2.ValidPeriod;
			//this.ValidPeriodType = student_2.ValidPeriodType;
			//this.Capacity = student_2.Capacity;
			//this.Featured = student_2.Featured;
			//this.SaleOnDevice = student_2.SaleOnDevice;
			//this.SaleOnWeb = student_2.SaleOnWeb;
			//this.hihi1 = student_2.hihi1;
			//this.hi2 = student_2.hi2;
			//this.hi3 = student_2.hi3;
			//this.hi4 = student_2.hi4;
			//this.Age = student_2.Age;
        }
    }
}
