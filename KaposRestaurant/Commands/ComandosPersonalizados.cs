using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KaposRestaurant.Commands
{
    public static class ComandosPersonalizados
    {
        public static readonly RoutedUICommand Clear = new RoutedUICommand
            (
                "Clear",
                "Clear",
                typeof(ComandosPersonalizados),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.L, ModifierKeys.Control)
                }
                    
            );

        public static readonly RoutedUICommand Delete = new RoutedUICommand
            (
                "Delete",
                "Delete",
                typeof(ComandosPersonalizados),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.D, ModifierKeys.Control)
                }

            );

        public static readonly RoutedUICommand Update = new RoutedUICommand
            (
                "Update",
                "Update",
                typeof(ComandosPersonalizados),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.U, ModifierKeys.Control)
                }

            );

    }
}
