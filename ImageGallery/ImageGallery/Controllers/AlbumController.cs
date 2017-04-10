using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Repositories;
using DAL.Tables;
using ImageGallery.Mapping;
using ImageGallery.Models;

namespace ImageGallery.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private AlbumRepository AlbumRepository { get; set; }
        private UserRepository UserRepository { get; set; }
        private CommentRepository CommentRepository { get; set; }

        public AlbumController()
        {
            this.AlbumRepository = new AlbumRepository();
            this.UserRepository = new UserRepository();
            this.CommentRepository = new CommentRepository();
        }
        // GET: Album
        public ActionResult Index()
        {
            //var pr = new PhotoRepository();
            //pr.Clear();
            //AlbumRepository.Clear();
            return View();
        }

        public ActionResult List()
        {
            var email = User.Identity.Name;

            var model = AlbumRepository.Get(email).ToModel();
            return PartialView("List", model);
        }



        // GET: Album/Create

        // POST: Album/Create
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(AlbumViewModel collection)
        {
            if (ModelState.IsValid)
            {
                collection.UserEmail = User.Identity.Name;
                collection.Id = Guid.NewGuid();

                AlbumRepository.AddOrUpdate(collection.ToEntity());
            }

            return List();
        }

        public ActionResult Comment(Guid id)
        {
            var comments = CommentRepository.Get(id).ToModel();

            return PartialView(comments);
        }
        [HttpPost]
        public ActionResult CreateComment(string comment, Guid id)
        {
            var model = new CommentViewModel()
            {
                Id = Guid.NewGuid(),
                UserEmail = User.Identity.Name,
                Text = comment,
                AlbumRefId =id,
            };
            CommentRepository.AddOrUppdate(model.ToEntity());

            return Comment(id);
        }

        public ActionResult DeleteComment(Guid id)
        {
            CommentRepository.Delete(id);

            return null;
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
            AlbumRepository.Delete(id);

            return null;
        }

        // POST: Album/Delete/5


    }
}
