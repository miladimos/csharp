using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DataAccess;
using DataAccess.Models;


namespace ShopManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeDataAccess EmployeeDataAccess = new EmployeeDataAccess();
        CustomerDataAccess CustomerDataAccess = new CustomerDataAccess();
        ProductDataAccess ProductDataAccess = new ProductDataAccess();

        ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();
        ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();
        ObservableCollection<Product> Products = new ObservableCollection<Product>();

        public Employee currentEmployee { get; set; } = new Employee();
        public Customer currentCustomer { get; set; } = new Customer();
        public Product currentProduct { get; set; } = new Product();


        public MainWindow()
        {
            InitializeComponent();

            fillData();
            EmployeesDataGrid.ItemsSource = Employees;
        }

        private void fillData()
        {
            Employees = EmployeeDataAccess.Employees;
            Customers = CustomerDataAccess.Customers;
            Products = ProductDataAccess.Products;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Visible;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Visible;
        }

        private void EmployeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesDataGrid.SelectedItem as Employee;
                EmployeeLabel.Content = currentEmployee.GetBasicInfo();
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployee addEditEmployee = new AddEditEmployee(EmployeeDataAccess);

            addEditEmployee.ShowDialog();
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesDataGrid.SelectedItem as Employee;
                EmployeeDataAccess.RemoveEmployee(currentEmployee.Id);
                EmployeeLabel.Content = "---";
            }
        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedIndex >= 0)
            {
                currentEmployee = EmployeesDataGrid.SelectedItem as Employee;
                AddEditEmployee addEditEmployee = new AddEditEmployee(EmployeeDataAccess, currentEmployee);

                addEditEmployee.ShowDialog();
            }
        }
    }
}
