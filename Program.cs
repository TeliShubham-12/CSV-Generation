using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using Entity;
    
            List<Employee> data = new List<Employee>
            {
                new Employee { Name = "John", Age = 25, City = "New York" },
                new Employee { Name = "Alice", Age = 30, City = "London" },
                new Employee { Name = "Bob", Age = 22, City = "Paris" }
            };

            // File path to save the CSV file
            string filePath = "C:/Users/shree/Desktop/CSVGeneration/CSV.csv";

            // Display existing data
            DisplayData(data);

            // Add new data
            AddData(data, "Eve", "28", "Berlin");
            AddData(data, "Steve", "28", "Berlin");

            // Remove data
            RemoveData(data, "Alice", 30, "London");

            // Regenerate CSV with updated data
            GenerateCSV(filePath, data);

            // Display updated data
            DisplayData(data);

            Console.WriteLine("CSV file updated successfully.");
        

        static void AddData(List<Employee> data, string name, string age, string city)
        {
            // Create a new Employee object with the provided data
            Employee newEmployee = new Employee
            {
                Name = name,
                Age = int.Parse(age), // Assuming age is an integer
                City = city
            };

            // Add the new Employee object to the data list
            data.Add(newEmployee);
        }

        static void RemoveData(List<Employee> data, string name, int age, string city)
        {
            // Find and remove the specified employee from the data list
            Employee employeeToRemove = data.Find(emp => emp.Name == name && emp.Age == age && emp.City == city);

            if (employeeToRemove != null)
            {
                data.Remove(employeeToRemove);
                Console.WriteLine("Employee removed successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        

            
        }

        // Rest of the methods remain unchanged...



        static void DisplayData(List<Employee> data)
        {
            Console.WriteLine("Current Data:");

            foreach (var employee in data)
            {
                Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, City: {employee.City}");
            }

            Console.WriteLine("Data Displayed Successfully");
        }

        static void GenerateCSV(string filePath, List<Employee> data)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    // Writing header
                    sw.WriteLine("Name, Age, City");

                    // Writing data
                    foreach (var employee in data)
                    {
                        sw.WriteLine($"{employee.Name}, {employee.Age}, {employee.City}");
                    }

                    Console.WriteLine("CSV File Generated Successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    

      EmailService.SendEmailWithAttachment("your_email@gmail.com", "your_password", "recipient_email@example.com", "CSV File Attachment", "Please find the attached CSV file.", filePath);

            Console.WriteLine("CSV file updated and email sent successfully.");

