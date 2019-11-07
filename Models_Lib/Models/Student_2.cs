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
    }
}
