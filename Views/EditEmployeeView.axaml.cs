using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace EmployeeManagementApp.Views
{
    public partial class EditEmployeeView : UserControl
    {
        private readonly EmployeeRepository _repository;
        private readonly Action _onUpdateComplete;
        private Employee _employee;

        public EditEmployeeView(EmployeeRepository repository, Employee employee, Action onUpdateComplete)
        {
            InitializeComponent();
            _repository = repository;
            _employee = employee;
            _onUpdateComplete = onUpdateComplete;

            // Populate the form
            var nameTextBox = this.FindControl<TextBox>("nameTextBox");
            var departmentTextBox = this.FindControl<TextBox>("departmentTextBox");

            nameTextBox.Text = employee.Name;
            departmentTextBox.Text = employee.Department;
        }

        private void SaveChanges_Click(object? sender, RoutedEventArgs e)
        {
            var nameTextBox = this.FindControl<TextBox>("nameTextBox");
            var departmentTextBox = this.FindControl<TextBox>("departmentTextBox");

            _employee.Name = nameTextBox.Text;
            _employee.Department = departmentTextBox.Text;

            _repository.UpdateEmployee(_employee);
            _onUpdateComplete?.Invoke();
        }

        private void Cancel_Click(object? sender, RoutedEventArgs e)
        {
            _onUpdateComplete?.Invoke();
        }
        private void BackToMain_Click(object? sender, RoutedEventArgs e)
{
    _onUpdateComplete?.Invoke();
}
    }
}