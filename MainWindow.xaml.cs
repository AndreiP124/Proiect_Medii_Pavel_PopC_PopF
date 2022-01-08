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

namespace Proiect_WPF3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
public partial class MainWindow : Window
    {
        
        public MainWindow()
        {   
            InitializeComponent();
            CommandBinding cmb1 = new CommandBinding();
            cmb1.Command = CustomCommands.Shortcut.Launch;
            cmb1.Executed += new ExecutedRoutedEventHandler(btn_administrator_Click);
            this.CommandBindings.Add(cmb1);
        }

        private void btn_employee_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Employee_window();
            newForm.Show();
            this.Close();
        }

        private void btn_administrator_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Administrator();
            newForm.Show();
            this.Close();
        }
    }
}
