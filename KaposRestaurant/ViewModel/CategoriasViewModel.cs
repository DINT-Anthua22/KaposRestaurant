using KaposRestaurant.Model;
using KaposRestaurant.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            nuevaCategoria = new CATEGORIA();
        }

        public bool puedeBorrarCategoria()
        {
            return categoriaSeleccionada != null;
        }

        public void borrarCategoria()
        {
            if (!BbddService.HayElementosEnCategoria(categoriaSeleccionada))
            {
                BbddService.DeleteCategoria(categoriaSeleccionada);
                MessageBox.Show("Categoría eliminada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se puede eliminar la categoría debido a que contiene elementos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void seleccionarImagen()
        {
            //Creamos un nuevo diálogo
            FolderBrowserDialog dialogo = new FolderBrowserDialog();

            //Mostramos el diálogo
            DialogResult resultado = dialogo.ShowDialog();

            //Comprobamos si el usuario ha pulsado el botón Aceptar
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                //Accedemos a la ruta seleccionada por el usuario
                string ruta = dialogo.SelectedPath;

                nuevaCategoria.ImagenCategoriaURL = ruta;
            }
        }

        public void vaciarCampos()
        {
            nuevaCategoria = new CATEGORIA();
        }

        public void añadirCategoria()
        {
            if (!BbddService.ExisteCategoria(nuevaCategoria))
            {
                BbddService.AddCategoria(nuevaCategoria);
                MessageBox.Show("Categoría insertada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se ha podido insertar la categoría debido a que ya existe una con el mismo nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool puedeAñadirCategoria()
        {
            return nuevaCategoria.NombreCategoria != "";
        }
    }
}
