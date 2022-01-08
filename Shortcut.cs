using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Proiect_WPF3.CustomCommands

{
    class Shortcut
    {
        private static RoutedUICommand launch_command;
        static Shortcut()
        {
            InputGestureCollection myInputGestures = new InputGestureCollection();
            myInputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Alt));
            launch_command = new RoutedUICommand("Launch", "Launch", typeof(Shortcut), myInputGestures);


        }
        public static RoutedUICommand Launch
        {
            get
            {
                return launch_command;
            }
        }
    }
}
