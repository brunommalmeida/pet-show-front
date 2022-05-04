using System;

namespace pet_show_front.Models.MainModels
{
    public class TokenApi
    {        
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Validade { get; set; }
    }
}
