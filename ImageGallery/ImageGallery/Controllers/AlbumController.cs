using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Repositories;
using ImageGallery.Mapping;
using ImageGallery.Models;

namespace ImageGallery.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private AlbumRepository AlbumRepository { get; set; }
        private UserRepository UserRepository { get; set; }

        public AlbumController()
        {
            this.AlbumRepository = new AlbumRepository();
            this.UserRepository = new UserRepository();
        }
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var email = User.Identity.Name;

            var model = AlbumRepository.Get(email).ToModel();
            return PartialView(model);
        }

        // GET: Album/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        [HttpPost]
        public ActionResult Create(AlbumViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection.UserEmail = User.Identity.Name;
                    collection.Id = Guid.NewGuid();

                    AlbumRepository.AddOrUpdate(collection.ToEntity());

                    return RedirectToAction("Index");
                }

                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = AlbumRepository.Get(id).ToModel();

            return View(model);
        }

        // POST: Album/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, AlbumViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AlbumRepository.AddOrUpdate(collection.ToEntity());

                    return RedirectToAction("Index");
                }

                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: Album/Delete/5
        [HttpPost]
        public ActionResult Delete(AlbumViewModel collection)
        {
            try
            {
               
                    AlbumRepository.Delete(collection.Id);

                    return RedirectToAction("Index");
                         
            }
            catch
            {
                return View();
            }
        }
    }
}
