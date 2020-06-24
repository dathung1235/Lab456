using HuynhDatHung_Lab456.DTOs;
using HuynhDatHung_Lab456.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HuynhDatHung_Lab456.Controllers
{
    public class FollowingsController : ApiController

    {
        private readonly ApplicationDbContext _dbContext;
            public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(FollowingDto follwingDto)
        {

            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == follwingDto.FolloweeId))
                return BadRequest("The Attendance already exist!");





            var folowing = new Following
            {

                FollowerId = userId,
                FolloweeId = follwingDto.FolloweeId








            };

            _dbContext.Followings.Add(folowing);
            _dbContext.SaveChanges();
            return Ok();
        }



    }
}
