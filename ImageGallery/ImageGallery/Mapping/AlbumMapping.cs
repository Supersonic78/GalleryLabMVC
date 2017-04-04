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
    }
}