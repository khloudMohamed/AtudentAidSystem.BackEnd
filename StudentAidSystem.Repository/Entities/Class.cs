using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAidSystem.Repository.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Discription { get; set; }
        public int Capacity { get; set; }
        public int FK_Class { get; set; }
        public Grade Grade { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
