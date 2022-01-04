using StudentAidSystem.Repository.Entities;
using StudentAidSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAidSystem.Repository.Interfaces
{
    public interface IMovementQueries
    {
         List<Movements> ShowMovements(int fromYear, int toYear);
         Movements GetMovementsAtGivenYear(long year);
         bool MoveStudent(Student oldStudent, ICollection<Student> student);
    }
}
