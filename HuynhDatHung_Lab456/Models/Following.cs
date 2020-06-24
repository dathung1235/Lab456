using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HuynhDatHung_Lab456.Models
{
    public class Following
    {
        [Key]
        [Column(Order=1)]
        public string FollowerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; }

        public ApplicationUser Follwer { get; set; }
        public ApplicationUser Follwee { get; set; }


    }

}