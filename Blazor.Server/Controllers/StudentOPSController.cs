﻿using Blazor.Shared.Models;
using Blazor.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentOPSController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public StudentOPSController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }


        [HttpGet]
        [Route("GetStudentsList")]
        public async Task<IActionResult> GetStudentsList()
        {
            List<StudentEntity> students = new List<StudentEntity>();

            students = await _studentServices.GetAllStudent().ToList();

            return Ok(students);
        }
    }
}