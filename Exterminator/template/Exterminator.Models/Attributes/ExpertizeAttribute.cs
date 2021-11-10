using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Exterminator.Models
{
    public class ExpertizeAttribute : ValidationAttribute
    {
        //only valid: "Ghost catcher", "Ghoul strangler", "Monster encager", "Zombie exploder"

        private string[] vs;

        

        public ExpertizeAttribute(string[] vs)
        {
            this.vs = vs;
            
        }

        public override bool IsValid(object value)
        {
            Console.WriteLine(this.vs.Contains(value));
            Console.WriteLine(value);
            if(this.vs.Contains(value)) 
            {
                return true;
            } else 
            {
                return false;
            }
            
            
        }   
        
    }
}