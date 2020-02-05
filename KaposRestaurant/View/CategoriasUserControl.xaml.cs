using KaposRestaurant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KaposRestaurant.View
{
    /// <summary>
    /// Lógica de interacción para CategoriasUserControl.xaml
    /// </summary>
    public partial class CategoriasUserControl : System.Windows.Controls.UserControl
    {
        public CategoriasUserControl()
        {
            this.DataContext = new CategoriasViewModel();
            InitializeComponent();
        }

        private void SaveBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {

                (this.DataContext as CategoriasViewModel).añadirCategoria();
                this.DataContext = new CategoriasViewModel();

                System.Windows.Forms.MessageBox.Show("Categoría insertada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("No se ha podido insertar la categoría debido a que ya existe una con el mismo nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((this.DataContext as CategoriasViewModel).puedeAñadirCategoria())
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void ClearBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            (this.DataContext as CategoriasViewModel).vaciarCampos();
            this.DataContext = new CategoriasViewModel();
        }

        private void DeleteBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                (this.DataContext as CategoriasViewModel).borrarCategoria();

                System.Windows.Forms.MessageBox.Show("Categoría eliminada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("No se puede eliminar la categoría debido a que contiene elementos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((this.DataContext as CategoriasViewModel).puedeBorrarCategoria())
                e.CanExecute = true;
            else
                e.CanExecute = false;

        }

        private void SeleccionarImagenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos de imágenes|*.jpg;*.png";

            DialogResult resultado = dialogo.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                string fileName = dialogo.FileName;

                (this.DataContext as CategoriasViewModel).seleccionarImagen(fileName);
            }
        }
    }
}
