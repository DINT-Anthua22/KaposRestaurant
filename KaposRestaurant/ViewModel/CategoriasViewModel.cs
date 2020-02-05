using KaposRestaurant.Model;
using KaposRestaurant.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaposRestaurant.ViewModel
{
    class CategoriasViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CATEGORIA> listaCategorias { get; set; }
        public CATEGORIA categoriaSeleccionada { get; set; }
        public CATEGORIA nuevaCategoria { get; set; }

        public CategoriasViewModel()
        {
            listaCategorias = BbddService.GetCategorias();
            nuevaCategoria = new CATEGORIA();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool puedeBorrarCategoria()
        {
            return categoriaSeleccionada != null;
        }

        public void borrarCategoria()
        {
            if (!BbddService.HayElementosEnCategoria(categoriaSeleccionada))
            {
                BbddService.DeleteCategoria(categoriaSeleccionada);
            }
        }

        public void seleccionarImagen(string fileName)
        {
            nuevaCategoria.ImagenCategoriaURL = fileName;
        }

        public void vaciarCampos()
        {
            nuevaCategoria = new CATEGORIA();
        }

        public void añadirCategoria()
        {
            if (!BbddService.ExisteCategoria(nuevaCategoria))
            {
                string[] rutaFichero = nuevaCategoria.ImagenCategoriaURL.Split('\\');
                
                string urlImagen = BlobStorage.guardarImagen(nuevaCategoria.ImagenCategoriaURL, rutaFichero[rutaFichero.Length-1]);

                nuevaCategoria.ImagenCategoriaURL = urlImagen;

                BbddService.AddCategoria(nuevaCategoria);
                
                vaciarCampos();
            }
        }

        public bool puedeAñadirCategoria()
        {
            return nuevaCategoria.NombreCategoria != null && nuevaCategoria.NombreCategoria != "";
        }
    }
}
