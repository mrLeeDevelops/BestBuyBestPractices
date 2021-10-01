using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            #endregion

            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);
            Console.WriteLine("Hello user! Here are the current departments.");
            Console.WriteLine("Please press ENTER. . .");
            Console.ReadLine();

            var depos = repo.GetAllDepartments();
            Print(depos);
            Console.WriteLine("Do you want to add a department?");
            string userResponse = Console.ReadLine();

            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of you r new department?");
                userResponse = Console.ReadLine();

                repo.InsertDepartment(userResponse);
                Print(repo.GetAllDepartments());
            }

            Console.WriteLine("Have a great day!");

            //-------------------------------------------------------------------------------

            DapperProductsRepository repo2 = new DapperProductsRepository(conn);
            Console.WriteLine("Hello user! Here are the current products.");
            Console.WriteLine("Please press ENTER. . .");
            Console.ReadLine();

            var depos2 = repo2.GetAllProducts();
            Print2(depos2);
            Console.WriteLine("Do you want to add a product?");
            userResponse = Console.ReadLine();

            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new product?");
                var prodName = Console.ReadLine();

                Console.WriteLine("What is the categoryID of your new product?");
                var catID = int.Parse(Console.ReadLine());

                Console.WriteLine("What is the price of your new product?");
                var cost = double.Parse(Console.ReadLine());

                repo2.CreateProduct(prodName, cost, catID);
                Print2(repo2.GetAllProducts());
            }

            Console.WriteLine("Have a great day!");
        }
    
        private static void Print(IEnumerable<Department> depos)
        {
                foreach (var depo in depos)
                {
                Console.WriteLine($"ID:  {depo.DepartmentId}  Name:  {depo.Name}");

                }
        }

        private static void Print2(IEnumerable<Products> depos2)
        {
            foreach (var depo in depos2)
            {
                Console.WriteLine($"CategoryID:  {depo.CategoryID}  Name:  {depo.Name}  Price:  {depo.Price}");

            }
        }
    }
}
