using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SanaatanGroup.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}