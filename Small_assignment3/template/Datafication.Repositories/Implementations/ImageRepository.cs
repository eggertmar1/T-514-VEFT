using System.Collections.Generic;
using System.Linq;
using System;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;
using Datafication.Repositories.Contexts;
using Datafication.Repositories.Entities;
using Datafication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datafication.Repositories.Implementations
{
    public class ImageRepository : IImageRepository
    {
        private readonly IceCreamDbContext _dbContext;
        public  ImageRepository(IceCreamDbContext dbContext) 
        {
            _dbContext = dbContext;
        } 
        public ImageDetailsDto GetImageById(int id) 
        {
            var Image = _dbContext.Images.Where(c => c.Id == id).Select(c => new ImageDetailsDto
            {
                Id = c.Id,
                Url = c.Url,
            }).ToList()[0];
            return Image;
        }
        public IEnumerable<ImageDto> GetAllImagesByIceCreamId(int iceCreamId)
        {
            throw new NotImplementedException();
        }
        // {
        //     var Image = _dbContext.Images.Where(c => c.IceCreamId == iceCreamId).Select(c => new ImageDetailsDto
        //     {
        //         Id = c.Id,
        //         Url = c.Url,
        //     }).ToList()[0];
        //     return Image;
        // }
        public int CreateNewImage(ImageInputModel image)
        {
            var entity = new Image
            {
                IceCreamId = image.IceCreamId,
                Url = image.Url
            };
            _dbContext.Images.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }
    }
}