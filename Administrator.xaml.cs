using RestaurantModel;
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
using System.Windows.Shapes;
using System.Data.Entity;
using System.Data;


namespace Proiect_WPF3
{
    /// <summary>
    /// Interaction logic for Administrator.xaml
    /// </summary>
     enum ActionState
    {
        New,
        Edit,
        Delete,
         Nothing
    }
public partial class Administrator : Window
    {
        ActionState action = ActionState.Nothing;
        RestaurantEntitiesModel ctx = new RestaurantEntitiesModel();
        CollectionViewSource employeesVSource;
        CollectionViewSource tablesVSource;
        
        CollectionViewSource order_ItemsVSource;
        CollectionViewSource orderVSource;
        public Administrator()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            employeesVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
            employeesVSource.Source = ctx.Employees.Local;
            ctx.Employees.Load();
            tablesVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableViewSource")));
            tablesVSource.Source = ctx.Tables.Local;
            ctx.Tables.Load();
            order_ItemsVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("order_ItemsViewSource")));
            order_ItemsVSource.Source = ctx.Order_Items.Local;
            ctx.Order_Items.Load();
            orderVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
            orderVSource.Source = ctx.Orders.Local;
            ctx.Orders.Load();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
            BindingOperations.ClearBinding(nameTextBox, TextBox.TextProperty);
            SetValidationBinding();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
            BindingOperations.ClearBinding(nameTextBox, TextBox.TextProperty);
            SetValidationBinding();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }

        private void btn_next_emp_Click(object sender, RoutedEventArgs e)
        {
            employeesVSource.View.MoveCurrentToNext();
        }

        private void btn_prev_emp_Click(object sender, RoutedEventArgs e)
        {
            employeesVSource.View.MoveCurrentToPrevious();
        }
        private void btn_next_tbl_Click(object sender, RoutedEventArgs e)
        {
            tablesVSource.View.MoveCurrentToNext();
        }

        private void btn_prev_tbl_Click(object sender, RoutedEventArgs e)
        {
            tablesVSource.View.MoveCurrentToPrevious();
        }
        private void btn_prev_orders_Click(object sender, RoutedEventArgs e)
        {
            orderVSource.View.MoveCurrentToPrevious();
        }


        private void SaveEmployees()
        {
            Employee employee = null;
            if (action==ActionState.New)
            {
                try
                {
                    employee = new Employee()
                    {
                        shift = shiftTextBox.Text.Trim(),
                        name = nameTextBox.Text.Trim(),
                        job = jobTextBox.Text.Trim()

                    };
                    ctx.Employees.Add(employee);
                    employeesVSource.View.Refresh();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else 
                if (action==ActionState.Edit)
            {
                try
                {
                    employee = (Employee)employeeDataGrid.SelectedItem;
                    employee.name = nameTextBox.Text.Trim();
                    employee.job = jobTextBox.Text.Trim();
                    employee.shift = seatsTextBox.Text.Trim();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action==ActionState.Delete)
            {
                try
                {
                    employee = (Employee)employeeDataGrid.SelectedItem;
                    ctx.Employees.Remove(employee);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                employeesVSource.View.Refresh();
            }
        }
        private void SaveOrders()
        {
            Order order = null;
            if (action == ActionState.New)
            {
                try
                {
                    order = new Order()
                    {
                        
                        check_time = TimeSpan.Parse(check_timeTextBox.Text.Trim()),
                        first_order = TimeSpan.Parse(first_orderTextBox.Text.Trim()),
                        table_id=Convert.ToInt32(table_idTextBox.Text.Trim())

                    };
                    ctx.Orders.Add(order);
                    employeesVSource.View.Refresh();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                if (action == ActionState.Edit)
            {
                try
                {
                    order = (Order)orderDataGrid.SelectedItem;
                    order.check_time = TimeSpan.Parse(check_timeTextBox.Text.Trim());
                    order.first_order = TimeSpan.Parse(first_orderTextBox.Text.Trim());
                    order.table_id = Convert.ToInt32(table_idTextBox.Text.Trim());
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    order = (Order)orderDataGrid.SelectedItem;
                    ctx.Orders.Remove(order);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                orderVSource.View.Refresh();
            }
        }
        private void SaveOrder_items()
        {
            Order_Items order_item = null;
            if (action == ActionState.New)
            {
                try
                {
                    order_item = new Order_Items()
                    {

                        menu_id = Convert.ToInt32(menu_idTextBox.Text.Trim()),
                        order_id = Convert.ToInt32(order_idTextBox.Text.Trim()),
                        quantity = Convert.ToInt32(quantityTextBox.Text.Trim())

                    };
                    ctx.Order_Items.Add(order_item);
                    order_ItemsVSource.View.Refresh();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                if (action == ActionState.Edit)
            {
                try
                {
                    order_item = (Order_Items)order_ItemsDataGrid.SelectedItem;
                    order_item.menu_id = Convert.ToInt32(menu_idTextBox.Text.Trim());
                    order_item.order_id = Convert.ToInt32(order_idTextBox.Text.Trim());
                    order_item.quantity = Convert.ToInt32(quantityTextBox.Text.Trim());
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    order_item = (Order_Items)order_ItemsDataGrid.SelectedItem;
                    ctx.Order_Items.Remove(order_item);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                order_ItemsVSource.View.Refresh();
            }
        }
        private void SaveTables()
        {
            RestaurantModel.Table table = null;
            if (action == ActionState.New)
            {
                try
                {
                    table = new RestaurantModel.Table()
                    {
                        seats = Convert.ToInt32(seatsTextBox.Text.Trim()),
                        availability = Convert.ToInt32(availabilityTextBox.Text.Trim()),
                        location = locationTextBox.Text.Trim(),
                        employee_id=Convert.ToInt32(employee_idTextBox.Text.Trim())

                    };
                    ctx.Tables.Add(table);
                    tablesVSource.View.Refresh();
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                if (action == ActionState.Edit)
            {
                try
                {
                    table = (RestaurantModel.Table)tableDataGrid.SelectedItem;
                    table.seats = Convert.ToInt32(seatsTextBox.Text.Trim());
                    table.availability = Convert.ToInt32(availabilityTextBox.Text.Trim());
                    table.location = locationTextBox.Text.Trim();
                    table.employee_id = Convert.ToInt32(employee_idTextBox.Text.Trim());
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    table = (RestaurantModel.Table)tableDataGrid.SelectedItem;
                    ctx.Tables.Remove(table);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                tablesVSource.View.Refresh();
            }
        }
        private void ReInitialize()
        {
            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlAdmin.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Employees":
                    SaveEmployees();
                    break;
                case "Tables":
                    SaveTables();
                    break;
                case "Orders":
                    SaveOrders();
                    break;
                case "Order_Items":
                    SaveOrder_items();
                    break;
            }
            ReInitialize();
        }
        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;
            foreach(Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }

        private void btn_next_orders_Click(object sender, RoutedEventArgs e)
        {
            orderVSource.View.MoveCurrentToNext();
        }

        private void btn_next_item_Click(object sender, RoutedEventArgs e)
        {
            order_ItemsVSource.View.MoveCurrentToNext();

        }
        private void btn_item_prev_Click(object sender, RoutedEventArgs e)
        {
            order_ItemsVSource.View.MoveCurrentToPrevious();

        }

        private void btn_redirect_check_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Employee_window();
            newForm.Show();
            this.Close();
        }
        private void SetValidationBinding()
        {
            Binding nameValidationBinding = new Binding();
            nameValidationBinding.Source = employeesVSource;
            nameValidationBinding.Path = new PropertyPath("name");
            nameValidationBinding.NotifyOnValidationError = true;
            nameValidationBinding.Mode = BindingMode.TwoWay;
            nameValidationBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            nameValidationBinding.ValidationRules.Add(new StringNotEmpty());
            nameTextBox.SetBinding(TextBox.TextProperty, nameValidationBinding);
        }
    }
}
