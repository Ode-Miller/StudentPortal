﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Add(AddStudentViewModel viewModel)
        //{
        //    var student = new Student
        //    {
        //        Name = viewModel.Name,
        //        Email = viewModel.Email,
        //        Phone = viewModel.Phone,
        //        Subscribed = viewModel.Subscribed
        //    };
        //    dbContext.Students.Add(student);
        //    dbContext.SaveChanges();

        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            
            return View();
        }
    }
}
