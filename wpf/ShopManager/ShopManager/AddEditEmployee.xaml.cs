using DataAccess;
using DataAccess.Models;
using System;
using System.Net;
using System.Windows;


namespace ShopManager
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        private EmployeeDataAccess EmployeeDataAccess;
        private Employee editingEmployee;
        private bool isEdit = false;

        public AddEditEmployee(EmployeeDataAccess employeeDataAccess)
        {
            InitializeComponent();

            EmployeeDataAccess = employeeDataAccess;
        }

        public AddEditEmployee(EmployeeDataAccess employeeDataAccess, Employee employee)
        {
            InitializeComponent();

            EmployeeDataAccess = employeeDataAccess;
            editingEmployee = employee;
            isEdit = true;
            txtFirstName.Text = employee.FirstName;
            txtLastName.Text = employee.LastName;
            txtAddress.Text = employee.Address;
            txtBaseSalary.Text = employee.BaseSalary.ToString();
            txtPhone.Text = employee.PhoneNumber.ToString();
            cmbDepartment.SelectedIndex = (int)employee.Department;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            isValid = CheckEmployeeValidation();

            if (isValid)
            {
                if (isEdit == true)
                {
                    Employee employee = new Employee()
                    {
                        Id = editingEmployee.Id,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Address = txtAddress.Text,
                        PhoneNumber = Convert.ToUInt64(txtPhone.Text),
                        BaseSalary = Convert.ToDecimal(txtBaseSalary.Text),
                        Department = (Department)cmbDepartment.SelectedIndex
                    };

                    EmployeeDataAccess.EditEmployee(employee);
                }
                else
                {
                    Employee employee = new Employee()
                    {
                        Id = EmployeeDataAccess.GetNextId(),
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Address = txtAddress.Text,
                        PhoneNumber = Convert.ToUInt64(txtPhone.Text),
                        BaseSalary = Convert.ToDecimal(txtBaseSalary.Text),
                        Department = (Department)cmbDepartment.SelectedIndex
                    };

                    EmployeeDataAccess.AddEmployee(employee);
                }
                this.Close();
                this.Close();
            }
            else { }


        }

        private bool CheckEmployeeValidation()
        {
            bool isValid = true;



            string FirstName = txtFirstName.Text.Trim().ToLower();
            string LastName = txtLastName.Text.Trim().ToLower();
            string Address = txtAddress.Text.Trim().ToLower();
            string PhoneNumber = txtPhone.Text.Trim().ToLower();
            string BaseSalary = txtBaseSalary.Text.Trim().ToLower();
            int Department = cmbDepartment.SelectedIndex;

            if (string.IsNullOrEmpty(FirstName))
            {
                isValid = false;
                MessageBox.Show("First name is invalid");
            }
            else if (string.IsNullOrEmpty(LastName))
            {
                isValid = false;
                MessageBox.Show("Last name is invalid");
            }
            else if (UInt64.TryParse(PhoneNumber, out ulong a))
            {
                isValid = false;
                MessageBox.Show("Phone invalid");
            }
            else if (Department > 0)
            {
                isValid = false;
                MessageBox.Show("Select a Department");
            }



            return isValid;
        }
    }
}
