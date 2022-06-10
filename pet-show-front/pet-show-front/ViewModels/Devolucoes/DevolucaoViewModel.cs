using pet_show_front.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pet_show_front.ViewModels.Devolucoes
{
    public class DevolucaoViewModel : BaseViewModel
    {
        public ICommand EnviarRomaneioCommand { get; set; }
        public ICommand LimparCommand { get; set; }
        public ItemNotaFiscal ItemNotaFiscal { get; set; }
        public DevolucaoViewModel(Model.ItemNotaFiscal itemNotaFiscal)
        {
            ItemNotaFiscal = itemNotaFiscal;
            EnviarRomaneioCommand = new Command(EnviarDevolucaoAsync);
        }

        public DevolucaoViewModel()
        {

        }
        private async void EnviarDevolucaoAsync()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
