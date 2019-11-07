using Models_Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models_Lib.ViewModels
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TeacherModel(Teacher teacher)
        {
            this.Id = teacher.Id;
            this.Name = teacher.Name;
        }
    }
}
