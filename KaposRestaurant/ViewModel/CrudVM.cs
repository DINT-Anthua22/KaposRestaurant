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
        public event PropertyChangedEventHandler PropertyChanged;

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
        public int Save_Execute()
        {
            switch (_accion)
            {
                case Accion.Nuevo:

                    if (ElementoSeleccionado.NombreElemento != "" && ElementoSeleccionado.Categoria != 0)
                    {
                        if (BbddService.AddElemento(ElementoSeleccionado) > 0)
                            return 1;
                        else
                            return -1;
                    }
                    else
                        return -1;
                case Accion.Editar:
                    if (BbddService.ActualizarBbdd() > 0)
                        return 2;
                    else
                        return -1;

                case Accion.Borrar:
                    if (BbddService.DeleteElemento(ElementoSeleccionado) > 0)
                        return 3;
                    else
                        return -1;

                default:
                    return 0;
            }
        }


        public void CambiaAccion(Accion accion)
        {
            if (_accion == Accion.Editar || _accion == Accion.Borrar)
            {
                ListaElementos = CategoriaSeleccionada == null ? BbddService.GetElementos() : BbddService.GetElementosCategoria(CategoriaSeleccionada);
            }

            _accion = accion;
        }

        public Accion GetAccion() { return _accion; }

        public void LimpiaCampos()
        {
            ElementoSeleccionado = new ELEMENTO();
        }

        public void SeleccionarImagen() { Console.WriteLine("Seleccionar imagen..."); }

    }
}
