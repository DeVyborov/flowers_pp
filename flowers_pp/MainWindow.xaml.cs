using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using baseDLL;

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

                            StaticVars.Login = login_field.Text;
                            StaticVars.Password = password_field.Password;

                            this.Hide();
                            CatalogWindow catalogWindow = new CatalogWindow("1","");
                            catalogWindow.Show();
                        }
                        else
                        {
                            Notification.Notify("Произошла ошибка", "Вы указали неверный пароль!");
                            FailLogin();
                        }
                    }
                    else
                    {
                        Notification.Notify("Произошла ошибка", "Аккаунт с данным логином не найден в системе!");
                        FailLogin();
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

        public void FailLogin()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.CreateSubKey("LoginInfo_PP");
            helloKey.SetValue("login", "");
            helloKey.SetValue("password", "");
            helloKey.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SQLclass.CloseConnection();
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.OpenSubKey("LoginInfo_PP");

            if (helloKey.GetValue("login").ToString() != "")
            {
                login_field.Text = helloKey.GetValue("login").ToString();
                password_field.Password = helloKey.GetValue("password").ToString();
            }
            helloKey.Close();
        }
    }
}
