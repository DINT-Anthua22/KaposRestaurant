using KaposRestaurant.Model;
using KaposRestaurant.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaposRestaurant.ViewModel
{
    class ConsultarPedidoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<COMANDA> Comandas { get; set; }

        public ConsultarPedidoViewModel()
        {
            Comandas = BbddService.GetComandas();
        }
    }
}
