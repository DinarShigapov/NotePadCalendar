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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LvReminds.ItemsSource = App.DB.Note.Where(x => x.UserId == App.LoggedUser.Id).ToList();
        }
        

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";

            if (DatDp.SelectedDate == null)
            {
                errorMessage += "Выберите дату\n";
            }
            if (string.IsNullOrWhiteSpace(TbDescription.Text))
            {
                errorMessage += "Введите описание\n";
            }
            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            App.DB.Note.Add(new Note()
            {
                NoteDate = DatDp.Text,
                Description = TbDescription.Text,
                UserId = App.LoggedUser.Id,

            });
            App.DB.SaveChanges();
            Refresh();
        }
        public void Refresh()
        {
            LvReminds.ItemsSource = App.DB.Note.Where(x => x.UserId == App.LoggedUser.Id).ToList();
        }
        private void ExtBtn_OnClick(object sender, RoutedEventArgs e)
        {
            App.LoggedUser = null;
            NavigationService.Navigate(new LoginPage());
        }
    }
}
