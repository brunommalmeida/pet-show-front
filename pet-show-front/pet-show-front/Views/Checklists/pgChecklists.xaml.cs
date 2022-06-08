using pet_show_front.ViewModels.Checklists;
using pet_show_front.Views.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pet_show_front.Views.Checklists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pgChecklists : pgBasePage
    {
        private Model.Romaneio Romaneio { get; set; }
        public pgChecklists(Model.Romaneio romaneio)
        {
            InitializeComponent();
            Romaneio = romaneio;
            ChecklistViewModel checklistViewModel = new ChecklistViewModel(Romaneio);
            BindingContext = checklistViewModel;
        }
    }
}