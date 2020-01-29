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

        //****************
        //CONSTRUCTOR
        public CrudVM(Accion accion)
        {
            _accion = accion;
            ListaCategorias = BbddService.GetCategorias();

            if (_accion == Accion.Nuevo)
            {
                ElementoSeleccionado = new ELEMENTO();
            }
        }

        /// <summary>
        ///     CRUD BBDD
        /// </summary>
        public void Save_Execute()
        {
            switch (_accion)
            {
                case Accion.Nuevo:

                    BbddService.AddElemento(ElementoSeleccionado);
                    break;
                case Accion.Editar:

                    BbddService.ActualizarBbdd();
                    break;
                case Accion.Borrar:

                    BbddService.DeleteElemento(ElementoSeleccionado);

                    break;
            }
        }


        public void CambiaAccion(Accion accion)
        {
            _accion = accion;
        }

        public void LimpiaCampos()
        {
            ElementoSeleccionado = new ELEMENTO();
        }

        public void SeleccionarImagen() { }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
