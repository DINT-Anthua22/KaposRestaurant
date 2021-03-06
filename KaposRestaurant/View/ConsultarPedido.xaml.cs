﻿using KaposRestaurant.ViewModel;
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
    /// Lógica de interacción para ConsultarPedido.xaml
    /// </summary>
    public partial class ConsultarPedido : UserControl
    {
        public ConsultarPedido()
        {
            this.DataContext = new ConsultarPedidoViewModel();
            InitializeComponent();

           
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ConsultarPedidoViewModel).Actualizar();
            MessageBox.Show("Info: " + "Comandas Actualizadas", "Notificación", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
