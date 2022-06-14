using System;
using System.Collections.Generic;
using System.Text;

namespace pet_show_front.Model.MainModels
{
    public class ReceiveApi<T> where T : class
    {
        public string message { get; set; }
        public T value { get; set; }
    }
}
