using NotePadCalendar.Model;
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

namespace NotePadCalendar.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }
        private void RegCloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (LogTb.Text.Trim().Length <= 0 || PassPb.Password.Trim().Length <= 0 || RepPassPb.Password.Trim().Length <= 0)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                if (PassPb.Password.Trim().Length != RepPassPb.Password.Trim().Length)
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
                else
                {
                    App.LoggedUser = App.DB.User.ToList().Find(x => x.Login == LogTb.Text);
                    if (App.LoggedUser != null)
                    {
                        MessageBox.Show("Такой логин уже есть!");
                    }
                    else
                    {
                        App.DB.User.Add(new User()
                        {
                            Login = LogTb.Text.Trim(),
                            Password = PassPb.Password.Trim(),
                        });
                        App.DB.SaveChanges();
                        NavigationService.Navigate(new LoginPage());
                    }

                }
            }
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
