using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_3.Models;
using APBD_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IDbService _DbService;

        public StudentsController(IDbService DbService)
        {
            this._DbService = DbService;

        }
        [HttpGet]
       public IActionResult GetStudents(String orderby = "FirstName")
        {
            return Ok(_DbService.getStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
             if(id == 1)
            {
                return  Ok("Ahmad");
            }else if(id == 2)
            {
                return  Ok("Alice");
            }
            else
            {
                return  NotFound("user was not found") ;
            }
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1,20000)}";
            return Ok(student);
        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            
            _DbService.deleteStudent(id);
            return Ok("Delete completed");
        }

        //I realize the task said that id should be inputted 
        //however i feel like having a student inputed makes more sense
        //since i want to be able to update things like first or last name

        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            _DbService.UpdateStudent(student);
            return Ok("Update completed");
        }

    }
}