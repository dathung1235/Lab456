using System;
using System.Data.Entity;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HuynhDatHung_Lab456.Models;
using HuynhDatHung_Lab456.ViewModels;

namespace HuynhDatHung_Lab456.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        

        public ActionResult Index()
        {

            var upcomingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c =>c.Category)
                .Where(c => c.DateTime > DateTime.Now).ToList();


            var viewModel = new CoursesViewModel
            {
                UpcomingCourses = upcomingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };


            return View(viewModel);  
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }



}