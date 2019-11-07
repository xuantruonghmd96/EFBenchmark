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

        public Student_2ViewModel(Student_2 student_2)
        {
            this.Id = student_2.Id;
            this.Name = student_2.Name;
            this.GradeId = student_2.Id;
            this.GradeModel = new GradeModel(student_2.Grade);
        }
    }
}
