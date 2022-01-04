using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAidSystem.Repository.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string EgyptionNationalId { get; set; }
        public string Gender { get; set; }
        public string EmergencyContact { get; set; }
        public long Year { get; set; }
        public Grade Grade { get; set; }
        public Class Class { get; set; }
    }
}
