using SanaatanGroup.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SanaatanGroup.Controllers
{
    public class SanaatanResourceController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SanaatanResource
        public ActionResult TPACManagingPartner()
        {
            return View();
        }
        public ActionResult Erstwhile()
        {
            return View();
        }
        public ActionResult TPACAssociatePartner()
        {
            return View();
        }
        public ActionResult TPACAssociateTrainee()
        {
            return View();
        }
        public ActionResult TPACSupportStaff()
        {
            return View();
        }
        public ActionResult TPACExecutivePartner()
        {
            return View();
        }
        public ActionResult TPACExecutiveTrainee()
        {
            return View();
        }
        public ActionResult JammuTechnologyPartner()
        {
            return View();
        }
        public ActionResult JammuEstablishmentPartner()
        {
            return View();
        }
        public ActionResult MCAAssociatePartner()
        {
            return View();
        }
        public ActionResult MCAAssociateDirector()
        {
            return View();
        }
        public ActionResult TOACAssociatePartner()
        {
            return View();
        }
        public ActionResult TOACAssociateTrainee()
        {
            return View();
        }
        public ActionResult TOACExecutiveTrainee()
        {
            return View();
        }
        public ActionResult TOACTeamLeader()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {

            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(SanaatanResource js)
        {

            if (ModelState.IsValid)
            {
                string Fname = "";
                string path = "";
                HttpPostedFileBase pb = Request.Files["image"];
                if (pb != null && pb.ContentLength > 0)
                {

                    Fname = DateTime.Now.ToString("yyyyMMddHHmmssfff") + System.IO.Path.GetFileName(pb.FileName);
                    path = Server.MapPath("~/Content/UploadedImages/Sanaatan");
                    pb.SaveAs(System.IO.Path.Combine(path, Fname));

                    js.Image = Fname;

                }
                db._SanaatanResource.Add(js);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult List()
        {
            return View(db._SanaatanResource.OrderBy(m => m.Name).ToList());
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanaatanResource m = db._SanaatanResource.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(m);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Edit(SanaatanResource model)
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            if (ModelState.IsValid)
            {
                string fdel = "";
                string Fname = "";
                string path = "";
                HttpPostedFileBase pb = Request.Files["image"];
                if (pb != null && pb.ContentLength > 0)
                {
                    path = Server.MapPath("~/Content/UploadedImages/Sanaatan");
                    fdel = System.IO.Path.Combine(path, model.Image);
                    System.IO.File.Delete(fdel);
                    Fname = DateTime.Now.Date.ToString("yyyyMMddHHmmssfff") + System.IO.Path.GetFileName(pb.FileName);
                    pb.SaveAs(System.IO.Path.Combine(path, Fname));
                    model.Image = Fname;
                }

                db._SanaatanResource.Add(model);
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("List");
            }

            return View();
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanaatanResource m = db._SanaatanResource.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(m);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanaatanResource m = db._SanaatanResource.Find(id);
            string fdel = m.Image;

            string path = "";
            path = Server.MapPath("~/Content/UploadedImages/Sanaatan");
            fdel = System.IO.Path.Combine(path, fdel);
            System.IO.File.Delete(fdel);

            db._SanaatanResource.Remove(m);
            db.SaveChanges();

            return RedirectToAction("List");
        }
        [Authorize]
        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanaatanResource m = db._SanaatanResource.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(m);
        }
    }
}