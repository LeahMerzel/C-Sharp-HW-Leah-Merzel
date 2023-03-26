using Leah_s_HomeWork.HW10_Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_HW_Leah_Merzel.HW10_Store
{
    public class Menu
    {
        public static void ShowMenu()
        {
            bool isContinue = true;
            while (isContinue)
            {
                isContinue = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            ProductsService productsService = ProductsService.GetInstance();

            Console.Clear();
            Console.WriteLine("Choose an option and press Enter:");
            Console.WriteLine("1) Get All Top Level Categories");
            Console.WriteLine("2) Get Sub-Categories in a Category");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    List<Category> topLevelCategories = productsService.GetAllTopLevelCategories();
                    topLevelCategories.ForEach(category => { Console.WriteLine(category); });
                    Console.ReadKey();
                    return true;
                case "2":
                    Console.WriteLine("Choose a Category");
                    Console.WriteLine("1) Boys");
                    Console.WriteLine("2) Girls");
                    Console.WriteLine("3) Babies");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            List<Category> BoysSubCategories = productsService.GetSubCategories(1);
                            BoysSubCategories.ForEach(category => { Console.WriteLine(category.Name); });
                            Console.Write("Press Any Key To Continue");
                            Console.ReadKey();
                            break;
                        case "2":
                            List<Category> GirlsSubCategories = productsService.GetSubCategories(2);
                            GirlsSubCategories.ForEach(category => { Console.WriteLine(category.Name); });
                            Console.Write("Press Any Key To Continue");
                            Console.ReadKey();
                            break;
                        case "3":
                            List<Category> babiesSubCategories = productsService.GetSubCategories(3);
                            babiesSubCategories.ForEach(category => { Console.WriteLine(category.Name); });
                            Console.Write("Press Any Key To Continue");
                            Console.ReadKey();
                            break;
                    }
                    return true;
                case "3":                 
                    List<Product>productsInCategory = productsService.GetProductsCategory(1);
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }
}
