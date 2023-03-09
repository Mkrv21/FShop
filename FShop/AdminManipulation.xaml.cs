using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AdminManipulation.xaml
    /// </summary>
    public partial class AdminManipulation : Window
    {
        private Product _currentProduct = new Product();
        public AdminManipulation(Product selectedProduct)
        {
            InitializeComponent();
            if (selectedProduct != null)
                _currentProduct = selectedProduct;

            DataContext = selectedProduct;

            if (_currentProduct.Image != null)
            {
                ImageR.Source = LoadImage(_currentProduct.Image);
            }
        }
        private string imagepath = "";
        private void ChangePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (openDialog.ShowDialog() == true)
            {
                imagepath = openDialog.FileName;
                ImageR.Source = new BitmapImage(new Uri(openDialog.FileName));
            }
        }
        public static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ( NameTB.Text == "" || QuTB.Text == "" || PriceTB.Text == "")
            {
                MessageBox.Show("Not all fields are filled in!");
                return;
            }

            if (_currentProduct == null)
            {
                _currentProduct = new Product() { Quantity = Convert.ToInt32(QuTB.Text), Description = DescTb.Text, Price = Convert.ToInt32(PriceTB.Text), Name = NameTB.Text };
            }
            else
            {
                _currentProduct.Name = NameTB.Text;
                _currentProduct.Quantity = Convert.ToInt32(QuTB.Text);
                _currentProduct.Description = DescTb.Text;
                _currentProduct.Price = Convert.ToInt32(PriceTB.Text);
            }
            if (imagepath != "")
                _currentProduct.Image = File.ReadAllBytes(imagepath);
            if (_currentProduct.Id == 0)
                DbflowerShopContext.GetContext().Products.Add(_currentProduct);
            try
            {
                DbflowerShopContext.GetContext().SaveChanges();
                MessageBox.Show("Information is saved!");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


            //string Name = NameTB.Text.Trim();
            //int Quantity = Convert.ToInt32(QuTB.Text.Trim());
            //int Cost = Convert.ToInt32(PriceTB.Text.Trim());
            //string Description = DescTb.Text.Trim();

            //using (DbflowerShopContext db = new DbflowerShopContext())
            //{
            //    var product = db.Products.FirstOrDefault(x => x.Name == NameTB.Text || x.Quantity == Convert.ToInt32(QuTB.Text) || x.Price == Convert.ToInt32(PriceTB.Text));
            //    if (product != null)
            //    {
            //        MessageBox.Show("Такой товар уже существует!");
            //    }
            //    if (imagepath != "")
            //        _currentProduct.Image = File.ReadAllBytes(imagepath);
            //    Product productadd = new Product
            //    {

            //        Name = NameTB.Text,
            //        Quantity = Convert.ToInt32(QuTB.Text),
            //        Price = Convert.ToInt32(PriceTB.Text),
            //        Description = DescTb.Text,

            //    };


            //    db.Products.Add(productadd);
            //    db.SaveChanges();
            //    MessageBox.Show("Товар успешно добавлен!");
            //    AdminCatalog catalogAdminWindow = new AdminCatalog();
            //    catalogAdminWindow.Show();
            //    Hide();
        
        }
    }
}
