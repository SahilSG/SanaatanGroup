using Microsoft.AspNet.Identity;
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
    public class MediaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Media

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ShowImages()
        {

            return View(db._Media.OrderBy(m => m.CreatedOn).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Media image)
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            if (ModelState.IsValid)
            {
                string Fname = "";
                string path = "";
                HttpPostedFileBase pb = Request.Files["jpeg"];
                if (pb.ContentLength > 0)
                {
                    Fname = DateTime.Now.ToString("yyyyMMddHHmmssfff") + System.IO.Path.GetFileName(pb.FileName);
                    path = Server.MapPath("~/Content/Media");
                    pb.SaveAs(System.IO.Path.Combine(path, Fname));
                    image.ImageUrl = Fname;
                }

                image.CreatedOn = indianTime;
                db._Media.Add(image);
                db.SaveChanges();
              //  this.AddToastMessage("Congratulations!!!", " Image  Added Successfully", ToastType.Success);
                return RedirectToAction("List");
            }
           // this.AddToastMessage("Error!!!", "Something Went Wrong", ToastType.Error);
            return View(image);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Media m = db._Media.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(m);
        }
        [HttpPost]
        public ActionResult Edit(Media model)
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            if (ModelState.IsValid)
            {
                string fdel = "";
                string Fname = "";
                string path = "";
                HttpPostedFileBase pb = Request.Files["jpeg"];
                if (pb.ContentLength > 0)
                {
                    path = Server.MapPath("~/Content/Media");
                    fdel = System.IO.Path.Combine(path, model.ImageUrl);
                    System.IO.File.Delete(fdel);
                    Fname = DateTime.Now.Date.ToString("yyyyMMddHHmmssfff") + System.IO.Path.GetFileName(pb.FileName);
                    pb.SaveAs(System.IO.Path.Combine(path, Fname));
                    model.ImageUrl = Fname;
                }
                model.CreatedOn = indianTime;
                db._Media.Add(model);
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
             //   this.AddToastMessage("Congratulations!!!", "Changes Saved Successfully", ToastType.Info);
                return RedirectToAction("List");
            }
         //   this.AddToastMessage("Error!!!", "Something Went Wrong", ToastType.Error);
            return View();
        }

        public ActionResult List()
        {

            return View(db._Media.OrderBy(m => m.ImageName).ToList());
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Media m = db._Media.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(m);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Media m = db._Media.Find(id);
            string fdel = m.ImageUrl;

            string path = "";
            path = Server.MapPath("~/Content/Media");
            fdel = System.IO.Path.Combine(path, fdel);
            System.IO.File.Delete(fdel);

            db._Media.Remove(m);
            db.SaveChanges();
           this.AddToastMessage("Congratulations!!!", "Image Deleted Successfully", ToastType.Info);
            return RedirectToAction("List");
        }
        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Media m = db._Media.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(m);
        }

        // Event

        public ActionResult Event()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Event(Event model)
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            if (ModelState.IsValid)
            {


                model.UserId = User.Identity.GetUserId();
                model.CreatedOn = indianTime;

                db._Event.Add(model);
                db.SaveChanges();
                this.AddToastMessage("Congratulations!!!", " Video  Added Successfully", ToastType.Success);
                return RedirectToAction("EventList");
            }
            this.AddToastMessage("Error!!!", "Something Went Wrong", ToastType.Error);
            return View(model);
        }

        public ActionResult EventList()
        {

            return View(db._Event.OrderBy(m => m.CreatedOn).ToList());
        }

        public ActionResult Delete1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event m = db._Event.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(m);
        }
        [HttpPost, ActionName("Delete1")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed1(int id)
        {
            Event m = db._Event.Find(id);
            db._Event.Remove(m);
            db.SaveChanges();
            this.AddToastMessage("Congratulations!!!", "Event Deleted Successfully", ToastType.Info);
            return RedirectToAction("EventList");


        }

        public ActionResult Events()
        {

            return View();
        }

        public ActionResult ViewEvent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event m = db._Event.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(m);
        }

    }
}