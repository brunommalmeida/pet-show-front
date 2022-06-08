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
    public partial class pgRomaneio : pgBasePage
    {
        private Model.ItemRomaneio ItemRomaneio { get; set; }
        public pgRomaneio(Model.ItemRomaneio itemRomaneio)
        {
            InitializeComponent();
            ItemRomaneio = itemRomaneio;
            RomaneioViewModel romaneioViewModel = new RomaneioViewModel(ItemRomaneio);
            BindingContext = romaneioViewModel;

        }
    }
}