using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanaatanGroup.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        [AllowHtml]
        public string VideoUrl { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string UserId { get; set; }
    }
}