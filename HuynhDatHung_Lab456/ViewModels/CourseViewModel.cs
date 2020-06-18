﻿using HuynhDatHung_Lab456.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HuynhDatHung_Lab456.ViewModels
{
    public class CourseViewModel
    {
        [Required]
        public string Place { get; set; }


        [Required]
        [FutureDate]  
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public Byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }



}