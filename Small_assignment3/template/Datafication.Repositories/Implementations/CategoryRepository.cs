using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Datafication.Models.Dtos;
using Datafication.Models.InputModels;
using Datafication.Repositories.Contexts;
using Datafication.Repositories.Entities;
using Datafication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datafication.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IceCreamDbContext _dbContext;
        public  CategoryRepository(IceCreamDbContext dbContext) 
        {
            _dbContext = dbContext;
        } 
        public IEnumerable<IceCreamDto> GetIceCreamsByCategoryId(int id)
        {
            throw new NotImplementedException();
        }
        public int CreateNewCategory(CategoryInputModel category)
        {
            string new_slug = category.Name;
            new_slug = CultureInfo.CurrentCulture.TextInfo.ToLower(new_slug);
            new_slug = new_slug.Replace(" ", "-");
            var entity = new Category
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }
        public void DeleteCategory(int id) 
        {
            var entity = _dbContext.Categories.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; }
            _dbContext.Categories.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}