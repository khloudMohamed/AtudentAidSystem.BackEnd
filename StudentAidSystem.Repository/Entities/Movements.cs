using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAidSystem.Repository.Entities
{
    public class Movements
    {
        public int Id { get; set; }
        public long Year { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
