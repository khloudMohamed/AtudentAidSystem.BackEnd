using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAidSystem.Repository.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public string GradeName { get; set; }
        public string EducationSystem { get; set; }
        public ICollection<Student> Students { get; set; }
        public Class Class { get; set; }
    }
}
