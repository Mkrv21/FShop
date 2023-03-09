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

namespace FShop
{
    /// <summary>
    /// Логика взаимодействия для AdminCatalog.xaml
    /// </summary>
    public partial class AdminCatalog : Window
    {
        public AdminCatalog()
        {
            InitializeComponent();
            AdminCatalogList.ItemsSource = DbflowerShopContext.GetContext().Products.ToList();
        }

       

        private void AdminCatalog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminManipulation adminManipulation = new AdminManipulation((sender as Button).DataContext as Product);
            adminManipulation.ShowDialog();
            AdminCatalogList.ItemsSource = DbflowerShopContext.GetContext().Products.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var productsForRemoving = AdminCatalogList.SelectedItems.Cast<Product>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {productsForRemoving.Count()}элемента(ов)?", "Внимание",
             MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    DbflowerShopContext.GetContext().Products.RemoveRange(productsForRemoving);
                    DbflowerShopContext.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    AdminCatalogList.ItemsSource = DbflowerShopContext.GetContext().Products.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AdminManipulation adminManipulation = new AdminManipulation(AdminCatalogList.SelectedItem as Product);
            adminManipulation.ShowDialog();
            AdminCatalogList.ItemsSource = DbflowerShopContext.GetContext().Products.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            this.Close();
            orders.Show();
        }
    }
}
