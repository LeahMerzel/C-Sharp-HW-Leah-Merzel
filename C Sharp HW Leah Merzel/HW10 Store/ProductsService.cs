using C_Sharp_Design_Patterns.Builder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leah_s_HomeWork.HW10_Store
{
    public class ProductsService : IProductsService
    {
        private readonly List<Category> _categories;
        private readonly List<Product> _products;

        private static ProductsService instanceObj = null;
        private ProductsService()
        {
            _categories = new List<Category>();
            _products = new List<Product>();
        }
        public static ProductsService GetInstance()
        {
            if (instanceObj == null)
            {
                instanceObj = new ProductsService();
            }
            return instanceObj;
        }

        /// <returns>The id of the new Category object</returns>
        public Category AddNewCategory(string categoryName, int categoryParentId)
        {
            Category category = new Category(categoryName, categoryParentId);
            _categories.Add(category);
            return category;
        }
        public Category[] AddNewCategories(Category[] categories)
        {
            foreach (Category category in categories)
            {
                _categories.Add(category);
            }
            return _categories.ToArray();
        }

        public Product AddNewProduct(string name, decimal price, bool isinstock, int categoryId)
        {
            Product product = new Product(name, price, isinstock, categoryId);
            _products.Add(product);
            return product;
        }
        public Product[] AddNewProducts(Product[] products, int categoryId)
        {
            Category c = _categories.Find(c => c.CategoryId == categoryId);
            foreach (Product product in products)
                {
                    product.CategoryId = categoryId;
                }
            _products.AddRange(products);
            return _products.ToArray();

        }
        public Product[] AddNewProducts(Product[] products)
        {
            foreach (Product product in products)
            {
                _products.Add(product);
            }
            return _products.ToArray();
        }

        public Product FindProductByName(string productname)
        {
            Product product = null;
            foreach (Product item in _products)
            {
                if (item.Name == productname)
                {
                    product = item;
                }
            }
            return product;
        }

        public List<Product> GetAllProducts()
        {
            //List<Product> products = new List<Product>();
            //foreach (Product originalProduct in _products)
            //{
            //    Product copiedProduct = Product.CopyProductWithNewId(originalProduct);
            //    products.Add(copiedProduct);
            //}
            return _products;
        }
        public List<Product> GetAllProductsByPrice(int lowPrice, int highPrice)
        {
            List<Product> products = new List<Product>();
            foreach (Product item in _products)
            {
                if (lowPrice <= item.Price && item.Price <= highPrice)
                {
                    products.Add(item);
                }
            }
            return products;
        }

        public List<Product> GetAllProductsByPrice(int CategoryId, int lowPrice, int highPrice)
        {
            List<Product> productsInCategory = new List<Product>();
                foreach (Product product in _products)
                {
                    if (product.CategoryId == CategoryId)
                    {
                        if (lowPrice <= product.Price && product.Price <= highPrice)
                        {
                            productsInCategory.Add(product);
                        }
                    }
                }
            productsInCategory.Sort();
            return productsInCategory;
        }

        public List<Category> GetAllTopLevelCategories()
        {
            List<Category> categories = _categories.FindAll(c=> c.ParentCategoryId==0);
            return categories;
        }

        public List<Product> GetProductsCategory(int categoryId)
        {
            List<Product> products = new List<Product>();
            foreach (Product product in _products)
            {
                if (product.CategoryId == categoryId)
                {
                    products.Add(product);
                }
            }
            return products;
        }

        public List<Category> GetSubCategories(int parentCategoryID)
        {
            List<Category> categories = new List<Category>();
            foreach (Category category in _categories)
            {
                if (category.ParentCategoryId == parentCategoryID)
                {
                    categories.Add(category);
                }
            }
            return categories;
        }

        public void RemoveAllProductsOfCategory(int categoryId)
        {
            for (int i = _products.Count - 1; i >= 0; i--)
            {
                if (_products[i].CategoryId == categoryId)
                {
                    _products.RemoveAt(i);
                }
            }
        }

        public void RemoveProduct(string productId)
        {
            Product? result = _products.Find(x => x.ProductId == productId);
            if (result != null)
            {
                _products.Remove(result);
            }
            //foreach (Product product in _products)
            //{
            //    if (product.ProductId == productId)
            //    {
            //        _products.Remove(product);
            //    }
            //}
        }

        public void SaveAllProductsByCategory(int categoryId)
        {
            Category c = _categories.Find(x => x.CategoryId == categoryId);
            string categoryName = c.Name;

            List<Product> products = GetProductsCategory(categoryId);

            string contentToFile = "";
            foreach (Product product in products)
            {
                contentToFile += product.ToString() +"\n";
            }

            System.IO.File.WriteAllText(categoryName + ".txt", contentToFile);

        }

        public void UpdateProduct(string productId, Product newProductInfo)
        {
            // Product toUpdate = null;
            // foreach (Product product in _products)
            // {
            //     if (productId == product.ProductId)
            //     {
            //         toUpdate = product;
            //         break;
            //     }
            // }
            // if (toUpdate == null) { return; }
            // toUpdate.Name = newProductInfo.Name;
            //// ...

            //Product? result = _products.Find(x => x.Id == productId);
            //if (result != null)
            //{
            //    result = newProductInfo;
            //}

            foreach (Product product in _products)
            {
                if (productId == product.ProductId)
                {
                    product.ProductId = newProductInfo.ProductId;
                    product.Name = newProductInfo.Name;
                    product.CategoryId = newProductInfo.CategoryId;
                    product.Price = newProductInfo.Price;
                    product.InStock = newProductInfo.InStock;
                }
            }


        }

    }
}
