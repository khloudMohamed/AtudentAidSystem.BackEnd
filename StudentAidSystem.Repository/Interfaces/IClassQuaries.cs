using StudentAidSystem.Repository.Entities;
using StudentAidSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAidSystem.Repository.Interfaces
{
    public interface IClassQuaries
    {
        Boolean AddStudentCurrentClass(ref Student student, StudentDetails data);

        List<string> GetAllClassesNames();
    }
}
