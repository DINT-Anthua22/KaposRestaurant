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
        public ObservableCollection<COMANDA> Comanda { get; }
        public ObservableCollection<CATEGORIA> Categorias { get; }

        public int PrecioSinIva { get; set; }
        private double precio = 0;
        public ConsultarPedidoViewModel()
        {
            Elementos = BbddService.GetElementos();
            Facturas = BbddService.GetFacturas();
            Comanda = BbddService.GetComandas();
            Categorias = BbddService.GetCategorias();
            foreach(ELEMENTO x in Elementos)
            {
                precio += x.Precio;
            }
        }
    }
}
