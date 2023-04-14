using baseDLL;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace flowers_pp
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : System.Windows.Window
    {
        public OrderWindow()
        {
            InitializeComponent();
        }

        string title_tovar = "";
        int result_price = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SQLclass.OpenConnection();
                List<string> user_info = SQLclass.Select($"SELECT * FROM users INNER JOIN address ON address.id_user = users.id WHERE users.id = N'" + StaticVars.UserId + "'");

                family_field.Text = user_info[3];
                name_field.Text = user_info[4];
                patronymic_field.Text = user_info[5];
                phone_field.Text = user_info[6];
                email_field.Text = user_info[1] + "@mail.ru";
                street_field.Text = user_info[12];
                house_field.Text = user_info[13];
                apartment_field.Text = user_info[14];
                ex_field.Text = user_info[15];
                floor_field.Text = user_info[16];

                final_summ.Text = "Стоимость: " + StaticVars.summ + " рублей";
                itog_summ.Text = "Итого: " + StaticVars.summ + " рублей";
                SQLclass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btn_create_order_Click(object sender, RoutedEventArgs e)
        {
            if (family_field.Text != "" && name_field.Text != "" && patronymic_field.Text != "" && phone_field.Text != "" && email_field.Text != "" && street_field.Text != "" && house_field.Text != "" && apartment_field.Text != "" && ex_field.Text != "" && floor_field.Text != "")
            {
                ChangeInfoOrder();
                Document doc = null;
                try
                {
                    Random rnd = new Random();
                    string fio = family_field.Text + " " + name_field.Text + " " + patronymic_field.Text;

                    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                    string source = Environment.CurrentDirectory + @"\Check_order.docx";
                    doc = app.Documents.Open(source);
                    doc.Activate();

                    Bookmarks wBookmarks = doc.Bookmarks;
                    Range wRange;
                    int i = 0;
                    string[] data = new string[5] { DateTime.Now.ToString(), fio, rnd.Next(1, 10000).ToString(), StaticVars.summ.ToString(), title_tovar };
                    foreach (Bookmark mark in wBookmarks)
                    {
                        wRange = mark.Range;
                        wRange.Text = data[i];
                        i++;
                    }
                    doc.Close();
                    doc = null;
                    Notification.Notify("Поздравляем", "Ваш заказ успешно оформлен");
                }
                catch (Exception ex)
                {
                    doc.Close();
                    doc = null;
                    MessageBox.Show(ex.Message);
                }
            }
            else
                Notification.Notify("Оформление не возможно", "Пожалуйста заполните все данные");           
        }

        public void ChangeInfoOrder()
        {
            try
            {
                SQLclass.OpenConnection();
                for(int i = 0; i < StaticVars.basket.Count; i++)
                {
                    List<string> services_flower = SQLclass.Select($"SELECT name FROM [dbo].[items] WHERE id = '" + StaticVars.basket[i] + "'");
                    title_tovar += services_flower[0] + "("+StaticVars.count_flower[i]+") \n";
                }
                SQLclass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_basket_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            CatalogWindow catalogWindow = new CatalogWindow("1", "");
            catalogWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            CatalogWindow catalogWindow = new CatalogWindow("1", "");
            catalogWindow.Show();
        }

        private void btn_vk_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/syrprizko");
        }

        private void btn_inst_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.instagram.com/teddyflowers_perm/");
        }

        private void btn_telegram_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://web.telegram.org/");
        }

        private void phone_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "+0123456789".IndexOf(e.Text) < 0;
        }

        private void house_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void apartment_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void ex_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void floor_field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }
    }
}
