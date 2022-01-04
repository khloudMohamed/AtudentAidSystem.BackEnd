using StudentAidSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAidSystem.Repository
{
    public interface IStudentQueries
    {
        Boolean SaveStudentData(StudentDetails student);

    }
}
