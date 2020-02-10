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
using System.Windows.Input;
using System.Windows.Threading;

namespace KaposRestaurant.ViewModel
{
    class ConsultarPedidoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<COMANDA> Comandas { get; set; }

        private DispatcherTimer timer;

        public double Precio { get; set; }
        public ConsultarPedidoViewModel()
        {
            Comandas = new ObservableCollection<COMANDA>(BbddService.GetComandas().OrderByDescending(x => x.IdComanda).ToList());
           
        }

        private void ActualizarDataGrid()
        {
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);

        }
        public void Actualizar()
        {
            BbddService.ActualizarBbdd();
           
        }
    }

   
}
