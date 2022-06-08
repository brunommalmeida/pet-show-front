using pet_show_front.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace pet_show_front.ViewModels.Checklists
{
    public class ChecklistViewModel : BaseViewModel
    {
        public ICommand EnviarChecklistCommand { get; set; }
        public ICommand LimparCommand { get; set; }
        public Romaneio Romaneio { get; set; }
        public Checklist Checklist { get; set; }
        public ChecklistViewModel(Model.Romaneio romaneio)
        {
            Romaneio = romaneio;
         
        }
        public ChecklistViewModel()
        {

        }

    }
}
