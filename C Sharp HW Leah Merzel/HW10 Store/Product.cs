using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leah_s_HomeWork.HW10_Store
{
    public class Product : IComparable<Product>
    {
        private static int _counter = 0;
        private static int GetNewCounter()
        {
            _counter += 1;
            return _counter;
        }

        private readonly string prefixId;
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }

        public Product(string prefixId, string name, decimal price, bool inStock, int categoryId)
        {
            ProductId = $"{prefixId}#{GetNewCounter()}";
            this.prefixId = prefixId;
            Name = name;
            Price = price;
            InStock = inStock;
            CategoryId = categoryId;
        }

        public Product(string name, decimal price, bool inStock, int categoryId)
        {
            ProductId = $"{categoryId}#{GetNewCounter()}";
            Name = name;
            Price = price;
            InStock = inStock;
            CategoryId = categoryId;
        }
        public Product()
        {
            ProductId = GetNewCounter().ToString();
        }
        public static Product CopyProductWithNewId(Product exsistingProduct)
        {
            Product copiedProduct = new Product();
            copiedProduct.Name = exsistingProduct.Name;
            copiedProduct.CategoryId = exsistingProduct.CategoryId;
            copiedProduct.Price = exsistingProduct.Price;
            copiedProduct.InStock = exsistingProduct.InStock;
            //what about prefixId?
            return copiedProduct;
        }
        public override string ToString()
        {
            return ProductId + " " + prefixId + " " + Name + " " + Price + " " + InStock + " " + CategoryId;
        }

        public int CompareTo(Product? other)
        {
            // other, then this 
            if (other == null) return 1;
            // order based on name
            return this.Name.CompareTo(other.Name);



        }
    }
}
