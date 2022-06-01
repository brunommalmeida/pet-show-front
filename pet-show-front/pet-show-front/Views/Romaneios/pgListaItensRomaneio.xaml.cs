using pet_show_front.ViewModels.Romaneios;
using pet_show_front.Views.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pet_show_front.Views.Romaneios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pgListaItensRomaneio : pgBasePage
    {
        private Model.Romaneio Romaneio { get; set; }
        public pgListaItensRomaneio(Model.Romaneio romaneio)
        {
            InitializeComponent();
            Romaneio = romaneio;

            ListaItensRomaneioViewModel listaItensRomaneioViewModel = new ListaItensRomaneioViewModel(Romaneio);
            BindingContext = listaItensRomaneioViewModel;
        }
    }
}