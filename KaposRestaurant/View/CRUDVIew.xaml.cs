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
    /// Lógica de interacción para CRUDVIew.xaml
    /// </summary>
    public partial class CRUDVIew : System.Windows.Controls.UserControl
    {
        public CRUDVIew()
        {
            this.DataContext = new ViewModel.CrudVM(Accion.Nuevo);
            InitializeComponent();
        }

        //***************
        //CRUD
        private void CommandBindingSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int respuesta = ((ViewModel.CrudVM)this.DataContext).Save_Execute();

            switch (respuesta)
            {
                case -1:
                    System.Windows.MessageBox.Show("No se ha podido realizar la acción", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                    break;

                case 0:
                    System.Windows.MessageBox.Show("Acción cancelada", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                case 1:
                    System.Windows.MessageBox.Show("Elemento creado correctamente", "Insertar", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                case 2:
                    System.Windows.MessageBox.Show("Elemento modificado correctamente", "Editar", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                case 3:
                    System.Windows.MessageBox.Show("Elemento eliminado correctamente", "Eliminar", MessageBoxButton.OK, MessageBoxImage.Information);

                    break;

            }

             ((ViewModel.CrudVM)this.DataContext).LimpiaCampos();
        }

        private void CommandBindingSave_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            if (((ViewModel.CrudVM)this.DataContext).GetAccion() == Accion.Nuevo)
            {
                e.CanExecute = ((ViewModel.CrudVM)this.DataContext).CategoriaSeleccionada != null;
            }
            else
            {
                e.CanExecute = ((ViewModel.CrudVM)this.DataContext).CategoriaSeleccionada != null && ((ViewModel.CrudVM)this.DataContext).ElementoSeleccionado != null;
            }

        }

        //***************
        //LIMPIAR CAMPOS
        private void CommandBindingClear_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((ViewModel.CrudVM)this.DataContext).LimpiaCampos();
        }

        private void CommandBindingClear_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((ViewModel.CrudVM)this.DataContext).ElementoSeleccionado != null;
        }

        private void AñadirElementoButton_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModel.CrudVM)this.DataContext).LimpiaCampos();
            CRUDGroupBox.Header = "Añadir Elemento";
            AceptarCambiosButton.Content = "Añadir Elemento";
            HacerVisibleInvisible(false);
            ((ViewModel.CrudVM)this.DataContext).CambiaAccion(Accion.Nuevo);
        }

        private void ModificarElementoButton_Click(object sender, RoutedEventArgs e)
        {
            CRUDGroupBox.Header = "Modificar Elemento";
            AceptarCambiosButton.Content = "Modificar Elemento";
            HacerVisibleInvisible(true);
            ((ViewModel.CrudVM)this.DataContext).CambiaAccion(Accion.Editar);
        }

        private void EliminarElementoButton_Click(object sender, RoutedEventArgs e)
        {
            CRUDGroupBox.Header = "Eliminar Elemento";
            AceptarCambiosButton.Content = "Eliminar Elemento";
            HacerVisibleInvisible(true);
            ((ViewModel.CrudVM)this.DataContext).CambiaAccion(Accion.Borrar);
        }

        private void SeleccionImagenElementoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogoImagen = new OpenFileDialog();

            dialogoImagen.InitialDirectory = "c://";
            dialogoImagen.Filter = "Imágenes JPG (*.jpg)|*.jpg|Imágenes PNG (*.png)|*.png|Todos los archivos (*.*)|*.*";

            dialogoImagen.FilterIndex = 3;

            dialogoImagen.RestoreDirectory = true;

            if (dialogoImagen.ShowDialog() == DialogResult.OK)
            {
                string ruta = "";

                ruta = dialogoImagen.FileName;

                ((ViewModel.CrudVM)this.DataContext).SeleccionarImagen(ruta);
            }
        }

        private void HacerVisibleInvisible(bool visible)
        {

            if (visible)
            {
                ElementoCRUDComboBox.Visibility = Visibility.Visible;
                SeleccionElementoLabel.Visibility = Visibility.Visible;
            }
            else
            {
                ElementoCRUDComboBox.Visibility = Visibility.Collapsed;
                SeleccionElementoLabel.Visibility = Visibility.Collapsed;

            }
        }

        private void CategoriasCRUDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ViewModel.CrudVM)this.DataContext).CambiaAccion(((ViewModel.CrudVM)this.DataContext).GetAccion());
        }
    }
}
