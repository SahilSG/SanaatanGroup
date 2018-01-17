using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SanaatanGroup.Models
{
    public class State
    {
        public int Id { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]

        public string StateName { get; set; }
        public virtual Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}