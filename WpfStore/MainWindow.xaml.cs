using Leah_s_HomeWork.HW10_Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            this.servProducts.AddNewCategories(new Category[]{ boys, girls, babies,
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
            this.servProducts.AddNewProducts(new Product[]{ boysTShirt, boysJeans, boysSweater,
                                                            girlsTShirt, girlsDress, girlsSweater,
                                                            babiesTShirt, babiesOverall, babiesSweater});

        }
        private void InitView()
        {
            //Update CONTROLS With DATA

            //Init ComboBox Categories
            comboCategories.Items.Clear();
            var categories = servProducts.GetSubCategories(0);
            /*for (int i = 0; i < categories.Count; i++)
            {
                comboCategories.Items.Add(categories[i].Name);
            }
            comboCategories.Items.Insert(0, "--Please Choose Categories--");*/
            comboCategories.Text = "--Please Choose Categories--";
            comboCategories.ItemsSource = categories;
            //comboCategories.SelectedIndex = 0;

        }

                //var subCategories = servProducts.GetSubCategories(categories[i].CategoryId);
                //for (int j = 0; j<subCategories.Count; j++)
                //{
                //    comboSubCategories.Items.Add(subCategories[j].Name);
                //}
                //comboSubCategories.Items.Insert(0, "--Please Choose a SubCategory--");
                //comboSubCategories.SelectedIndex = 0;


    private void comboCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idSelected = ((Category)comboCategories.SelectedItem).CategoryId;
            List<Category> subCategories = servProducts.GetSubCategories(idSelected);
            this.comboSubCategories.ItemsSource = subCategories;



            //string categorySelected = comboCategories.SelectedItem.ToString();
            //var categories = servProducts.GetSubCategories(0);
            //Category found = categories.Find(c => c.Name == categorySelected);
            //if (found != null)
            //{
            //    int idSelected = found.CategoryId;
            //    List<Category> subCategories = servProducts.GetSubCategories(idSelected);
            //    this.comboSubCategories.ItemsSource = subCategories;
            //  //  List<Product> listProducts = servProducts.GetProductsCategory(idSelected);
            //  //  this.ListBoxProducts.ItemsSource = listProducts;
            //}


        }
        //private void InitViewSub()
        //{

        //    //Init ComboBox Sub-Categories
        //    comboSubCategories.Items.Clear();

        //    var subCategories = servProducts.GetSubCategories();
        //    for (int i = 0; i < subCategories.Count; i++)
        //    {
        //        comboSubCategories.Items.Add(subCategories[i].Name);
        //    }
        //    comboSubCategories.Items.Insert(0, "--Please Choose a SubCategory--");
        //    comboSubCategories.SelectedIndex = 0;
        //}


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
            AddNewProduct dialog = new AddNewProduct();
            dialog.ShowDialog();


        }
    }
}
