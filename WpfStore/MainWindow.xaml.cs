using Leah_s_HomeWork.HW10_Store;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal IProductsService servProducts;
        public MainWindow()
        {
            InitializeComponent();
            servProducts = ProductsService.GetInstance();
        }

        /// <summary>
        /// Once When Window is First loaded with all 
        /// Inner Components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Initialization Of GUI WITH DATA
            InitData();
            InitView();
        }



        private void InitData()
        {
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

            //Add categories to list of categories
            servProducts.AddNewCategories(new Category[]{ boys, girls, babies,
                                                               boysClothing, boysShoes,
                                                               girlsClothing, girlsShoes,
                                                               babiesClothing, babiesAccessories });

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

            //Add products to list of products
            servProducts.AddNewProducts(new Product[]{ boysTShirt, boysJeans, boysSweater,
                                                            girlsTShirt, girlsDress, girlsSweater,
                                                            babiesTShirt, babiesOverall, babiesSweater});

        }
        private void InitView()
        {
            //Update CONTROLS With DATA

            //Init ComboBox Categories
            comboCategories.Items.Clear();
            var categories = servProducts.GetSubCategories(0);
            comboCategories.Text = "--Please Choose Categories--";
            comboCategories.ItemsSource = categories;
        }
        private void comboCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idSelected = ((Category)comboCategories.SelectedItem).CategoryId;
            List<Category> subCategories = servProducts.GetSubCategories(idSelected);
            comboSubCategories.ItemsSource = subCategories;


        }
        private void comboSubCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idSelected = ((Category)comboSubCategories.SelectedItem).CategoryId;
            List<Product> listProducts = servProducts.GetProductsCategory(idSelected);
            ListBoxProducts.ItemsSource = listProducts;
        }


        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Product ProductSelected = (Product)ListBoxProducts.SelectedItem;
            servProducts.RemoveProduct(ProductSelected.ProductId);
            List<Product> listProducts = servProducts.GetProductsCategory(ProductSelected.CategoryId);
            ListBoxProducts.ItemsSource = listProducts;



        }

        private void Add_Product_Button_Click(object sender, RoutedEventArgs e)
        {
            if (comboCategories.SelectedItem != null && comboSubCategories.SelectedItem != null)
            {
                int idSelected = ((Category)comboSubCategories.SelectedItem).CategoryId;

                AddNewProduct addNewProduct = new AddNewProduct(idSelected);
                addNewProduct.ShowDialog();

                ListBoxProducts.ItemsSource = null; 
                ListBoxProducts.ItemsSource = servProducts.GetProductsCategory(idSelected);

            }
            else
            {
                MessageBox.Show("please choose category and sub-category to add a product");
            }
        }
    }
}
