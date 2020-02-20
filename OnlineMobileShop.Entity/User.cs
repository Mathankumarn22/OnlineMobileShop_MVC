using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMobileShop.Entity
{
    public class User
    {
   
        public int userID { get; set; }
        public string name { get; set; }
        public long phoneNumber { get; set; }
        public Gender gender { get; set; }
        public string state { get; set; }
        public string mailID { get; set; }
        public string password { get; set; }
       
    }
    public enum Gender
    {
        Male,
        Female, 
        Other
    }
}
