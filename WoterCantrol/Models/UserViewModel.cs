using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoterCantrol.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
    }
}