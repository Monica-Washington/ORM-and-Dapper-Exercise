using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            
            var departmentRepo = new DapperDepartmentRespository(conn);
            
            departmentRepo.InsertDepartment("Best Buy New Department");
            
            var departments = departmentRepo.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentId);
                Console.WriteLine(department.Name);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("_______________");
            }
            
            var productRepository = new DapperProductRepository(conn);
            var products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductId);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OneSale);
                Console.Write(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }


        }
    }
}
