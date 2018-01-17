using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanaatanGroup.Models
{
    public class Media
    {
        public int Id { get; set; }
        public int MediaHeadingId { get; set; }
        public string ImageName { get; set; }
        [AllowHtml]
        public string ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}