using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Tables;
using ImageGallery.Models;
using WebGrease.Css.Extensions;

namespace ImageGallery.Mapping
{
    public static class PhotoMapping
    {
        public static PhotoViewModel ToModel(this Photo entity)
        {
            var model = new PhotoViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Url = entity.Url,
                Comments = entity.Comments.ToModel()
            };
            return model;
        }
        public static List<PhotoViewModel> ToModel(this ICollection<Photo> entitys)
        {
            var model = new List<PhotoViewModel>();

            entitys.ForEach(x => model.Add(x.ToModel()));

            return model;
        }

    }
}