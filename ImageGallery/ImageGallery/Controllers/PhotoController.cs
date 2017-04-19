using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Repositories;
using DAL.Tables;
using ImageGallery.Mapping;
using ImageGallery.Models;

namespace ImageGallery.Controllers
{
    public class PhotoController : Controller
    {
       private PhotoRepository PhotoRepository { get; set; }

        public PhotoController()
        {
            PhotoRepository = new PhotoRepository();
        }
        // GET: Photo
        public ActionResult Index(Guid id)
        {
            ViewBag.AlbumRefId = id;

            return View();
        }

        // GET: Photo/Details/5
        public ActionResult List(Guid id) // Album Id
        {
            var photos = PhotoRepository.Get(id);
            return View(photos.ToModel());
        }



        public ActionResult Create(Guid id) // Album id
        {
            ViewBag.AlbumRefId = id;
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhotoViewModel model,HttpPostedFileBase file,Guid id)
        {
            if (ModelState.IsValid)
            {
                if (file != null || file.ContentLength != 0)
                {
                    model.Url = @"/img/" + file.FileName;
                    model.AlbumRefId = id;
                    PhotoRepository.Add(model.ToEntity());
                   
                    file.SaveAs(Path.Combine(Server.MapPath("~/img"), file.FileName));
                }
            }
        
            return List(id);
        }

        // GET: Photo/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Photo photo = db.Photos.Find(id);
        //    if (photo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.AlbumRefID = new SelectList(db.Albums, "Id", "Name", photo.AlbumRefID);
        //    return View(photo);
        //}

        // POST: Photo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Url,AlbumRefID")] Photo photo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(photo).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.AlbumRefID = new SelectList(db.Albums, "Id", "Name", photo.AlbumRefID);
        //    return View(photo);
        //}

    }
}
