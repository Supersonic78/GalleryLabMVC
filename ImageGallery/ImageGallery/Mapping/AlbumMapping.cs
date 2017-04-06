using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Tables;
using ImageGallery.Models;
using WebGrease.Css.Extensions;

namespace ImageGallery.Mapping
{
    public static class AlbumMapping
    {
        public static AlbumViewModel ToModel(this Album entity)
        {
            var model = new AlbumViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                UserEmail = entity.UserEmail,
                Comments = entity.Comments.ToModel(),
                Photos = entity.Photos.ToModel(),
                
            };
            return model;
        }
        public static List<AlbumViewModel> ToModel(this ICollection<Album> entitys)
        {
            var model = new List<AlbumViewModel>();

            entitys.ForEach(x => model.Add(x.ToModel()));

            return model;
        }

        public static Album ToEntity(this AlbumViewModel model)
        {
            var entity = new Album()
            {
                Id = model.Id,
                Name = model.Name,
                UserEmail = model.UserEmail,
                Comments = model.Comments.ToEntity(),
                Photos = model.Photos.ToEntity(),
                
            };
            return entity;
        }
        public static List<Album> ToEntity(this ICollection<AlbumViewModel> model)
        {
            var entity = new List<Album>();

            model.ForEach(x => entity.Add(x.ToEntity()));

            return entity;
        }
    }
}