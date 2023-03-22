using C_Sharp_HW_Leah_Merzel.HW10_Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leah_s_HomeWork.HW10_Store

{
    public class RunHomeWork10
    {
        public static void RunStore()
        {
            ProductsService productsService = ProductsService.GetInstance();
            int boysCategoryId = productsService.AddNewCategory("Boys", 0);
            int girlsCategoryId = productsService.AddNewCategory("Girls", 0);
            int babiesCategoryId = productsService.AddNewCategory("Babies", 0);
            int boysClothingId = productsService.AddNewCategory("Clothing", boysCategoryId);
            int boysShoesId = productsService.AddNewCategory("Shoes", boysCategoryId);
            int girlsClothingId = productsService.AddNewCategory("Clothing", girlsCategoryId);
            int girlsShoesId = productsService.AddNewCategory("Shoes", girlsCategoryId);
            int babiesClothingId = productsService.AddNewCategory("Clothing", babiesCategoryId);
            int babiesAccessoriesId = productsService.AddNewCategory("Accessories", babiesCategoryId);
            Product boysTshirt = productsService.AddNewProduct("T-Shirt", 39, true, boysClothingId);
            Product boysJeans = productsService.AddNewProduct("Jeans", 60, true, boysClothingId);
            Product boysSocks = productsService.AddNewProduct("Socks", 7, true, boysClothingId);
            Product boysSneakers = productsService.AddNewProduct("Sneakers", 35, true, boysShoesId);
            Product boysBoots =  productsService.AddNewProduct("Boots", 50, true, boysShoesId);
            Product boysSchoolShoes = productsService.AddNewProduct("SchoolShoes", 89, true, boysShoesId);
            Product girlsShirt = productsService.AddNewProduct("Shirt", 35, true, girlsClothingId);
            Product girlsSkirt = productsService.AddNewProduct("Skirt", 55, true, girlsClothingId);
            Product girlsDress = productsService.AddNewProduct("Dress", 120, true, girlsClothingId);
            Product girlsSneakers = productsService.AddNewProduct("Sneakers", 35, true, girlsShoesId);
            Product girlsBoots = productsService.AddNewProduct("Boots", 50, true, girlsShoesId);
            Product girlsSchoolShoes = productsService.AddNewProduct("SchoolShoes", 89, true, girlsShoesId);
            Product babiesShirt = productsService.AddNewProduct("Shirt", 35, true, babiesClothingId);
            Product babiesLeggings = productsService.AddNewProduct("Leggings", 35, true, babiesClothingId);
            Product babiesOverall = productsService.AddNewProduct("Overall", 60, true, babiesClothingId);
            Product babyPacifier = productsService.AddNewProduct("Pacifier", 12, true, 9);
            productsService.RemoveProduct(babyPacifier.ProductId);
            Product babyBottle = productsService.AddNewProduct("Bottle", 34, true, 9);
            productsService.RemoveProduct(babyBottle.ProductId);
            Product babyBlanket = productsService.AddNewProduct("Blanket", 49, true, 9);
            productsService.RemoveProduct(babyBlanket.ProductId);
            Product[] babyAccessories = new Product[3] { babyPacifier , babyBottle , babyBlanket };
            productsService.AddNewProducts(babyAccessories, babiesAccessoriesId);
            Product boysTshirtColors = new Product { Name = "T-Shirt-Colors", Price = 39, InStock = true, CategoryId = boysClothingId };
            productsService.UpdateProduct(boysTshirt.ProductId, boysTshirtColors);
            List<Category> storeCategories = new List<Category>();
            storeCategories = productsService.GetAllTopLevelCategories();//ok, right? (also next)
            List<Category> subCategories = new List<Category>();
            subCategories.ForEach(c => c.ParentCategoryId = babiesCategoryId);
            subCategories = productsService.GetSubCategories(0);
            List<Product> productsInCategory = new List<Product>();
            productsInCategory = productsService.GetProductsCategory(boysClothingId);
            List<Product> productsPrice = new List<Product>();
            productsPrice = productsService.GetAllProductsByPrice(25, 85);
            List<Product> categoryProductsPrice = new List<Product>();
            categoryProductsPrice = productsService.GetAllProductsByPrice(boysClothingId, 25, 85);
            List<Product> storeProducts = new List<Product>();
            storeProducts = productsService.GetAllProducts();
            Product foundProduct = productsService.FindProductByName("T-Shirt-Colors");
            int babiesShoesId = productsService.AddNewCategory("Babies Shoes", babiesCategoryId);
            productsService.SaveAllProductsByCategory(girlsCategoryId);
            productsService.printToConsole();
            productsService.RemoveProduct(boysTshirt.ProductId);
            productsService.RemoveAllProductsOfCategory(babiesClothingId);
            Menu.ShowMenu();






        }
    }
}
