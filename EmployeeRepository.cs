using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;


namespace EmployeeManagementApp
{
    public class EmployeeRepository
    {
        private const string ConnectionString = "Data Source=employees.db";

        public void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Employees (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Department TEXT NOT NULL
                    )";
                command.ExecuteNonQuery();
            }
        }

        public void AddEmployee(Employee employee)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    INSERT INTO Employees (Name, Department)
                    VALUES ($name, $department);
                    SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("$name", employee.Name ?? string.Empty);
                command.Parameters.AddWithValue("$department", employee.Department ?? string.Empty);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    employee.Id = Convert.ToInt32(result);
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Department FROM Employees";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Department = reader.GetString(2)
                        });
                    }
                }
            }
            return employees;
        }
        public void DeleteEmployee(int id)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Employees WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
        }
    }

    public void UpdateEmployee(Employee employee)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE Employees 
                SET Name = $name, Department = $department
                WHERE Id = $id";
            command.Parameters.AddWithValue("$name", employee.Name ?? string.Empty);
            command.Parameters.AddWithValue("$department", employee.Department ?? string.Empty);
            command.Parameters.AddWithValue("$id", employee.Id);
            command.ExecuteNonQuery();
        }
    }
    }
}