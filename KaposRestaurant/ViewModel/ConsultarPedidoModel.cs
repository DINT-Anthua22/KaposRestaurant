using KaposRestaurant.Model;
using KaposRestaurant.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KaposRestaurant.ViewModel
{
    class ConsultarPedidoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<COMANDA> Comandas { get; set; }

        public double Precio { get; set; }
        public ConsultarPedidoViewModel()
        {
            Comandas = new ObservableCollection<COMANDA>(BbddService.GetComandas().OrderByDescending(x => x.IdComanda).ToList());
           
        }

        public void Actualizar()
        {
            BbddService.ActualizarBbdd();
           
        }
    }

   
}
