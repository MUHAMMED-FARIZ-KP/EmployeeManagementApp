using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;


namespace EmployeeManagementApp.Views
{
    public partial class EmployeeListView : UserControl
    {
        private readonly EmployeeRepository _repository;
        private readonly ContentControl _parentContentArea;
        public ObservableCollection<Employee> Employees { get; private set; }

        public EmployeeListView(EmployeeRepository repository, ContentControl parentContentArea)
        {
            InitializeComponent();
            _repository = repository;
            _parentContentArea = parentContentArea;
            Employees = new ObservableCollection<Employee>();
            RefreshEmployees();
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
    Employees.Clear();

    foreach (var employee in _repository.GetAllEmployees())
    {
        Employees.Add(employee);
    }

    employeeGrid.ItemsSource = Employees;

    // Set the minimum height of the DataGrid
    int rowHeight = 30; // Height for each row in pixels
    int minRows = 3; // Minimum number of rows to display initially
    int maxRows = 10; // Maximum number of rows before scrolling starts

    // Calculate the heights based on row count
    employeeGrid.MinHeight = (minRows + 1) * rowHeight; // +1 for the header row
    employeeGrid.MaxHeight = (maxRows + 1) * rowHeight; // +1 for the header row

    // If the number of employees exceeds the maxRows, the DataGrid will become scrollable
}

    }
}