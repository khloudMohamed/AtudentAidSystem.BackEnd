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
    public class GradeQueries : IGradeQuaries
    {
        private SchoolDbContext schoolContext;

        public GradeQueries(SchoolDbContext _schoolContext)
        {
            schoolContext = _schoolContext;
        }

        public List<string> GetAllGetGradesNames()
        {
            try
            {
                return schoolContext.Grades.Include(s => s.GradeName).Select(f => f.GradeName).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool AddStudentCurrentGrade(ref Student student, StudentDetails data)
        {
            try
            {
                if (GetStudentCurrentGrade(data) == null)
                {
                    Grade NewGrade = new Grade()
                    {
                        Id = data.StudentID,
                        GradeName = data.GradeName,
                        Class = new Class() { ClassName = data.ClassName },
                        Students = new List<Student>()
                        {
                            new Student()
                            {
                                Id = data.StudentID,
                                StudentName = data.StudentName,
                                DateOfBirth = data.DateOfBirth,
                                Gender = data.Gender,
                                Nationality = data.Nationality,
                                EgyptionNationalId = data.EgyptionNationalId,
                                EmergencyContact = data.EmergencyContact,
                                Year = data.Year
                            }
                        }
                    };
                    var result = schoolContext.Grades.Add(NewGrade);
                    schoolContext.SaveChanges();
                    student = NewGrade.Students.First();
                    return true;
                }
                else
                {
                    Student st = new Student()
                    {
                        Grade = new Grade()
                        {
                            GradeName = data.GradeName,
                            Class = new Class() { ClassName = data.ClassName }
                        }
                    };
                    student = st;
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Grade GetStudentCurrentGrade(StudentDetails student)
        {
            try
            {
                return schoolContext.Grades.Include(s => s.Students).FirstOrDefault(f => f.GradeName == student.GradeName);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
