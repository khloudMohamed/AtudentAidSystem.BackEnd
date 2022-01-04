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
    public class StudentQueries : IStudentQueries
    {
        private SchoolDbContext schoolContext;
        private IMovementQueries movementQueries;
        private IGradeQuaries gradeQuaries;
        private IClassQuaries classQuaries;


        public StudentQueries(SchoolDbContext schoolContext, IMovementQueries movementQueries,
            IGradeQuaries gradeQuaries,IClassQuaries classQuaries)
        {
            this.schoolContext = schoolContext;
            this.movementQueries = movementQueries;
            this.gradeQuaries = gradeQuaries;
            this.classQuaries = classQuaries;
        }

        public bool SaveStudentData(StudentDetails student)
        {
            try
            {
                if (ValidateNewStudent(student))
                {
                    Student oldStudent = new Student();

                    var movements = movementQueries.GetMovementsAtGivenYear(student.Year);
                    if (movements != null)
                    { oldStudent = movements.Students.FirstOrDefault(f => f.Id == student.StudentID); }

                    if (oldStudent == null)
                    {
                        //Add new student
                        Student newStudent = new Student();
                        AddStudentClass(ref newStudent, student);
                        AddStudentGrade(ref newStudent, student);

                        newStudent.Id = student.StudentID;
                        newStudent.StudentName = student.StudentName;
                        newStudent.DateOfBirth = student.DateOfBirth;
                        newStudent.Gender = student.Gender;
                        newStudent.Nationality = student.Nationality;
                        newStudent.EgyptionNationalId = student.EgyptionNationalId;
                        newStudent.EmergencyContact = student.EmergencyContact;
                        newStudent.Year = student.Year;
                        
                        schoolContext.Students.Add(newStudent);
                        schoolContext.SaveChanges();
                        Console.WriteLine("Email SENT TO admin@admin.com FOR ADD NEW STUDENT WITH ID" + newStudent.Id);
                        return true;
                    }
                    else
                    {
                        //this is old student then add student movement(Add New Movement)
                        if (movements != null)
                        {
                            movements.Students.Add(oldStudent);
                            if (movementQueries.MoveStudent(oldStudent, movements.Students))
                                return true;
                        }
                        else
                        {
                            //Create movement for frist time
                            Student newStudent = new Student();
                            AddStudentClass(ref newStudent, student);
                            AddStudentGrade(ref newStudent, student);
                            List<Student> std = new List<Student>();
                            newStudent.Id = student.StudentID;
                            newStudent.StudentName = student.StudentName;
                            newStudent.DateOfBirth = student.DateOfBirth;
                            newStudent.Gender = student.Gender;
                            newStudent.Nationality = student.Nationality;
                            newStudent.EgyptionNationalId = student.EgyptionNationalId;
                            newStudent.EmergencyContact = student.EmergencyContact;
                            newStudent.Year = student.Year;
                             
                            std.Add(newStudent);
                            movements = new Movements()
                            {
                                Year = student.Year,
                                Students = std
                            };
                            if (movementQueries.MoveStudent(oldStudent, movements.Students))
                                return true;
                        }
                           
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool ValidateNewStudent(StudentDetails student)
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private Boolean AddStudentGrade(ref Student student, StudentDetails data)
        {
            try
            {
                return gradeQuaries.AddStudentCurrentGrade(ref  student,  data);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private Boolean AddStudentClass(ref Student student,StudentDetails data)
        {
            try
            {
                return classQuaries.AddStudentCurrentClass(ref  student,  data);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
