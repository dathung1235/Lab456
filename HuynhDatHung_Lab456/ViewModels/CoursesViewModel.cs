﻿using HuynhDatHung_Lab456.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuynhDatHung_Lab456.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable <Courses> UpcomingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}