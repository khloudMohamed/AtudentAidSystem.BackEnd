using StudentAidSystem.Repository.Entities;
using StudentAidSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAidSystem.Repository.Interfaces
{
    public interface IGradeQuaries
    {
        Boolean AddStudentCurrentGrade(ref Student student, StudentDetails data);

        List<string> GetAllGetGradesNames();
    }
}
