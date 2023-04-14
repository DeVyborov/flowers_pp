﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace flowers_pp
{
    /// <summary>
    /// Логика взаимодействия для FlowerPanel.xaml
    /// </summary>
    public partial class FlowerPanel : UserControl
    {
        public FlowerPanel()
        {
            InitializeComponent();
        }

        string flower_id, flower_name, flower_photo, flower_price, flower_type;
        int count_flower = 0;

        public TextBlock summ;
        public TextBox select;

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (count_flower == 0)
            {
                btn_minus.IsEnabled = true;
                count_flower = 1;
                count_field.Text = count_flower.ToString();
                background_basket.Background = new SolidColorBrush(Color.FromRgb(253,161,26));
                btn_text.Text = "Убрать";
                StaticVars.basket.Add(flower_id);
                StaticVars.count_flower[StaticVars.basket.IndexOf(flower_id)] = count_flower;
                StaticVars.summ += Convert.ToInt32(flower_price);
            }
            else if (btn_text.Text == "Убрать")
            {
                if (count_flower > 1)
                {
                    StaticVars.summ -= Convert.ToInt32(flower_price) * count_flower;
                }
                else
                {
                    StaticVars.summ -= Convert.ToInt32(flower_price);
                }

                btn_minus.IsEnabled = false;
                count_flower = 0;
                count_field.Text = count_flower.ToString();
                background_basket.Background = new SolidColorBrush(Color.FromRgb(57, 255, 41));
                btn_text.Text = "В корзину";
                StaticVars.count_flower[StaticVars.basket.IndexOf(flower_id)] = 0;
                StaticVars.basket.Remove(flower_id);                
            }

            summ.Text = "Корзина (" + StaticVars.summ + ")";
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            StaticVars.summ -= Convert.ToInt32(flower_price);
            if (count_flower == 1)
            {
                btn_minus.IsEnabled = false;
                count_flower--;
                count_field.Text = count_flower.ToString();
                background_basket.Background = new SolidColorBrush(Color.FromRgb(57, 255, 41));
                btn_text.Text = "В корзину";
                StaticVars.count_flower[StaticVars.basket.IndexOf(flower_id)] = 0;
                StaticVars.basket.Remove(flower_id);

                if (flower_type == "1")
                {
                    summ.Text = "Корзина(" + StaticVars.summ + ")";
                }
                else if (flower_type == "2")
                {
                    select.Text = "";
                    select.Text = "1";
                    summ.Text = "Корзина (" + StaticVars.summ + ")";
                }               
            }
            else if (count_flower > 1)
            {
                count_flower--;
                count_field.Text = count_flower.ToString();
                StaticVars.count_flower[StaticVars.basket.IndexOf(flower_id)] = count_flower;


                if (flower_type == "1")
                {
                    summ.Text = "Корзина(" + StaticVars.summ + ")";
                }
                else if (flower_type == "2")
                {
                    summ.Text = "Оформить(" + StaticVars.summ + ")";
                }
            }                     
        }

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            if (count_flower == 0)
            {
                btn_minus.IsEnabled = true;
                count_flower++;
                count_field.Text = count_flower.ToString();

                if(flower_type != "2")
                {
                    background_basket.Background = new SolidColorBrush(Color.FromRgb(253, 161, 26));
                    btn_text.Text = "Убрать";
                }             
                StaticVars.basket.Add(flower_id);
                StaticVars.count_flower[StaticVars.basket.IndexOf(flower_id)] = count_flower;
            }
            else if (count_flower >= 1 && count_flower <= 20)
            {
                count_flower++;
                count_field.Text = count_flower.ToString();
                StaticVars.count_flower[StaticVars.basket.IndexOf(flower_id)] = count_flower;
            }

            StaticVars.summ += Convert.ToInt32(flower_price);

            if (flower_type == "1")
            {
                summ.Text = "Корзина(" + StaticVars.summ + ")";
            }
            else if (flower_type == "2")
            {
                summ.Text = "Оформить(" + StaticVars.summ + ")";
            }               
        }

        public FlowerPanel(string form_flower_id, string form_flower_name, string form_flower_photo, string form_flower_price, string form_flower_type)
        {
            try
            {
                InitializeComponent();
                flower_id = form_flower_id;
                flower_name = form_flower_name;
                flower_photo = form_flower_photo;
                flower_price = form_flower_price;
                flower_type = form_flower_type;

                if (flower_type == "1")
                {                                      
                    for (int i = 0; i < StaticVars.basket.Count; i++)
                    {
                        if (flower_id == StaticVars.basket[i])
                        {
                            btn_minus.IsEnabled = true;
                            count_flower = StaticVars.count_flower[i];
                            count_field.Text = count_flower.ToString();
                            background_basket.Background = new SolidColorBrush(Color.FromRgb(253, 161, 26));
                            btn_text.Text = "Убрать";
                        }
                    }

                    title_price.Text = flower_price + " рублей";
                    title_flower.Text = flower_name;
                    photo_category.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/PreviewFlower/" + flower_photo, UriKind.Absolute));
                }
                else if (flower_type == "2")
                {
                    btn_add.IsEnabled = false;
                    for (int i = 0; i < StaticVars.basket.Count; i++)
                    {
                        if (flower_id == StaticVars.basket[i])
                        {
                            btn_minus.IsEnabled = true;
                            count_flower = StaticVars.count_flower[i];
                            count_field.Text = count_flower.ToString();
                            background_basket.Background = new SolidColorBrush(Color.FromRgb(153, 147, 147));
                        }
                    }

                    title_price.Text = flower_price + " рублей";
                    title_flower.Text = flower_name;
                    photo_category.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/PreviewFlower/" + flower_photo, UriKind.Absolute));
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
