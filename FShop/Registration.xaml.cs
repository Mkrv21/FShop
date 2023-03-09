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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

     

        private void Pass_reg_PasswordChanged_1(object sender, RoutedEventArgs e)
        {

        }

        

        private void Log_reg_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Log_reg.Text) && Log_reg.Text.Length > 0)
            {
                Log.Visibility = Visibility.Collapsed;
            }
            else
            {
                Log.Visibility = Visibility.Visible;
            }
        }

        private void Fullname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Fullname_txtb.Text) && Fullname_txtb.Text.Length > 0)
            {
                Fulln.Visibility = Visibility.Collapsed;
            }
            else
            {
                Fulln.Visibility = Visibility.Visible;
            }
        }

        private void Fuln_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Fullname_txtb.Focus();
        }

        private void Log_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Log_reg.Focus();
        }

        private void Em_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Email_txtb.Focus();
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Email_txtb.Text) && Email_txtb.Text.Length > 0)
            {
                Em.Visibility = Visibility.Collapsed;
            }
            else
            {
                Em.Visibility = Visibility.Visible;
            }
        }

        private void Ph_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Phone_txtb.Focus();
        }

        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Phone_txtb.Text) && Phone_txtb.Text.Length > 0)
            {
                Ph.Visibility = Visibility.Collapsed;
            }
            else
            {
                Ph.Visibility = Visibility.Visible;
            }
        }

        private void Pass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Pass_reg.Focus();
        }

        private void Pass_reg_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Pass_reg.Password) && Pass_reg.Password.Length > 0)
            {
                Pass.Visibility = Visibility.Collapsed;
            }
            else
            {
                Pass.Visibility = Visibility.Visible;
            }
        }

        private void PassSec_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PassSec_reg.Focus();
        }

        private void PassSec_reg_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PassSec_reg.Password) && PassSec_reg.Password.Length > 0)
            {
                PassSec.Visibility = Visibility.Collapsed;
            }
            else
            {
                PassSec.Visibility = Visibility.Visible;
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void button_reg_Click(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(Fullname.Text) && !string.IsNullOrEmpty(Phone.Text) && !string.IsNullOrEmpty(Email.Text) && !string.IsNullOrEmpty(Log_reg.Text) && !string.IsNullOrEmpty(Pass_reg.Password) && !string.IsNullOrEmpty(PassSec_reg.Password))
            //{
            //    MessageBox.Show("Successfully Signed Up");
            //}
            string Login = Log_reg.Text.Trim();
            string Password = Pass_reg.Password.Trim();
            string Password2 = PassSec_reg.Password.Trim();
            string Number = Phone_txtb.Text.Trim().ToLower();
            string Full = Fullname_txtb.Text.Trim();
            string EmailAd = Email_txtb.Text.Trim();
           

            if (Full.Length < 5)
            {
                Fullname_txtb.ToolTip = "Please enter a valid fullname!";
                Fullname_txtb.Background = Brushes.LightCoral;
            }
            else
            {
                Fullname_txtb.ToolTip = "";
                Fullname_txtb.Background = Brushes.Transparent;
                }
                if (Login.Length < 5)
            {
                Log_reg.ToolTip = "Please enter a valid login!";
                Log_reg.Background = Brushes.LightCoral;
            }
            else
            {
                Log_reg.ToolTip = "";
                Log_reg.Background = Brushes.Transparent;

                if (Password.Length < 5)
                {
                    Pass_reg.ToolTip = "Please enter a valid password!";
                    Pass_reg.Background = Brushes.LightCoral;
                }
                else
                {
                    Pass_reg.ToolTip = "";
                    Pass_reg.Background = Brushes.Transparent;

                    if (Password2 != Password)
                    {
                        PassSec_reg.ToolTip = "Please enter a valid repeat password!";
                        PassSec_reg.Background = Brushes.LightCoral;
                    }
                    else
                    {
                        PassSec_reg.ToolTip = "";
                        PassSec_reg.Background = Brushes.Transparent;

                        if (Number.Length == 20)
                        {
                            Phone_txtb.ToolTip = "Please enter a valid phone number!";
                            Phone_txtb.Background = Brushes.LightCoral;
                        }
                        else
                        {
                            Phone_txtb.ToolTip = "";
                            Phone_txtb.Background = Brushes.Transparent;

                            if (EmailAd.Length < 5)
                            {
                                Email_txtb.ToolTip = "Please enter a valid email!";
                                Email_txtb.Background = Brushes.LightCoral;
                            }
                            else
                            {
                                Email_txtb.ToolTip = "";
                                Email_txtb.Background = Brushes.Transparent;


                                using (DbflowerShopContext db = new DbflowerShopContext())
                            {
                                var user = db.Users.FirstOrDefault(x => x.Login == Log_reg.Text || x.Password == Pass_reg.Password);
                                if (user != null)
                                {
                                    MessageBox.Show("Such a user already exists!");
                                }
                                User useradd = new User
                                {
                                    Fullname = Fullname_txtb.Text,
                                    Login = Log_reg.Text,
                                    Phone = Phone_txtb.Text,
                                    Email = Email_txtb.Text,
                                    Password = Pass_reg.Password,
                                    Role = "Client"
                                };
                                db.Users.Add(useradd);
                                db.SaveChanges();
                                MessageBox.Show("Signed Up Successfully!");
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();
                                Hide();
                            }

                        }
                    }
                }
            }
        }
    }
    }
}
