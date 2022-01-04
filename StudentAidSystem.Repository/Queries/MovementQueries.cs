using Microsoft.EntityFrameworkCore;
using StudentAidSystem.Repository.Entities;
using StudentAidSystem.Repository.Interfaces;
using StudentAidSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAidSystem.Repository.Queries
{
    public class MovementQueries: IMovementQueries
    {
        private SchoolDbContext schoolContext;

        public MovementQueries(SchoolDbContext _schoolContext)
        {
            schoolContext = _schoolContext;
        }

        public List<Movements> ShowMovements(int fromYear, int toYear)
        {
            try
            {
                var test = schoolContext.Movements.Include(s => s.Students).ToList();
                return schoolContext.Movements.Include(s => s.Students).Where(f => (f.Year >= fromYear) && (f.Year <= toYear)).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Movements GetMovementsAtGivenYear(long year)
        {
            try
            {
                return schoolContext.Movements.Include(s => s.Students).FirstOrDefault(f => f.Year == year);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool MoveStudent(Student oldStudent, ICollection<Student> student)
        {
            try
            {
                //Add new Movement
                Movements newMovement = new Movements()
                {
                    Id = oldStudent.Id,
                    Year = oldStudent.Year,
                    Students = student

                };
                schoolContext.Movements.Add(newMovement);
                schoolContext.SaveChanges();
                Console.WriteLine("Email SENT TO admin@admin.com FOR ADD NEW STUDENT Movement WITH ID" + newMovement.Id);

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

    }
}
