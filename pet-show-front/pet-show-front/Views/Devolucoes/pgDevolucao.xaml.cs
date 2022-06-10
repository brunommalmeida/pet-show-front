using pet_show_front.ViewModels.Devolucoes;
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
    public partial class pgDevolucao : pgBasePage
    {
        private Model.ItemNotaFiscal ItemNotaFiscal { get; set; }
        public pgDevolucao(Model.ItemNotaFiscal itemNotaFiscal)
        {
            InitializeComponent();
            ItemNotaFiscal = itemNotaFiscal;
            DevolucaoViewModel devolucaoViewModel = new DevolucaoViewModel(ItemNotaFiscal);
            BindingContext = devolucaoViewModel;

        }
    }
}