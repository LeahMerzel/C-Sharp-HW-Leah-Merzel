using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leah_s_HomeWork.HW10_Store
{
    interface IProductsService
    {
        Category AddNewCategory(string categoryName, int categoryParentId);
        Product AddNewProduct(string name, decimal price, bool isinstock, int categoryId);
        Product[] AddNewProducts(Product[] products, int categoryId);
        void RemoveProduct(string productId);
        void UpdateProduct(string productId, Product newProductInfo);
        List<Category> GetAllTopLevelCategories();
        List<Category> GetSubCategories(int parentCategoryID);
        List<Product> GetProductsCategory(int categoryId);
        List<Product> GetAllProductsByPrice(int lowPrice, int highPrice);
        List<Product> GetAllProductsByPrice(int inCategoryId, int lowPrice, int highPrice);
        List<Product> GetAllProducts();
        Product FindProductByName(string productname);
        void RemoveAllProductsOfCategory(int categoryId);
        void SaveAllProductsByCategory(int categoryId);
        void printToConsole();
    }
}
