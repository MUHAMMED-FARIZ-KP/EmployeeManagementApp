using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Views
{
    public partial class AddEmployeeView : UserControl
    {
        private readonly EmployeeRepository _repository;

        public AddEmployeeView(EmployeeRepository repository)
        {
            InitializeComponent();
            _repository = repository;
        }

        private async void SaveEmployee_Click(object? sender, RoutedEventArgs e)
        {
            var nameTextBox = this.FindControl<TextBox>("nameTextBox");
            var departmentTextBox = this.FindControl<TextBox>("departmentTextBox");
            var messageText = this.FindControl<TextBlock>("messageText");

            if (string.IsNullOrWhiteSpace(nameTextBox?.Text) || string.IsNullOrWhiteSpace(departmentTextBox?.Text))
            {
                messageText.Text = "Please fill in all fields";
                messageText.Foreground = new SolidColorBrush(Colors.Red);  // Set red color for error message
                await ClearMessageAfterDelay(messageText);
                return;
            }
            var dateOfJoinPicker = this.FindControl<DatePicker>("dateOfJoinPicker");
            var employee = new Employee
            {
                Name = nameTextBox.Text,
                Department = departmentTextBox.Text,
            };

            _repository.AddEmployee(employee);

            // Clear the form
            nameTextBox.Text = string.Empty;
            departmentTextBox.Text = string.Empty;
            messageText.Text = "Employee added successfully!";
            messageText.Foreground = new SolidColorBrush(Colors.White); // Set white color for success message
            await ClearMessageAfterDelay(messageText);
        }

        private async Task ClearMessageAfterDelay(TextBlock messageText)
        {
            await Task.Delay(3000);
            messageText.Text = string.Empty;
        }
    }
}
