

https://github.com/user-attachments/assets/6a718bcf-daaa-450b-9a0e-814b28875e25


# Employee Management Application

This is an Employee Management Application built using Avalonia (.NET) for Windows Desktop. The application helps manage employee records, including adding, viewing, updating, and deleting employee data. It uses a local SQLite database to store the information and provides an intuitive UI design for smooth user experience.

## Features

- **Add Employee**: Allows you to add new employee records with details like name, email, phone number, designation, and date of joining.
- **View Employee**: Displays the list of all employees stored in the database.
- **Update Employee**: Enables updating employee details like name, email, and designation.
- **Delete Employee**: Allows deleting employee records.
- **SQLite Database**: Uses a local SQLite database to store employee data.
- **Intuitive UI**: Easy-to-use interface with Avalonia for a seamless desktop experience.

## Technology Stack

- **Frontend**: Avalonia (.NET)
- **Backend**: C# 
- **Database**: SQLite (for local storage)
- **UI Framework**: Avalonia (cross-platform UI framework for .NET)

## Getting Started

### Prerequisites

To run this application, you need to have the following installed:

- **.NET 6 or later**: [Download here](https://dotnet.microsoft.com/download)
- **SQLite**: SQLite is included in the application, so no additional installation is required.
- **Visual Studio** (Recommended): [Download Visual Studio](https://visualstudio.microsoft.com/)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/MUHAMMED-FARIZ-KP/EmployeeManagementApp.git
    cd EmployeeManagementApp
    ```

2. Restore the required dependencies:

    ```bash
    dotnet restore
    ```

3. Build the project:

    ```bash
    dotnet build
    ```

4. Run the application:

    ```bash
    dotnet run
    ```

The application should now be running on your machine.

## Database Migration

If you need to apply database updates (such as adding new columns), follow these steps:

1. Update the model class to include the new fields.
2. Use Entity Framework migrations or manually update the SQLite database as required.
3. Make sure to apply any necessary changes to the UI to reflect the new database structure.

## Contributing

Contributions are welcome! If you find bugs or have ideas for improvements, feel free to open an issue or create a pull request.


## Contact

For any queries or feedback, please contact [Muhammed Fariz KP](mailto:farizz7676off@gmail.com).
