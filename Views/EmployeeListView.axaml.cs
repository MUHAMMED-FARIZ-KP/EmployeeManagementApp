using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using System.Collections.Generic; // Add this for List<>
using System.Linq; // Add this for LINQ operations
using Avalonia.Input; // Add this for KeyEventArgs

namespace EmployeeManagementApp.Views
{
    public partial class EmployeeListView : UserControl
    {
        private readonly EmployeeRepository _repository;
        private readonly ContentControl _parentContentArea;
        public ObservableCollection<Employee> Employees { get; private set; }
        private List<Employee> _allEmployees;

        public EmployeeListView(EmployeeRepository repository, ContentControl parentContentArea)
        {
            InitializeComponent();
            _repository = repository;
            _parentContentArea = parentContentArea;
            Employees = new ObservableCollection<Employee>();
            _allEmployees = new List<Employee>();
            RefreshEmployees();
        }

        private void SearchBox_KeyUp(object? sender, KeyEventArgs e)
        {
            ApplySearch();
        }

        private void ClearSearch_Click(object? sender, RoutedEventArgs e)
        {
            var nameSearchBox = this.FindControl<TextBox>("nameSearchBox");
            var departmentSearchBox = this.FindControl<TextBox>("departmentSearchBox");
            
            nameSearchBox.Text = string.Empty;
            departmentSearchBox.Text = string.Empty;
            
            RefreshEmployees();
        }

        private void ApplySearch()
        {
            var nameSearchBox = this.FindControl<TextBox>("nameSearchBox");
            var departmentSearchBox = this.FindControl<TextBox>("departmentSearchBox");
            var employeeGrid = this.FindControl<DataGrid>("employeeGrid");

            var nameFilter = nameSearchBox?.Text?.ToLower() ?? string.Empty;
            var departmentFilter = departmentSearchBox?.Text?.ToLower() ?? string.Empty;

            var filteredEmployees = _allEmployees.Where(e =>
                (string.IsNullOrEmpty(nameFilter) || e.Name.ToLower().Contains(nameFilter)) &&
                (string.IsNullOrEmpty(departmentFilter) || e.Department.ToLower().Contains(departmentFilter))
            ).ToList();

            Employees.Clear();
            foreach (var employee in filteredEmployees)
            {
                Employees.Add(employee);
            }
        }

        private void EditEmployee_Click(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Employee employee)
            {
                var editView = new EditEmployeeView(_repository, employee, () =>
                {
                    RefreshEmployees();
                    _parentContentArea.Content = this;
                });
                _parentContentArea.Content = editView;
            }
        }

        private void DeleteEmployee_Click(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Employee employee)
            {
                _repository.DeleteEmployee(employee.Id);
                RefreshEmployees();
            }
        }

        public void RefreshEmployees()
{
    var employeeGrid = this.FindControl<DataGrid>("employeeGrid");
    _allEmployees = _repository.GetAllEmployees();

    Employees.Clear();
    foreach (var employee in _allEmployees)
    {
        Employees.Add(employee);
    }

    employeeGrid.ItemsSource = Employees;

    int rowHeight = 30; // Height of each row
    int minRows = 10;   // Minimum number of rows to display

    // Calculate the minimum height required for 10 rows
    employeeGrid.MinHeight = minRows * rowHeight;

    // Automatically increase the height of the DataGrid as more entries are added
    employeeGrid.Height = Employees.Count * rowHeight;
}

    }
}