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

        private ObservableCollection<COMANDA> verificacion { get; set; }

        

        public double Precio { get; set; }
        public ConsultarPedidoViewModel()
        {
            Comandas = new ObservableCollection<COMANDA>(BbddService.GetComandas().OrderByDescending(x => x.IdComanda).ToList());
            ActualizarDataGrid();

        }

        private void ActualizarDataGrid()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += TimerControlador;
            timer.Start();
        }
        private void TimerControlador(object sender, EventArgs e)
        {
           verificacion = new ObservableCollection<COMANDA>(BbddService.GetComandas().OrderByDescending(x => x.IdComanda).ToList());
            if(Comandas.Count != verificacion.Count)
            {
                Comandas = verificacion;
            }

        }
        public void Actualizar()
        {
            BbddService.ActualizarBbdd();
           
        }
    }

   
}
