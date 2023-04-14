using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using baseDLL;

namespace flowers_pp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void radio_one_Click(object sender, RoutedEventArgs e)
        {
            if (case_prog_info.Visibility == Visibility.Hidden)
            {
                case_prog_info.Visibility = Visibility.Visible;
                case_user_info.Visibility = Visibility.Hidden;
                case_final.Visibility = Visibility.Hidden;
                case_address_info.Visibility = Visibility.Hidden;
            }
        }

        private void radio_two_Click(object sender, RoutedEventArgs e)
        {
            if (case_user_info.Visibility == Visibility.Hidden)
            {
                case_prog_info.Visibility = Visibility.Hidden;
                case_user_info.Visibility = Visibility.Visible;
                case_final.Visibility = Visibility.Hidden;
                case_address_info.Visibility = Visibility.Hidden;
            }
        }

        private void radio_three_Click(object sender, RoutedEventArgs e)
        {
            if (case_final.Visibility == Visibility.Hidden)
            {
                case_prog_info.Visibility = Visibility.Hidden;
                case_user_info.Visibility = Visibility.Hidden;
                case_final.Visibility = Visibility.Visible;
                case_address_info.Visibility = Visibility.Hidden;
            }
        }

        private void btn_registration_Click(object sender, RoutedEventArgs e)
        {
            if (case_prog_info.Visibility == Visibility.Visible)
            {
                if (login_field.Text != "" && password_field.Password != "" && password_rec_field.Password != "")
                {
                    if (password_field.Password == password_rec_field.Password)
                    {
                        case_prog_info.Visibility = Visibility.Hidden;
                        case_user_info.Visibility = Visibility.Visible;
                        radio_one.IsChecked = false;
                        radio_two.IsChecked = true;
                    }
                    else
                        Notification.Notify("", "Указанные вами пароли не совпадают!");
                }
                else
                    Notification.Notify("Произошла ошибка", "Для продолжения пожалуйста заполните данные!");
            }
            else if (case_user_info.Visibility == Visibility.Visible)
            {
                if (family_field.Text != "" && name_field.Text != "" && patronymic_field.Text != "")
                {
                    case_user_info.Visibility = Visibility.Hidden;
                    case_final.Visibility = Visibility.Visible;
                    radio_two.IsChecked = false;
                    radio_three.IsChecked = true;
                }
                else
                    Notification.Notify("Произошла ошибка", "Для продолжения пожалуйста заполните данные!");
            }
            else if (case_final.Visibility == Visibility.Visible)
            {
                if (phone_field.Text != "" && name_field.Text != "")
                {
                    case_final.Visibility = Visibility.Hidden;
                    case_address_info.Visibility = Visibility.Visible;
                    case_radio_button.Visibility = Visibility.Hidden;
                    text_registration.Text = "Зарегистрироваться";
                    logo_text.Margin = new Thickness(0, 0, 0, 310);
                }
                else
                    Notification.Notify("Произошла ошибка", "Для продолжения пожалуйста заполните данные!");
            }
            else if (case_address_info.Visibility == Visibility.Visible)
            {
                if (street_field.Text != "" && house_field.Text != "" && room_field.Text != "" && ex_field.Text != "" && floor_field.Text != "")
                {
                    try
                    {
                        if (password_field.Password.Length < 8)
                        {
                            Notification.Notify("Произошла ошибка", "Пожалуйста укажите пароль из 8 и более символов!");
                        }
                        else
                        {
                            int gender = 1;

                            if (radio_female.IsChecked == true)
                            {
                                gender = 2;
                            }

                            string date_time = birthday_field.Text;
                            DateTime date = Convert.ToDateTime(date_time.Replace("00:00:0000", ""));
                            string normal_date = Convert.ToString(date);
                            string rez_date = normal_date[6] + "" + normal_date[7] + "" + normal_date[8] + "" + normal_date[9] + "-" + normal_date[3] + "" + normal_date[4] + "-" + normal_date[0] + "" + normal_date[1];

                            SQLclass.Insert("INSERT INTO users(login, password, first_name, name, last_name, phone, date_of_birth, gender, roll)" +
                            " VALUES(N'" + login_field.Text + "'," +
                            "N'" + password_field.Password + "'," +
                            "N'" + family_field.Text + "'," +
                            "'" + name_field.Text + "'," +
                            "'" + patronymic_field.Text + "'," +
                            "'" + phone_field.Text + "'," +
                            "N'" + rez_date + "'," +
                            "'" + gender.ToString() + "'," +
                            "N'0')");

                            string user_reg = SQLclass.Select("SELECT id FROM users WHERE login = '" + login_field.Text + "'")[0];

                            SQLclass.Insert("INSERT INTO address(id_user, street, house, room, porch, floor)" +
                            " VALUES(N'" + user_reg + "'," +
                            "N'" + street_field.Text + "'," +
                            "N'" + house_field.Text + "'," +
                            "'" + room_field.Text + "'," +
                            "'" + ex_field.Text + "'," +
                            "N'" + floor_field.Text + "')");

                            Notification.Notify("Поздравляем", "Вы успешно зарегистрировали новый аккаунт!");

                            this.Hide();
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                        }                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    Notification.Notify("Произошла ошибка", "Для продолжения пожалуйста заполните данные!");
            }
        }

        private void radio_male_Click(object sender, RoutedEventArgs e)
        {
            if (radio_male.IsChecked == false)
            {
                radio_male.IsChecked = true;
                radio_female.IsChecked=false;
            }
        }

        private void radio_female_Click(object sender, RoutedEventArgs e)
        {
            if (radio_female.IsChecked == false)
            {
                radio_male.IsChecked = false;
                radio_female.IsChecked = true;
            }
        }

        private void btn_sign_Click(object sender, RoutedEventArgs e)
        {
            if (case_prog_info.Visibility == Visibility.Visible)
            {
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else if (case_user_info.Visibility == Visibility.Visible)
            {
                case_prog_info.Visibility = Visibility.Visible;
                case_user_info.Visibility = Visibility.Hidden;
                radio_one.IsChecked = true;
                radio_two.IsChecked = false;
            }
            else if (case_final.Visibility == Visibility.Visible)
            {
                case_user_info.Visibility = Visibility.Visible;
                case_final.Visibility = Visibility.Hidden;
                radio_two.IsChecked = true;
                radio_three.IsChecked = false;
            }
            else if (case_address_info.Visibility == Visibility.Visible)
            {
                case_final.Visibility = Visibility.Visible;
                case_address_info.Visibility = Visibility.Hidden;
                case_radio_button.Visibility = Visibility.Visible;
                text_registration.Text = "Продолжить";
                radio_three.IsChecked = true;
            }
        }

        private void phone_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "+0123456789".IndexOf(e.Text) < 0;
        }

        private void house_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void room_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void ex_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void TextBlock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
