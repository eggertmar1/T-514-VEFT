using System;
using System.Collections.Generic;

namespace Datafication.Repositories.Entities
{
    public class Manufacturer
    {
        public int Id {get; set; }
        public string Name {get; set; }
        public string Bio {get; set; }
        public string ExternalUrl {get; set; }
        public DateTime CreatedDate {get; set;}
        public DateTime ModifiedDate {get; set;}
    }
}