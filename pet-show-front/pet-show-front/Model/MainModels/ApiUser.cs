using System;
using System.Collections.Generic;
using System.Text;

namespace pet_show_front.Models.MainModels
{
    public class ApiUser
    {
        public int Id { get; set; }        
        public string Username { get; set; }        
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
