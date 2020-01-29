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
    public partial class CategoriasUserControl : UserControl
    {
        public CategoriasUserControl()
        {
            InitializeComponent();
            CategoriasListBox.DataContext = new CategoriasViewModel();
        }

        private void SaveBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            (this.DataContext as CategoriasViewModel).añadirCategoria();
        }

        private void SaveBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            (this.DataContext as CategoriasViewModel).puedeAñadirCategoria();
        }

        private void ClearBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            (this.DataContext as CategoriasViewModel).vaciarCampos();
        }

        private void DeleteBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            (this.DataContext as CategoriasViewModel).borrarCategoria();
        }

        private void DeleteBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            (this.DataContext as CategoriasViewModel).puedeBorrarCategoria();
        }

        private void SeleccionarImagenButton_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as CategoriasViewModel).seleccionarImagen();
        }
    }
}
