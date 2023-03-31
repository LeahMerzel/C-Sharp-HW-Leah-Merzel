using Leah_s_HomeWork.HW10_Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfStore
{
    /// <summary>
    /// Interaction logic for AddNewProduct.xaml
    /// </summary>
    public partial class AddNewProduct : Window
    {
        public int CategoryId = 0;
        public decimal Price = 0;
        public string ProductName = string.Empty;
        public bool inStock = true;

        internal IProductsService servProducts;
        public AddNewProduct(int categoryId)
        {
            CategoryId = categoryId;
            InitializeComponent();
            servProducts = ProductsService.GetInstance();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void Add_The_Product_Button_Click(object sender, RoutedEventArgs e)
        {
                servProducts.AddNewProduct(ProductName, Price, inStock, CategoryId);
                Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            bool InStock = false;
            if (IsInStockCheckbox.IsChecked==true)
            {
                InStock = true;
            }
        }
        private void NameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductName = NameInput.Text;
        }

        private void PriceInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PriceInput != null)
            {
                bool isDecimal = decimal.TryParse(PriceInput.Text, out decimal price);
                if (isDecimal == true)
                {
                    Price = price;
                }
                else
                {
                    MessageBox.Show("Price should be a number");
                }
            }
        }
    }
}
