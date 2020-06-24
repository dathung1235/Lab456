using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace HuynhDatHung_Lab456.Models
{
    public class Attendance
    {
        public Courses Course { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CourseId { get; set; }

        public ApplicationUser Attendee { get; set; }
        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}