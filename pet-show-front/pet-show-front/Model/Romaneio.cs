using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pet_show_front.Model
{
    public class Romaneio
    {
        public int codromaneio { get; set; }
        public DateTime dataemissao { get; set; }
        public DateTime datacarregar { get; set; }
        public int idveiculo { get; set; }
        public string placa { get; set; }
        public string modelo { get; set; }
    }

}
