using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanaatanGroup.Models
{
    public class JobSeeker
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Your Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Select Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Select State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please Select City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Your Contact Number")]
        [Phone(ErrorMessage = "Please Enter a Valid Phone Number")]
        public string Mobile { get; set; }
        public string AlternateNo { get; set; }
        [Required(ErrorMessage = "Please Select a Relevant Option")]
        public string Graduation { get; set; }
        [Required(ErrorMessage = "Please Select a Relevant Option")]
        public string Postgraduation { get; set; }
        public string ProfessionalExperience { get; set; }
        public string ResumeFile { get; set; }
    }
}