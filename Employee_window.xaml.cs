using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using RestaurantModel;
using System.Data.Entity;
using System;
using System.Windows.Input;

namespace Proiect_WPF3
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee_window : Window
    {
        ActionState action = ActionState.Nothing;
        RestaurantEntitiesModel ctx = new RestaurantEntitiesModel();
        CollectionViewSource employeesVSource;
        CollectionViewSource tableordersVSource;
        CollectionViewSource ordersVSource;
        CollectionViewSource orders2VSource;
        CollectionViewSource tableOrdersOrder_ItemsVSource;
        public Employee_window()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            employeesVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
            employeesVSource.Source = ctx.Employees.Local;
            ctx.Employees.Load();
            //System.Windows.Data.CollectionViewSource tableViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // tableViewSource.Source = [generic data source]
            //System.Windows.Data.CollectionViewSource orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // orderViewSource.Source = [generic data source]
        }

        private void employeeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selected_value = (Employee)employeeComboBox.SelectedItem;
            var employee = ctx.Employees.FirstOrDefault(em => em.name == selected_value.name);
            //MessageBox.Show(employee.name);
            tableordersVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableOrdersViewSource")));
            var query2 = from tbl in ctx.Tables
                         join ord in ctx.Orders on tbl.Id equals ord.table_id
                         where tbl.employee_id == employee.Id
                         select new { ord.Id, ord.check_time, ord.first_order, ord.table_id };
            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }
            tableordersVSource.Source = query2.ToList();
            var list = query2.ToList();
            ordersVSource = (System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource"));
            orders2VSource  = (System.Windows.Data.CollectionViewSource)(this.FindResource("order2ViewSource"));
            orders2VSource.Source = ctx.Orders.Local;
            ctx.Orders.Load();
            var query3 = from tbl in ctx.Tables
                         join ord in ctx.Orders on tbl.Id equals ord.table_id
                         where tbl.employee_id == employee.Id
                         select new { ord.Id };
            ordersVSource.Source = query3.ToList();




            /*var query3 = from order in list
                         join ord_item in ctx.Order_Items on order.Id equals ord_item.order_id
                         select new { ord_item.order_id, ord_item.quantity };
            tableOrdersOrder_ItemsVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableOrdersOrder_ItemsViewSource")));
            tableOrdersOrder_ItemsVSource.Source = query3.ToList(); */
        }
        /*private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender,
                                        e.OriginalSource as DependencyObject) as DataGridRow;

            if (row == null) return; 
            var order = ordersDataGrid.SelectedItem;
            string order_string = order.ToString();
            var query3 = from ord in ctx.Orders
                         join item in ctx.Order_Items on ord.Id equals item.order_id
                         where item.order_id == order
                         select new { item.order_id, item.quantity };
            tableOrdersOrder_ItemsVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableOrdersOrder_ItemsViewSource")));
            tableOrdersOrder_ItemsVSource.Source = query3.ToList();

     
        } */

       /* private void ordersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Order selected_value = (Order)ordersComboBox.SelectedItem;
            var order = ctx.Orders.FirstOrDefault(em => em.Id == selected_value.Id);
            //MessageBox.Show(employee.name);
            tableordersVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableOrdersOrder_ItemsViewSource")));
            var query3 = from tbl in ctx.Orders
                         join ord in ctx.Order_Items on tbl.Id equals ord.order_id
                         join item in ctx.Menu_items on ord.menu_id equals item.Id
                         where tbl.Id == order.Id
                         select new { ord.order_id, ord.quantity, ord.menu_id, item.price };
            foreach (var item in query3)
            {
                Console.WriteLine(item);
            }
            tableOrdersOrder_ItemsVSource.Source = query3.ToList();
            var list = query3.ToList();
        }*/

        private void orderComboBox_SelectionChanged(object sender, EventArgs e)
        {
            var selected_value = orderComboBox.SelectedItem;
            Console.WriteLine(selected_value);
            System.Reflection.PropertyInfo pi = selected_value.GetType().GetProperty("Id");
            int Id = Convert.ToInt32(pi.GetValue(selected_value, null));
            Console.WriteLine(Id);
            var order = ctx.Orders.FirstOrDefault(em => em.Id == Id);
            //MessageBox.Show(employee.name);
            tableOrdersOrder_ItemsVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableOrdersOrder_ItemsViewSource")));
            var query3 = from tbl in ctx.Orders
                         join ord in ctx.Order_Items on tbl.Id equals ord.order_id
                         join item in ctx.Menu_items on ord.menu_id equals item.Id
                         where tbl.Id == order.Id
                         select new { ord.order_id, ord.quantity, item.price, item.name, item.Id, sum=ord.quantity*item.price };
            foreach (var item in query3)
            {
                Console.WriteLine(item);
            }
            tableOrdersOrder_ItemsVSource.Source = query3.ToList();
            var list = query3.ToList(); 
        }

        private void btn_next_ord_Click(object sender, RoutedEventArgs e)
        {
            tableordersVSource.View.MoveCurrentToNext();

        }
        private void btn_prev_ord_Click(object sender, RoutedEventArgs e)
        {
            tableordersVSource.View.MoveCurrentToPrevious();

        }
        private void btn_next_ord_it_Click(object sender, RoutedEventArgs e)
        {
            tableOrdersOrder_ItemsVSource.View.MoveCurrentToNext();

        }
        private void btn_prev_ord_it_Click(object sender, RoutedEventArgs e)
        {
            tableOrdersOrder_ItemsVSource.View.MoveCurrentToPrevious();

        }

        private void btn_check_Click(object sender, RoutedEventArgs e)
        {
            int sumf=0;
            var selected_value = orderComboBox.SelectedItem;
            Console.WriteLine(selected_value);
            System.Reflection.PropertyInfo pi = selected_value.GetType().GetProperty("Id");
            int Id = Convert.ToInt32(pi.GetValue(selected_value, null));
            Console.WriteLine(Id);
            var order = ctx.Orders.FirstOrDefault(em => em.Id == Id);
            var query4 = from tbl in ctx.Orders
                         join ord in ctx.Order_Items on tbl.Id equals ord.order_id
                         join item in ctx.Menu_items on ord.menu_id equals item.Id
                         where tbl.Id == order.Id
                         select new { sum = ord.quantity * item.price };
          foreach (var thing in query4)
            {
                sumf+= thing.sum;
            }
            MessageBox.Show("The table's check is: "+sumf.ToString());
            
        }

        private void btn_go_administer_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Administrator();
            newForm.Show();
            this.Close();
        }
    }
}
