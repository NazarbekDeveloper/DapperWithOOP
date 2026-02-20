using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperWithOOP
{
    public static class Products
    {
        public static async Task GetById(int productId)
        {
            string? connectionString =
                                      "Server=BEKZALATOY\\MSSQLSERVER01;" +
                                      "Database=NorthWindDb;" +
                                      "Integrated Security=True;" +
                                      "TrustServerCertificate=True;";
            IDbConnection ulanish = new SqlConnection(connectionString);

            string sqlQuery =
                """
                select * from Products
                where ProductID = @productId;
                """;

            Product? product = await ulanish.QueryFirstOrDefaultAsync<Product>(sqlQuery, new { productId });

            Console.WriteLine($"ProductId: {product.ProductId} ");
            Console.WriteLine($"ReorderLevel: {product.ReorderLevel}");
            Console.WriteLine($"Discontinued: {product.Discontinued}");
            Console.WriteLine($"ProductName: {product.ProductName} ");
            Console.WriteLine($"SupplierId: {product.SupplierId}");
            Console.WriteLine($"CategoryId: {product.CategoryId}");
            Console.WriteLine($"QuantityPerUnit: {product.QuantityPerUnit}");
            Console.WriteLine($"UnitPrice: {product.UnitPrice}");
            Console.WriteLine($"UnitsInStock: {product.UnitsInStock}");
            Console.WriteLine($"UnitsOnOrder: {product.UnitsOnOrder}");
            Console.WriteLine();
        }
        public static async Task GetAll()
        {
            string? connectionString =
                                  "Server=BEKZALATOY\\MSSQLSERVER01;" +
                                  "Database=NorthWindDb;" +
                                  "Integrated Security=True;" +
                                  "TrustServerCertificate=True;";
            IDbConnection ulanish = new SqlConnection(connectionString);
            string sqlQuery =
                    """
                    select * from Products;
                    """;
            IEnumerable<Product> products = await ulanish.QueryAsync<Product>(sqlQuery);
            foreach (var product in products)
            {
                Console.WriteLine($"ProductId: {product.ProductId} ");
                Console.WriteLine($"ReorderLevel: {product.ReorderLevel}");
                Console.WriteLine($"Discontinued: {product.Discontinued}");
                Console.WriteLine($"ProductName: {product.ProductName} ");
                Console.WriteLine($"SupplierId: {product.SupplierId}");
                Console.WriteLine($"CategoryId: {product.CategoryId}");
                Console.WriteLine($"QuantityPerUnit: {product.QuantityPerUnit}");
                Console.WriteLine($"UnitPrice: {product.UnitPrice}");
                Console.WriteLine($"UnitsInStock: {product.UnitsInStock}");
                Console.WriteLine($"UnitsOnOrder: {product.UnitsOnOrder}");
                Console.WriteLine();
            }
        }
        public static async Task SearchByName(string name)
        {
            string? connectionString =
                                 "Server=BEKZALATOY\\MSSQLSERVER01;" +
                                 "Database=NorthWindDb;" +
                                 "Integrated Security=True;" +
                                 "TrustServerCertificate=True;";
            IDbConnection ulanish = new SqlConnection(connectionString);
            string sqlQuery =
                    """
                    select ProductName from Products
                    where ProductName LIKE '%@name%';
                    """;
            IEnumerable<string> productNames = await ulanish.QueryAsync<string>(sqlQuery, new { name });
            foreach(string productName in productNames)
            {
                Console.WriteLine($"ProductName: {productName}");
            }
        }
    }
}
