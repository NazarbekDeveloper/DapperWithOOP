using Dapper;
using DapperWithOOP;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DapperWithOOP
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("Qaysi table bilan ishlaymiz\n1.Products\n2.Customers\n3.Orders");
            Console.Write(">>> ");
            int tableNumber = int.Parse(Console.ReadLine());
            switch (tableNumber)
            {
                case 1:
                    Console.WriteLine("Qanday vazifa bajaramiz?\n1.GetByID\n2.GetAll\n3.SearchByName");
                    Console.Write(">>> ");
                    int vazifa = int.Parse(Console.ReadLine());
                    switch (vazifa)
                    {
                        case 1:
                            Console.Write("IDni kiriting: ");
                            int productId = Convert.ToInt32(Console.ReadLine());
                            await Products.GetById(productId);
                            break;
                        case 2:
                            _=Products.GetAll();
                            break;
                        case 3:
                            Console.WriteLine("Name ning biror qismini kiriting ");
                            Console.Write(">>> ");
                            string name = Console.ReadLine();
                            await Products.SearchByName(name);
                            break;

                    }
                    break;


            }

        }

    }
}
