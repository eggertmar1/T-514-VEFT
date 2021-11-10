using System.Linq;
using Datafication.Models.Dtos;
using Datafication.Repositories.Contexts;
using Datafication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Datafication.Repositories.Implementations
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly IceCreamDbContext _dbContext;
        public  ManufacturerRepository(IceCreamDbContext dbContext) 
        {
            _dbContext = dbContext;
        } 
        public ManufacturerDetailsDto GetManufacturerById(int id)
        {
            var author = _dbContext.Manufacturers.Where(c => c.Id == id).Select(c => new ManufacturerDetailsDto
            {
                Id = c.Id,
                Name = c.Name,
                Bio = c.Bio,
                ExternalUrl = c.ExternalUrl
            }).ToList()[0];
            return author;
        }

    }
}