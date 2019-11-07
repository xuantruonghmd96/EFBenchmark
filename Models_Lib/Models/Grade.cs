using System;
using System.Collections.Generic;
using System.Text;

namespace Models_Lib.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
