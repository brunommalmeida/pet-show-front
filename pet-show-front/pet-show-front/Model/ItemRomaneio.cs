using System;
using System.Collections.Generic;
using System.Text;

namespace pet_show_front.Model
{
    public class ItemRomaneio
    {
        public int Sequencia { get; set; }
        public string CodigoProduto { get; set; } 
        public string Produto { get; set; }
        public double Quantidade { get; set; }
        public double QuantidadeCarregada { get; set; }
        public string Lote { get; set; }
        public bool Conferido { get; set; }

    }
}
