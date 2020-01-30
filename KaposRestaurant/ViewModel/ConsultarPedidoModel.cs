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
        public ObservableCollection<ELEMENTO> Elementos { get; }
        public ObservableCollection<FACTURA> Facturas { get; }
        public ObservableCollection<COMANDA> Comandas { get; set; }

        public double Precio { get; set; }
        List<int> NumeroELementos;
        public ObservableCollection<int> NElementos { get; set; }
        List<double> Precios;
        public ObservableCollection<double> NPrecios{ get; set; }
        public ConsultarPedidoViewModel()
        {
            NumeroELementos = new List<int>();
            Precios = new List<double>();
            Comandas = BbddService.GetComandas();
            Elementos = BbddService.GetElementoFactura(Comandas.First().IdComanda);
            foreach(ELEMENTO x in Elementos)
            {
                NumeroELementos.Add(BbddService.CantidadELementosFacturas(x.IdElemento));
            }

            NElementos = new ObservableCollection<int>(NumeroELementos);

            for(int i = 0; i < NumeroELementos.Count; i++)
            {
                foreach(ELEMENTO x in Elementos)
                {
                    Precios.Add(BbddService.CalcularPrecioPorELmento(NumeroELementos[i], x.IdElemento));
                }
                
            }

            NPrecios = new ObservableCollection<double>(Precios);

        }

    }
}
