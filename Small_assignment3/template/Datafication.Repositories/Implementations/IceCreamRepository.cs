using System;
using System.Collections.Generic;
using System.Linq;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;
using Datafication.Repositories.Contexts;
using Datafication.Repositories.Entities;
using Datafication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datafication.Repositories.Implementations
{
    public class IceCreamRepository : IIceCreamRepository
    {
        private readonly IceCreamDbContext _dbContext;
        public IceCreamRepository(IceCreamDbContext dbContext) 
        {
            _dbContext = dbContext;
        } 
        public IEnumerable<IceCreamDto> GetAllIceCreams() 
        {
            var icecreams = _dbContext.IceCreams.Select(c => new IceCreamDto 
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).ToList();
            return icecreams;
        }
        public IceCreamDetailsDto GetIceCreamById(int id) 
        {
            var icecreams = _dbContext.IceCreams.Where(c => c.Id == id).Select(c => new IceCreamDetailsDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
            }).ToList()[0];
            return icecreams;
        }

        public int CreateNewIceCream(IceCreamInputModel iceCream)
        {
            var entity = new IceCream
            {
                Name = iceCream.Name,
                Description = iceCream.Description,
                ManufacturerId = iceCream.ManufacturerId,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            _dbContext.IceCreams.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }
        public void UpdateIceCream(int id, IceCreamInputModel item)
        {
            var entity = _dbContext.IceCreams.FirstOrDefault(a => a.Id == id);
            if (entity == null) { return; }

            entity.Name = item.Name;
            entity.Description = item.Description;
            entity.ManufacturerId = item.ManufacturerId;
            entity.ModifiedDate = DateTime.Now;
            _dbContext.SaveChanges();
        }
        public void DeleteIceCream(int id) 
        {
            var entity = _dbContext.IceCreams.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; }
            _dbContext.IceCreams.Remove(entity);
            _dbContext.SaveChanges();
        }
        public void AddIceCreamToCategory(int iceCreamId, int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}