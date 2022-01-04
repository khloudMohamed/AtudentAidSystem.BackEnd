using StudentAidSystem.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAidSystem.Repository.Models
{
    public class StudentDetails
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string EgyptionNationalId { get; set; }
        public string Gender { get; set; }
        public string EmergencyContact { get; set; }
        public long Year { get; set; }
        public string GradeName { get; set; }
        public string ClassName { get; set; }

    }
}
