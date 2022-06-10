using pet_show_front.ViewModels.Devolucoes;
using pet_show_front.ViewModels.Romaneios;
using pet_show_front.Views.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pet_show_front.Views.Devolucoes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pgListaItensNotasFiscais : pgBasePage
    {
        private Model.NotaFiscal NotaFiscal { get; set; }
        public pgListaItensNotasFiscais(Model.NotaFiscal notaFiscal)
        {
            InitializeComponent();
            NotaFiscal = notaFiscal;

            ListaItensNotasFiscaisViewModel listaItensNotasFiscaisViewModel = new ListaItensNotasFiscaisViewModel(NotaFiscal);
            BindingContext = listaItensNotasFiscaisViewModel;
        }
    }
}