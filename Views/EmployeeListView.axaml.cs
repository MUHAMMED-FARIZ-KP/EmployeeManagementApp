using Avalonia.Controls;
using System.Collections.ObjectModel;

namespace EmployeeManagementApp.Views
{
    public partial class EmployeeListView : UserControl
    {
        private readonly EmployeeRepository _repository;
        public ObservableCollection<Employee> Employees { get; private set; }

        public EmployeeListView(EmployeeRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            Employees = new ObservableCollection<Employee>();
            RefreshEmployees();
        }

        public void RefreshEmployees()
        {
            var employeeGrid = this.FindControl<DataGrid>("employeeGrid");
            Employees.Clear();
            foreach (var employee in _repository.GetAllEmployees())
            {
                Employees.Add(employee);
            }
            employeeGrid.ItemsSource = Employees;

            // Set the height of the DataGrid based on the number of employees
            int rowHeight = 30; // Assuming each row is 30 pixels high
            employeeGrid.Height = (Employees.Count + 1) * rowHeight; // +1 for the header row
        }
    }
}