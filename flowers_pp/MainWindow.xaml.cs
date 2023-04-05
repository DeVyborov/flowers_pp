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
        }

        private void btn_registration_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void btn_sign_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (login_field.Text != "" && password_field.Password != "")
                {
                    string existUser_Login = SQLclass.Select("SELECT COUNT(*) FROM [dbo].[Employees] WHERE login = '" + login_field.Text + "'")[0]; // проверка на введенный логин в бд

                    if (existUser_Login != "0") // Если логин существует в бд
                    {
                        string existUser_Password = SQLclass.Select("SELECT COUNT(*) FROM [dbo].[Employees] WHERE password='" + password_field.Password + "'")[0]; // проверка на введенный пароль в бд

                        if (existUser_Password != "0") // Если пароль введен верно
                        {
                            //List<string> userData = SQLclass.Select("SELECT * FROM Employees JOIN Post ON Employees.id_post = Post.id WHERE Employees.id = '" + StaticVars.UserId + "'");

                            //StaticVars.UserName = userData[0];
                            //StaticVars.UserSurname = userData[1];
                            //StaticVars.UserIDStatus = userData[2];
                            //StaticVars.UserStatus = userData[3];

                            //ntf.Notify("Добро пожаловать", "Желаем вам хорошего рабочего дня!");

                            //LogAuth(1); // запись истории входа

                            //this.Hide();
                            //User_Card user_Card = new User_Card();
                            //user_Card.Owner = this;
                            //user_Card.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                            //user_Card.ShowDialog();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
