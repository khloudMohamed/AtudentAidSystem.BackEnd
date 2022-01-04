using Microsoft.AspNetCore.Mvc;
using StudentAidSystem.Repository.Interfaces;
using StudentAidSystem.Repository.Entities;
using StudentAidSystem.Repository.Models;
using System;
using System.Collections.Generic;

namespace StudentAidSystem.Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailsController : ControllerBase
    {
        private readonly IStudentQueries studentQueries;
        private readonly IMovementQueries movementQueries;
        private readonly IClassQuaries classQuaries;
        private readonly IGradeQuaries gradeQuaries;


        public StudentDetailsController(IStudentQueries studentQueries, IMovementQueries movementQueries)
        {
            this.studentQueries = studentQueries;
            this.movementQueries = movementQueries;
        }

        [HttpPost]
        [Route("StudentData")]
        public Boolean StudentData(StudentDetails StudentData)
        {
            return studentQueries.SaveStudentData(StudentData);
        }

        [HttpGet]
        [Route("GetMovementsByYear")]
        public List<Movements> GetMovementsByYear(int fromYear, int toYear)
        {
            return movementQueries.ShowMovements(fromYear, toYear);
        }

        [HttpGet]
        [Route("GetClasses")]
        public List<string> GetClasses()
        {
            return classQuaries.GetAllClassesNames();
        }

        [HttpGet]
        [Route("GetGrades")]
        public List<string> GetGrades()
        {
            return gradeQuaries.GetAllGetGradesNames();
        }
    }
}
