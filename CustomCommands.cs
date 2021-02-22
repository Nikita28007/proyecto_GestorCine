using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace proyecto_GestorCine
{
    class CustomCommands
    {
        public static readonly RoutedUICommand editarSesion = new RoutedUICommand
            (
                 "Editar sesiones",
                  "Edit sessions",
                  typeof(CustomCommands),
                  new InputGestureCollection()
                  {
                       new KeyGesture(Key.E,ModifierKeys.Control)

                  }

        );

        public static readonly RoutedUICommand pay = new RoutedUICommand
            (
                 "pagar enrada",
                  "pay entrance",
                  typeof(CustomCommands),
                  new InputGestureCollection()
                  {
                       new KeyGesture(Key.G,ModifierKeys.Control)

                  }

        );

        public static readonly RoutedUICommand help = new RoutedUICommand
            (
                 "Ayuda",
                  "Help",
                  typeof(CustomCommands),
                  new InputGestureCollection()
                  {
                       new KeyGesture(Key.F1)

                  }

        );

    }
}
