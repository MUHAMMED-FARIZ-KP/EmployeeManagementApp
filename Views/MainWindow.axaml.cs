using Avalonia.Controls;
using Avalonia.Interactivity;

namespace EmployeeManagementApp.Views
{
    public partial class MainWindow : Window
    {
        private readonly EmployeeRepository _repository;
        private readonly EmployeeListView _employeeListView;
        private readonly AddEmployeeView _addEmployeeView;

        public MainWindow()
{
    InitializeComponent();
    _repository = new EmployeeRepository();
    _repository.InitializeDatabase();

    var contentArea = this.FindControl<ContentControl>("contentArea");
    
    // Initialize views
    _employeeListView = new EmployeeListView(_repository, contentArea);
    _addEmployeeView = new AddEmployeeView(_repository);
}

        private void ViewEmployees_Click(object? sender, RoutedEventArgs e)
        {
            var contentArea = this.FindControl<ContentControl>("contentArea");
            _employeeListView.RefreshEmployees(); // Refresh the list
            contentArea.Content = _employeeListView;
        }

        private void AddEmployee_Click(object? sender, RoutedEventArgs e)
        {
            var contentArea = this.FindControl<ContentControl>("contentArea");
            contentArea.Content = _addEmployeeView;
        }
    }
}