using System;
using System.Collections.Generic;

namespace Datafication.Repositories.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentCategoryId {get; set;} // Needs to be nullable? 
        public DateTime CreatedDate {get; set;}
        public DateTime ModifiedDate {get; set;}
    }
}