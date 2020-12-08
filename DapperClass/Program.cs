using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            // ------- READ -------
            Console.WriteLine("Would you like to see all the departments?");
            var userInput = Console.ReadLine();
            Console.WriteLine();
            var dept_repo = new DapperDepartmentRepository(conn);

            if (userInput.ToLower() == "yes")
            {
                var depts = dept_repo.GetAllDepartments();

                foreach (var dept in depts)
                {
                    Console.WriteLine(dept.Name);
                }
            }

            // ------- CREATE -------
            Console.WriteLine("Would you like to add a department? yes or no");
            userInput = Console.ReadLine();
            Console.WriteLine();
            var deptName = "";
            if (userInput.ToLower() == "yes")
            {
                Console.WriteLine("What is the new department's name?");
                deptName = Console.ReadLine();
                dept_repo.InsertDepartment(deptName);
                Console.WriteLine("Would you like to see the Departments list again? yes or no");
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "yes")
                {
                    foreach (var dept in dept_repo.GetAllDepartments())
                    {
                        Console.WriteLine($"{dept.Name} - {dept.DepartmentID}");
                    }
                }
            }
            Console.WriteLine();

            

            // ------- UPDATE -------
            Console.WriteLine("Would you like to update a department? yes or no");
            userInput = Console.ReadLine();
            Console.WriteLine();
            if (userInput.ToLower() == "yes")
            {
                Console.WriteLine("What is the department's new name?");
                deptName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine($"What is the department's ID?");
                Console.WriteLine();
                var deptID = int.Parse(Console.ReadLine());
                dept_repo.UpdateDepartment(deptName, deptID);

                Console.WriteLine("Would you like to refresh the table?");
                userInput = Console.ReadLine();
                Console.WriteLine();

            }

            // ------- DELETE -------
            Console.WriteLine("Would you like to delete a department? yes or no");
            userInput = Console.ReadLine();
            Console.WriteLine();
                
            if (userInput.ToLower() == "yes")
            {
                foreach (var dept in dept_repo.GetAllDepartments())
                {
                    Console.WriteLine($"{dept.Name} - {dept.DepartmentID}");
                }

                Console.WriteLine();
                Console.WriteLine("What is the ID of the department you would like to delete?");
                Console.WriteLine();
                var deleteThis = int.Parse(Console.ReadLine());
                dept_repo.DeleteDepartment(deleteThis);

                Console.WriteLine("Would you like to see the departments list again?");
                if (userInput.ToLower() == "yes")
                {
                    foreach (var dept in dept_repo.GetAllDepartments())
                    {
                        Console.WriteLine($"{dept.Name} - {dept.DepartmentID}");
                    }
                }
            }

            //------- READ -------
            Console.WriteLine("Would you like to see all the products?");
            userInput = Console.ReadLine();
            Console.WriteLine();
            var prod_repo = new DapperProductRepository(conn);

            if (userInput.ToLower() == "yes")
            {
                var prods = prod_repo.GetAllProducts();

                foreach (var prod in prods)
                {
                    Console.WriteLine();
                    Console.WriteLine(prod.Name);
                }
            }

            // ------ CREATE ------
            Console.WriteLine("Would you like to add a product? yes or no");
            userInput = Console.ReadLine();
            Console.WriteLine();
            var productName = "";
            if (userInput.ToLower() == "yes")
            {
                Console.WriteLine("What is the new product's ID?");
                var productID = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("What is the new product's name?");
                productName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("What is the new product's price?");
                var price = double.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("What is the new product's category ID?");
                var categoryID = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("What is the new product's on sale status? 0 or 1");
                var onSale = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("What is the new product's stock level?");
                var stockLevel = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Would you like to see the Products list again? yes or no");
                userInput = Console.ReadLine();
                Console.WriteLine();

                if (userInput.ToLower() == "yes")
                {
                    prod_repo.CreateProduct(productID, productName, price, categoryID, onSale, stockLevel);
                }

                if (userInput.ToLower() == "yes")
                {
                    foreach (var prod in prod_repo.GetAllProducts())
                    {
                        Console.WriteLine($"{prod.Name} - {prod.ProductID}");
                    }
                }
            }
            
            // ------- UPDATE -------
            Console.WriteLine("Would you like to update a product? yes or no");
            userInput = Console.ReadLine();
            Console.WriteLine();
            if (userInput.ToLower() == "yes")
            {
                Console.WriteLine($"What is the product's ID?");
                Console.WriteLine();
                var productID = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("What is the product's new name?");
                productName = Console.ReadLine();
                Console.WriteLine();         
                Console.WriteLine($"What is the product's price?");
                Console.WriteLine();
                var price = double.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine($"What is the product's category ID? Choose 1 through 10");
                Console.WriteLine();
                var categoryID = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine($"What is the product's on sale status? 0 or1");
                var onSale = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine($"What is the product's stock level?");
                var stockLevel = int.Parse(Console.ReadLine());
                Console.WriteLine();
                prod_repo.UpdateProduct(productID, productName, price, categoryID, onSale, stockLevel);

                Console.WriteLine("Would you like to refresh the table? yes or no");
                userInput = Console.ReadLine();
                Console.WriteLine();

                if (userInput.ToLower() == "yes")
                {
                    prod_repo.UpdateProduct(productID, productName, price, categoryID, onSale, stockLevel);
                }

                if (userInput.ToLower() == "yes")
                {
                    foreach (var prod in prod_repo.GetAllProducts())
                    {
                        Console.WriteLine($"{prod.Name} - {prod.ProductID}");
                    }
                }
            }


            // ------- DELETE -------
            Console.WriteLine("Would you like to delete a product? yes or no");
            userInput = Console.ReadLine();
            Console.WriteLine();

            if (userInput.ToLower() == "yes")
            {
                foreach (var prod in prod_repo.GetAllProducts())
                {
                    Console.WriteLine($"{prod.Name} - {prod.ProductID}");
                }

                Console.WriteLine();
                Console.WriteLine("What is the ID of the product you would like to delete?");
                Console.WriteLine();
                var deleteThis = int.Parse(Console.ReadLine());
                prod_repo.DeleteProduct(deleteThis);

                Console.WriteLine("Would you like to see the products list again?");
                if (userInput.ToLower() == "yes")
                {
                    foreach (var prod in prod_repo.GetAllProducts())
                    {
                        Console.WriteLine($"{prod.Name} - {prod.ProductID}");
                    }
                }
            }
        }
    }
}
