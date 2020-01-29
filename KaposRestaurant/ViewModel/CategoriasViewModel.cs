using KaposRestaurant.Model;
using KaposRestaurant.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaposRestaurant.ViewModel
{
    class CategoriasViewModel
    {
        public ObservableCollection<CATEGORIA> listaCategorias { get; set; }
        public CATEGORIA categoriaSeleccionada { get; set; }
        public CATEGORIA nuevaCategoria { get; set; }

        public CategoriasViewModel()
        {
            listaCategorias = BbddService.GetCategorias();
        }


        public bool puedeBorrarCategoria()
        {
            return categoriaSeleccionada != null;
        }

        public void borrarCategoria()
        {
            if (!BbddService.HayElementosEnCategoria())
            {
                BbddService.DeleteCategoria(categoriaSeleccionada);
            }
        }

        public void seleccionarImagen()
        {
            
        }

        public void vaciarCampos()
        {
            nuevaCategoria = null;
        }

        public void añadirCategoria()
        {
            if (!BbddService.ExisteCategoria(nuevaCategoria))
            {
                BbddService.AddCategoria(nuevaCategoria);
            }
        }

        public bool puedeAñadirCategoria()
        {
            return nuevaCategoria.NombreCategoria != "";
        }
    }
}
