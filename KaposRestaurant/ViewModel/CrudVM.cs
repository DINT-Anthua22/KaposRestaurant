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
    class CrudVM : INotifyPropertyChanged
    {
        public ELEMENTO ElementoSeleccionado { get; set; }

        public CATEGORIA CategoriaSeleccionada { get; set; }

        public ObservableCollection<ELEMENTO> ListaElementos { get; set; }
        public ObservableCollection<CATEGORIA> ListaCategorias { get; set; }

        private Accion _accion;

        public CrudVM(Accion accion)
        {
            _accion = accion;
            ListaCategorias = BbddService.GetCategorias();

            if (_accion == Accion.Nuevo)
            {
                ElementoSeleccionado = new ELEMENTO();
            }
        }

        public void Save_Execute()
        {
            switch (_accion)
            {
                case Accion.Nuevo:
                    break;
                case Accion.Editar:
                    break;
                case Accion.Borrar:
                    break;
                default:
                    break;
            }
        }


        public void CambiaAccion(Accion accion)
        {
            _accion = accion;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
