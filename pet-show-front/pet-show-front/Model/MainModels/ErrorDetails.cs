using System;
using System.Collections.Generic;
using System.Text;

namespace pet_show_front.Models.MainModels
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Trace { get; set; }
    }
}
