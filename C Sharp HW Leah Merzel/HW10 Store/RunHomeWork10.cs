using C_Sharp_HW_Leah_Merzel.HW10_Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Leah_s_HomeWork.HW10_Store

{
    public class RunHomeWork10
    {
        public static void RunStore()
        {
            //Product boysTshirtColors = new Product { Name = "T-Shirt-Colors", Price = 39, InStock = true, CategoryId = boysClothingId };
            //productsService.UpdateProduct(boysTshirt.ProductId, boysTshirtColors);
            //List<Category> storeCategories = new List<Category>();
            //storeCategories = productsService.GetAllTopLevelCategories();//ok, right? (also next)
            //List<Category> subCategories = new List<Category>();
            //subCategories.ForEach(c => c.ParentCategoryId = babiesCategoryId);
            //subCategories = productsService.GetSubCategories(0);
            //List<Product> productsInCategory = new List<Product>();
            //productsInCategory = productsService.GetProductsCategory(boysClothingId);
            //List<Product> productsPrice = new List<Product>();
            //productsPrice = productsService.GetAllProductsByPrice(25, 85);
            //List<Product> categoryProductsPrice = new List<Product>();
            //categoryProductsPrice = productsService.GetAllProductsByPrice(boysClothingId, 25, 85);
            //List<Product> storeProducts = new List<Product>();
            //storeProducts = productsService.GetAllProducts();
            //Product foundProduct = productsService.FindProductByName("T-Shirt-Colors");
            //int babiesShoesId = productsService.AddNewCategory("Babies Shoes", babiesCategoryId);
            //productsService.SaveAllProductsByCategory(girlsCategoryId);
            //productsService.printToConsole();
            //productsService.RemoveProduct(boysTshirt.ProductId);
            //productsService.RemoveAllProductsOfCategory(babiesClothingId);
            //Menu.ShowMenu();

            //Create Top Level categories
            Category boys = new Category("Boys", 0);
            Category girls = new Category("Girls", 0);
            Category babies = new Category("Babies", 0);

            //Create Sub categories
            Category boysClothing = new Category("Boys' Clothing", boys.CategoryId);
            Category boysShoes = new Category("Boys' Shoes", boys.CategoryId);

            Category girlsClothing = new Category("Girls' Clothing", girls.CategoryId);
            Category girlsShoes = new Category("Girls' Shoes", girls.CategoryId);

            Category babiesClothing = new Category("Babies' Clothing", babies.CategoryId);
            Category babiesAccessories = new Category("Babies' Accessories", babies.CategoryId);

            //Create products in Sub Categories
            Product boysTShirt = new Product("Boys' T-Shirt", 39, true, boysClothing.CategoryId);
            Product boysJeans = new Product("Boys' Jeans", 70, true, boysClothing.CategoryId);
            Product boysSweater = new Product("Boys' Sweater", 65, true, boysClothing.CategoryId);

            Product girlsTShirt = new Product("Girls' T-Shirt", 39, true, girlsClothing.CategoryId);
            Product girlsDress = new Product("Girls' Dress", 80, true, girlsClothing.CategoryId);
            Product girlsSweater = new Product("Girls' Sweater", 65, true, girlsClothing.CategoryId);

            Product babiesTShirt = new Product("Babies' T-Shirt", 29, true, babiesClothing.CategoryId);
            Product babiesOverall = new Product("Babies' OverAll", 55, true, babiesClothing.CategoryId);
            Product babiesSweater = new Product("Babies' Sweater", 50, true, babiesClothing.CategoryId);

            //Create SingleTon IProductService
            IProductsService ps = ProductsService.GetInstance();

            //Add categories to list of categories
            Category[] categories = new Category[]{ boys, girls, babies,
                                      boysClothing, boysShoes,
                                      girlsClothing, girlsShoes,
                                      babiesClothing, babiesAccessories };
            ps.AddNewCategories(categories);
           

            //Add products to list of products
            Product[] products = { boysTShirt, boysJeans, boysSweater,
                                   girlsTShirt, girlsDress, girlsSweater,
                                   babiesTShirt, babiesOverall, babiesSweater};
            ps.AddNewProducts(products);

            //test all productService methods
            //tets AddNewCategory()
            Category toys = ps.AddNewCategory("Childrens' Toys", 0);

            //test AddNewProduct()
            Product blocks = ps.AddNewProduct("Blocks", 99, true, toys.CategoryId);

            //test AddNewProducts()
            Product magnets = ps.AddNewProduct("Magnets", 120, true, toys.CategoryId);
            Product duplo = ps.AddNewProduct("Duplo", 75, true, toys.CategoryId);
            Product[] ChildrensToys = new Product[3] { blocks, magnets, duplo };
            ps.AddNewProducts(ChildrensToys, toys.CategoryId);

            //test FindProductByName()
            Console.WriteLine("test FindProductByName()");
            Product foundProduct = ps.FindProductByName("Duplo");
            Console.WriteLine(foundProduct+"\n");

            //test GetAllTopLevelCategories()
            Console.WriteLine("test GetAllTopLevelCategories()");
            var storeCategories = ps.GetAllTopLevelCategories();
            storeCategories.ForEach(storeCategories => Console.WriteLine(storeCategories + "\n"));

            //test RemoveAllProductsOfCategory()
            Console.WriteLine("\ntest RemoveAllProductsOfCategory()");
            ps.RemoveAllProductsOfCategory(babiesClothing.CategoryId);

            //test tets GetSubCategories() and GetProductsCategory()
            Console.WriteLine("tets GetSubCategories() \n and GetProductsCategory()");
            foreach (Category storeCategory in storeCategories)
            {
                var storeSubCategories = ps.GetSubCategories(storeCategory.CategoryId);
                storeSubCategories.ForEach(storeSubCategories => Console.WriteLine(storeSubCategories + "\n"));

                foreach (Category subCategory in storeSubCategories)
                {
                    var categoryProducts = ps.GetProductsCategory(subCategory.CategoryId);
                    categoryProducts.ForEach(categoryProducts => Console.WriteLine(categoryProducts));
                }
            }

            //test GetAllProducts()
            Console.WriteLine("\n test GetAllProducts()");
            List<Product> storeProducts = ps.GetAllProducts();
            storeProducts.ForEach(Console.WriteLine);

            //test GetAllProductsByPrice()
            Console.WriteLine("\n test GetAllProductsByPrice()");
            List<Product> storeProductsInPriceRange = ps.GetAllProductsByPrice(25, 80);
            storeProductsInPriceRange.ForEach(Console.WriteLine);

            //test GetAllProductsByPrice() in a specific Category
            Console.WriteLine("\n test GetAllProductsByPrice() in a specific Category");
            List<Product> CategoryProductsInRange = ps.GetAllProductsByPrice(boysClothing.CategoryId, 25, 80);
            CategoryProductsInRange.ForEach(Console.WriteLine);



            Product mockBlocks = new Product("Blocks", 100, true, toys.CategoryId);
            ps.RemoveProduct(mockBlocks.ProductId);
            Product updatedBlocks = new Product("Blocks", 100, true, toys.CategoryId);
            ps.UpdateProduct(blocks.ProductId, updatedBlocks);










        }
    }
}
