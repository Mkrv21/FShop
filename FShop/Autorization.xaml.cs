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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int DUser;
        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            this.Close();
            reg.Show();
        }

        

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Log_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Log_ent.Focus();
        }

        private void Log_ent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Log_ent.Text) && Log_ent.Text.Length > 0)
            {
                Log.Visibility = Visibility.Collapsed;
            }
            else
            {
                Log.Visibility = Visibility.Visible;
            }
        }

        private void Pass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Pass_ent.Focus();
        }

        

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(Log_ent.Text) && !string.IsNullOrEmpty(Pass_ent.Password))
            //{
            //    MessageBox.Show("Successfully Signed In");
            //}
            string login = Log_ent.Text.Trim();
            string password = Pass_ent.Password.Trim();
            if (login.Length < 5)
            {
                Log_ent.ToolTip = "Please enter a valid login!";
                Log_ent.Background = Brushes.LightCoral;
                
            }
            else
            {
                Log_ent.ToolTip = "";
                Log_ent.Background = Brushes.Transparent;

                if (password.Length < 5)
                {
                    
                    
                    
                    Log_ent.ToolTip = "Please enter a valid password!";
                    Pass_ent.Background = Brushes.LightCoral;
                }
                else
                {
                    Pass_ent.ToolTip = "";
                    Pass_ent.Background = Brushes.Transparent;

                    using (DbflowerShopContext context = new DbflowerShopContext())
                    {
                        foreach (User authUser in context.Users)
                        {
                            if (Log_ent.Text == authUser.Login && Pass_ent.Password == authUser.Password && authUser.Role == "Admin")
                            {
                                if (authUser.Role == "Admin")
                                {
                                    AdminCatalog admincatalog = new AdminCatalog();
                                    admincatalog.Show();
                                    Hide();
                                    return;
                                }
                            }

                            else if (Log_ent.Text == authUser.Login && Pass_ent.Password == authUser.Password && authUser.Role == "Client")
                            {
                                if (authUser.Role == "Client")
                                {
                                    DUser = (int)authUser.Id;
                                    Catalog catalog = new Catalog();
                                    catalog.Show();
                                    Hide();
                                    return;

                                }
                            }


                        }

                    }
                    MessageBox.Show("Invalid login or password!");

                }

            }


        }

        private void Pass_ent_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Pass_ent.Password) && Pass_ent.Password.Length > 0)
            {
                Pass.Visibility = Visibility.Collapsed;
            }
            else
            {
                Pass.Visibility = Visibility.Visible;
            }
        }
    }
}
