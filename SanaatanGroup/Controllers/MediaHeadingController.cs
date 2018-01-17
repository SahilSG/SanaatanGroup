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
    public class MediaHeadingController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: MediaHeading
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MediaHeading mtype)
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            if (ModelState.IsValid)
            {

                db._MediaHeading.Add(mtype);
                mtype.CreatedOn = indianTime;
                db.SaveChanges();
               // this.AddToastMessage("Congratulations!!!", " Added Successfully", ToastType.Success);
                return RedirectToAction("List", "MediaHeading");

            }
          //  this.AddToastMessage("Error!!!", "Something Went Wrong", ToastType.Error);
            return View(mtype);
        }

        public ActionResult List()
        {

            return View(db._MediaHeading.OrderBy(m => m.MHeading).ToList());
        }
      



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaHeading m = db._MediaHeading.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(MediaHeading mtype)
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            if (ModelState.IsValid)
            {

                db.Entry(mtype).State = EntityState.Modified;
                mtype.CreatedOn = indianTime;
                db.SaveChanges();
               // this.AddToastMessage("Congratulations!!!", "Changes Saved Successfully", ToastType.Info);
                return RedirectToAction("List");
            }
            //this.AddToastMessage("Error!!!", "Something Went Wrong", ToastType.Error);
            return View();
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaHeading m = db._MediaHeading.Find(id);
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
            MediaHeading m = db._MediaHeading.Find(id);
            db._MediaHeading.Remove(m);
            db.SaveChanges();
            //this.AddToastMessage("Congratulations!!!", " Deleted Successfully", ToastType.Info);
            return RedirectToAction("List");


        }
    }
}