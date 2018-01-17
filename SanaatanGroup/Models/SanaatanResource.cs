using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SanaatanGroup.Models
{
    public class SanaatanResource
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Your Full Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Enter Your Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Please Enter Your Designation")]
        public string Designation { get; set; }

        public string KeySkills { get; set; }

        public string Project { get; set; }

        public string Status { get; set; }

        public string Partner { get; set; }
    }
}