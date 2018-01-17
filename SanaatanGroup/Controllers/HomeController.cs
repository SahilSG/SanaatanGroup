
using SanaatanGroup.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SanaatanGroup.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult States(string cid)
        {
            int id = Convert.ToInt32(cid);
            var StatesList = (from st in db._State where st.CountryId == id select st).ToList();
            List<SelectListItem> states = new List<SelectListItem>();
            foreach (var s in StatesList)
            {
                states.Add(new SelectListItem { Text = s.StateName, Value = s.Id.ToString() });
            }
            return Json(new SelectList(states, "Value", "Text"));
        }
        public JsonResult Cities(string sid)
        {
            int id = Convert.ToInt32(sid);
            var citi = (from st in db._City where st.StateId == id select st).ToList();

            List<SelectListItem> cities = new List<SelectListItem>();
            foreach (var s in citi)
            {
                cities.Add(new SelectListItem { Text = s.CityName, Value = s.Id.ToString() });
            }
            return Json(new SelectList(cities, "Value", "Text"));
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
           

            return View();
        }
         [Authorize]
        public ActionResult Careers()
        {
            ViewBag.Message = "Careers - Sanaatan Group";
            return View();
        }
        [HttpPost]
        public ActionResult Careers(JobSeeker js, FormCollection frm)
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            if (ModelState.IsValid)
            {
                string Fname = "";
                string path = "";
                HttpPostedFileBase pb = Request.Files["ResumeFile"];
                string ext = System.IO.Path.GetExtension(pb.FileName);
                if (pb != null && pb.ContentLength > 0)
                {
                    if (ext == ".docx" || ext == ".pdf" || ext == ".doc" || ext == ".rtf")
                    {
                        Fname = DateTime.Now.ToString("yyyyMMddHHmmssfff") + System.IO.Path.GetFileName(pb.FileName);
                        path = Server.MapPath("~/Content/resume/");
                        pb.SaveAs(System.IO.Path.Combine(path, Fname));

                        js.ResumeFile = Fname;
                        js.ProfessionalExperience = frm["EYears"].ToString() + " Years " + frm["EMonths"].ToString() + " Months";
                        var ee = js.Email;


                        ModelState.Clear();
                           MailMessage mail = new MailMessage();

                            mail.To.Add(js.Email);
                            mail.From = new MailAddress("no-reply@gmail.com");
                            mail.Subject = "Acknowledgement Mail";
                            string Body = "Dear " + js.Name + ", " + Environment.NewLine + "We have received your resume, and will let you know if we can find a job for your profile in our organisation." + Environment.NewLine + "Best Regards" + Environment.NewLine + "HR Team";
                            mail.Body = Body;
                            mail.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = Convert.ToInt32(587);
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new System.Net.NetworkCredential
                            ("hr.sanaatan@gmail.com", "prOhr@2017");// Enter seders User name and password
                            smtp.EnableSsl = true;
                            smtp.Send(mail);

                        MailMessage mail1 = new MailMessage();
                            mail1.To.Add("hr@teamsanaatan.com");
                            mail1.From = new MailAddress("no-reply@gmail.com");
                            mail1.Subject = "CV Recieved";
                            string Body1 = js.Name+" has uploaded the CV";
                            mail1.Body = Body1;
                            mail1.IsBodyHtml = true;
                            SmtpClient smtp1 = new SmtpClient();
                            smtp1.Host = "smtp.gmail.com";
                            smtp1.Port = Convert.ToInt32(587);
                            smtp1.UseDefaultCredentials = false;
                            smtp1.Credentials = new System.Net.NetworkCredential
                           ("hr.sanaatan@gmail.com", "prOhr@2017");
                            smtp1.EnableSsl = true;
                            smtp1.Send(mail1);
                        

                    }
                    else
                    {
                        this.AddToastMessage("Error!!!", "Something Went Wrong", ToastType.Error);
                        ModelState.AddModelError("You can upload only docx or pdf file", "You can upload only docx or pdf file");
                        return View();
                    }
                }
                js.CreatedOn = indianTime;
                db._JobSeeker.Add(js);
                db.SaveChanges();
                this.AddToastMessage("Thanks!!", "Your CV has been Uploaded Successfully", ToastType.Success);
                //return View().Success("your profile has been submitted successfully.");
            }
            return RedirectToAction("Index","Home");
        }
        public ActionResult List()
        {
            return View(db._JobSeeker.OrderBy(m=>m.Name).ToList());
        }
       public ActionResult Details(int? Id)
        {
            ViewBag.FormHead = "JobSeeker Details";
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker seeker = db._JobSeeker.Find(Id);
            if (seeker == null)
            {
                return HttpNotFound();
            }
            return View(seeker);
        }
        [HttpGet]
        public ActionResult DisplayEmail()
        {
            return View();
        }
        public ActionResult Thankyou()
        {
            return View();
        }
      

    }
}