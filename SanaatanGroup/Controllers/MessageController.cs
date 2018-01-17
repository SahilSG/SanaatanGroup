using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace SanaatanGroup.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PurposeOfOurExistence()
        {
            return View();
        }
        public ActionResult MessageFromThePrimeMover()
        {
            return View();
        }
        public ActionResult MissionAndValues()
        {
            return View();
        }
        public ActionResult KeyDifferentiators()
        {
            return View();
        }
        public ActionResult ExecutiveLeadership()
        {
            return View();
        }
        public ActionResult ServiceVerticals()
        {
            return View();
        }
        public ActionResult KeyIndustrialExposure()
        {
            return View();
        }
        public ActionResult OurAlliancesAndAssociates()
        {
            return View();
        }
        public ActionResult CorporateExpedition()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection frm)
        {
            string message = frm["Message"].ToString();
            string name = frm["Name"].ToString();
            string Company = frm["Company"].ToString();
            string Country = frm["Country"].ToString();
            string Address = frm["Address"].ToString();
            string City = frm["City"].ToString();
            string State = frm["State"].ToString();
            string Phone = frm["Phone"].ToString();
            string text = message + "@From:@" + name + "@" + Company + "@" + Address + "@" + City + "@" + State + "@" + Country + "@" + Phone;
            text = text.Replace("@", Environment.NewLine);
            string html = text;
            //do whatever you want to the message        
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(frm["Email"].ToString());
            msg.To.Add(new MailAddress("hr@teamsanaatan.com"));
            msg.Subject = "Enquiry At Sanaatan Group Website";
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
            msg.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("hr.sanaatan@gmail.com", "prOhr@2017");
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);
            return View();
        }
        public ActionResult ProjectAndEfforts()
        {
            return View();
        }
        public ActionResult EGovernance()
        {
            return View();
        }
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        public ActionResult Disclaimer()
        {
            return View();
        }
        public ActionResult Brands()
        {
            return View();
        }
    }
}