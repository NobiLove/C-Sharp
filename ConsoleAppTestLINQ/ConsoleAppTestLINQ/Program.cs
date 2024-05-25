using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleAppTestLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BikeStoresEntities dbContext = new BikeStoresEntities();
            bool salir = false;

            while (!salir)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("1. List products");
                    Console.WriteLine("2. List brands");
                    Console.WriteLine("3. List categories");
                    Console.WriteLine("4. List all");
                    Console.WriteLine("Choose an option and press enter");
                    Console.WriteLine("---------------------------------------------");
                    int opcion = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Products:");
                            var query1 = from product in dbContext.products
                                         select new { Name = product.product_name, Year = product.model_year };
                            foreach (var item in query1)
                            {
                                Console.WriteLine($"NAME: {item.Name}, YEAR: {item.Year}");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Brands:");
                            var query2 = from brand in dbContext.brands
                                         select new { Name = brand.brand_name };
                            foreach (var item in query2)
                            {
                                Console.WriteLine($"NAME: {item.Name}");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Categories");
                            var query3 = from category in dbContext.categories
                                         select new { Name = category.category_name };
                            foreach (var item in query3)
                            {
                                Console.WriteLine($"NAME: {item.Name}");
                            }
                            break;
                        case 4:
                            Console.WriteLine("All data");
                            var query4 = from product in dbContext.products
                                         join brand in dbContext.brands on product.brand_id equals brand.brand_id
                                         join category in dbContext.categories on product.category_id equals category.category_id
                                         select new { Name = product.product_name, Year = product.model_year, Brand = brand.brand_name, Category = category.category_name };
                            foreach (var item in query4)
                            {
                                Console.WriteLine($"NAME: {item.Name}, YEAR: {item.Year}, BRAND: {item.Brand}, CATEGORY: {item.Category}");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Exiting from app");
                            salir = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong option");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
