using HuynhDatHung_Lab456.Models;
using HuynhDatHung_Lab456.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuynhDatHung_Lab456.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseController()
        {
            _dbContext = new ApplicationDbContext();  
        }
        // GET: Courses
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CourseViewModel viewModel)
        {
            //var viewModel = new CourseViewModel
            //{
            //    Categories = _dbContext.Categories.ToList()

            //};
            //return View(viewModel);
            if(!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Courses
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place

            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Attending()
        {

            var userId = User.Identity.GetUserId();

            var courses = _dbContext.Attendances.Where(a => a.AttendeeId == userId)
                .Select(a => a.Course)
                .Include(l => l.Lecturer)
                .Include(l => l.Category)
                .ToList();



            var viewModel = new CoursesViewModel
            {
                UpcomingCourses = courses,
                ShowAction = User.Identity.IsAuthenticated
            };


            return View(viewModel);
        }
        [Authorize]
        public ActionResult Mine()
        {
            var UserId = User.Identity.GetUserId();
            var courses = _dbContext.Courses.Where(c => c.LecturerId == UserId && c.DateTime>DateTime.Now)
               
               .Include(l => l.Lecturer)
               .Include(l => l.Category)
               .ToList();
            return View(courses);
        }


        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                Heading="Add Course"

            };
            return View(viewModel);
        }


        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(c => c.Id == id && c.LecturerId == userId);

            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                Date = course.DateTime.ToString("dd/M/yyyy"),
                Time = course.CategoryId.ToString(),
                Place = course.Place,
                 Heading = "Add Course",
                 Id=course.Id

            };
            return View("Create", viewModel);
        }




    }



}