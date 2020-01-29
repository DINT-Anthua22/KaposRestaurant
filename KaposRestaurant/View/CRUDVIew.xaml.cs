using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
    public partial class CRUDVIew : UserControl
    {
        public CRUDVIew()
        {
            this.DataContext = new ViewModel.CrudVM(Accion.Nuevo);
            InitializeComponent();
        }

        private void CommandBindingSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBindingSave_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((ViewModel.CrudVM)this.DataContext).CategoriaSeleccionada != null;
        }

        private void CommandBindingUpdate_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBindingUpdate_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((ViewModel.CrudVM)this.DataContext).ElementoSeleccionado != null;
        }

        private void CommandBindingDelete_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBindingDelete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((ViewModel.CrudVM)this.DataContext).ElementoSeleccionado != null;
        }

        private void CommandBindingClear_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBindingClear_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void AñadirElementoButton_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModel.CrudVM)this.DataContext).CambiaAccion(Accion.Nuevo);
        }

        private void ModificarElementoButton_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModel.CrudVM)this.DataContext).CambiaAccion(Accion.Editar);
        }

        private void EliminarElementoButton_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModel.CrudVM)this.DataContext).CambiaAccion(Accion.Borrar);
        }

        private void AceptarCambiosButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LimpiarCamposButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SeleccionImagenElementoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
