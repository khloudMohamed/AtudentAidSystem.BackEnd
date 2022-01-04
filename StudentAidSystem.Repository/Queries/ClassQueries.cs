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
    public class ClassQueries:IClassQuaries
    {
        private SchoolDbContext schoolContext;

        public ClassQueries(SchoolDbContext _schoolContext)
        {
            schoolContext = _schoolContext;
        }

        public List<string> GetAllClassesNames()
        {
            try
            {
                return schoolContext.Classes.Include(s => s.ClassName).Select(f => f.ClassName).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Class GetStudentCurrentClass(StudentDetails student)
        {
            try
            {
                return schoolContext.Classes.Include(s => s.Students).FirstOrDefault(f => f.ClassName == student.ClassName);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Boolean AddStudentCurrentClass(ref Student student, StudentDetails data)
        {
            try
            {
                if (GetStudentCurrentClass(data) == null)
                {
                    Class NewClass = new Class()
                    {
                        ClassName = data.ClassName,
                        //TODO need to get max capacity from db then add 1 to in 
                        Capacity = 50,
                        Discription = "Class " + data.ClassName.ToString(),
                        Grade = new Grade() { GradeName = data.GradeName },
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
                    var result = schoolContext.Classes.Add(NewClass);
                    schoolContext.SaveChanges();
                    student = NewClass.Students.First();
                    return true;
                }
                else
                {
                    Student st = new Student()
                    {
                        Class = new Class()
                        {
                            ClassName = data.ClassName,
                            //TODO need to get max capacity from db then add 1 to in 
                            Capacity = 50,
                            Discription = "Class " + data.ClassName.ToString(),
                            Grade = new Grade() { GradeName = data.GradeName }
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

    }
}
