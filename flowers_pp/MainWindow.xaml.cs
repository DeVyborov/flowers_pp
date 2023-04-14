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

namespace flowers_pp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SQLclass.OpenConnection();
        }

        private void btn_registration_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            //RegistrationWindow registrationWindow = new RegistrationWindow();
            //registrationWindow.Show();

            login_field.Text = "vyborov";
            password_field.Password = "123123";
        }

        private void btn_sign_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (login_field.Text != "" && password_field.Password != "")
                {                   
                    string existUser_Login = SQLclass.Select("SELECT COUNT(*) FROM [dbo].[users] WHERE login = '" + login_field.Text + "'")[0]; // проверка на введенный логин в бд

                    if (existUser_Login != "0") // Если логин существует в бд
                    {
                        string existUser_Password = SQLclass.Select("SELECT COUNT(*) FROM [dbo].[users] WHERE password='" + password_field.Password + "'")[0]; // проверка на введенный пароль в бд
                        StaticVars.UserId = SQLclass.Select("SELECT id FROM users WHERE login = '" + login_field.Text + "'")[0];

                        if (existUser_Password != "0") // Если пароль введен верно
                        {
                            List<string> userData = SQLclass.Select("SELECT * FROM [dbo].[users] WHERE id = '" + StaticVars.UserId + "'");

                            Notification.Notify("", "Добро пожаловать!");
                            SQLclass.CloseConnection();

                            this.Hide();
                            CatalogWindow catalogWindow = new CatalogWindow("1","");
                            catalogWindow.Show();
                        }
                        else
                        {
                            Notification.Notify("Произошла ошибка", "Вы указали неверный пароль!");
                        }
                    }
                    else
                    {
                        Notification.Notify("Произошла ошибка", "Аккаунт с данным логином не найден в системе!"); 
                    }
                }
                else
                    Notification.Notify("Произошла ошибка", "Пожалуйста укажите данные для входа!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SQLclass.CloseConnection();
        }
    }
}
