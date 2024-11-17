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
        private readonly ContentControl _parentContentArea;  // Added this field

        public AddEmployeeView(EmployeeRepository repository, ContentControl parentContentArea)
        {
            InitializeComponent();
            _repository = repository;
            _parentContentArea = parentContentArea;
        }

        private void BackToMain_Click(object? sender, RoutedEventArgs e)
        {
            // Reset the content to show the welcome message
            _parentContentArea.Content = new TextBlock
            {
                Text = "Welcome to Employee Management System",
                FontSize = 20,
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
            };
        }

        private async void SaveEmployee_Click(object? sender, RoutedEventArgs e)
        {
            var nameTextBox = this.FindControl<TextBox>("nameTextBox");
            var departmentTextBox = this.FindControl<TextBox>("departmentTextBox");
            var dateOfJoinPicker = this.FindControl<DatePicker>("dateOfJoinPicker");
            var messageText = this.FindControl<TextBlock>("messageText");
            
            if (string.IsNullOrWhiteSpace(nameTextBox?.Text) || 
                string.IsNullOrWhiteSpace(departmentTextBox?.Text) || 
                !dateOfJoinPicker?.SelectedDate.HasValue == true)
            {
                messageText!.Text = "Please fill in all fields";
                messageText.Foreground = new SolidColorBrush(Colors.Red);
                await ClearMessageAfterDelay(messageText);
                return;
            }

            var employee = new Employee
            {
                Name = nameTextBox!.Text,
                Department = departmentTextBox!.Text,
                DateOfJoining = dateOfJoinPicker!.SelectedDate!.Value.Date
            };

            _repository.AddEmployee(employee);
            
            // Clear the form
            nameTextBox.Text = string.Empty;
            departmentTextBox.Text = string.Empty;
            dateOfJoinPicker.SelectedDate = null;
            messageText!.Text = "Employee added successfully!";
            messageText.Foreground = new SolidColorBrush(Colors.White);
            await ClearMessageAfterDelay(messageText);
        }

        private async Task ClearMessageAfterDelay(TextBlock messageText)
        {
            await Task.Delay(3000);
            messageText.Text = string.Empty;
        }
    }
}