using Avalonia.Controls;
using Avalonia.Interactivity;

namespace EmployeeManagementApp.Views
{
    public partial class MainWindow : Window
    {
        private readonly EmployeeRepository _repository;
        private readonly EmployeeListView _employeeListView;
        private readonly AddEmployeeView _addEmployeeView;
        private readonly AboutView _aboutView; // Add this line

        public MainWindow()
        {
            InitializeComponent();
            _repository = new EmployeeRepository();
            _repository.InitializeDatabase();
            var contentArea = this.FindControl<ContentControl>("contentArea");

            // Initialize views with contentArea
            _employeeListView = new EmployeeListView(_repository, contentArea);
            _addEmployeeView = new AddEmployeeView(_repository, contentArea);
            _aboutView = new AboutView(); // Initialize AboutView
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

        // Event handler for About button
        private void AboutButton_Click(object? sender, RoutedEventArgs e)
{
    var contentArea = this.FindControl<ContentControl>("contentArea");
    contentArea.Content = new AboutView(); // Show the AboutView when About button is clicked
}
    }
}
