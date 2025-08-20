//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dmart_web.Core.Models
//{
//    public class User
//    {
//        public int Id { get; set; }
//        public string Username { get; set; }
//        public string Email { get; set; }
//        public string Password { get; set; }
//        public string Role { get; set; }
//        public string Name { get; internal set; }


//    }
//}


namespace Dmart_web.Core.Models
{
    public class User
    {
        public int Id { get; set; }              // Primary Key
        public string FirstName { get; set; }    // User's First Name
        public string LastName { get; set; }     // User's Last Name
        public string Username { get; set; }     // Added Username property
        public string Email { get; set; }        // Email Address
        public string Password { get; set; }     // Encrypted Password
        public string Role { get; set; }         // User Role (Admin, Customer, etc.)
    }
}