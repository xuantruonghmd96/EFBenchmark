using Models_Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models_Lib.ViewModels
{
    public class GradeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public TeacherModel TeacherModel { get; set; }

        public GradeModel(Grade grade)
        {
            this.Id = grade.Id;
            this.Name = grade.Name;
            this.TeacherId = grade.TeacherId;
            this.TeacherModel = new TeacherModel(grade.Teacher);
        }
    }
}
