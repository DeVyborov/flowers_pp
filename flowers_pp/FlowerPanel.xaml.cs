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
    /// Логика взаимодействия для FlowerPanel.xaml
    /// </summary>
    public partial class FlowerPanel : UserControl
    {
        public FlowerPanel()
        {
            InitializeComponent();
        }

        string flower_id, flower_name, flower_photo, flower_price;
        int count_flower = 0;

        public TextBlock summ;

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
                btn_minus.IsEnabled = false;
                count_flower = 0;
                count_field.Text = count_flower.ToString();
                background_basket.Background = new SolidColorBrush(Color.FromRgb(57, 255, 41));
                btn_text.Text = "В корзину";
                StaticVars.count_flower[StaticVars.basket.IndexOf(flower_id)] = 0;
                StaticVars.basket.Remove(flower_id);
                StaticVars.summ -= Convert.ToInt32(flower_price);
            }

            summ.Text = "Корзина (" + StaticVars.summ + ")";
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            if (count_flower == 1)
            {
                btn_minus.IsEnabled = false;
                count_flower--;
                count_field.Text = count_flower.ToString();
                background_basket.Background = new SolidColorBrush(Color.FromRgb(57, 255, 41));
                btn_text.Text = "В корзину";
                StaticVars.count_flower[StaticVars.basket.IndexOf(flower_id)] = 0;
                StaticVars.basket.Remove(flower_id);               
            }
            else if (count_flower > 1)
            {
                count_flower--;
                count_field.Text = count_flower.ToString();
                StaticVars.count_flower[StaticVars.basket.IndexOf(flower_id)] = count_flower;
            }

            StaticVars.summ -= Convert.ToInt32(flower_price);
            summ.Text = "Корзина (" + StaticVars.summ + ")";
        }

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            if (count_flower == 0)
            {
                btn_minus.IsEnabled = true;
                count_flower++;
                count_field.Text = count_flower.ToString();
                background_basket.Background = new SolidColorBrush(Color.FromRgb(253, 161, 26));
                btn_text.Text = "Убрать";
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
            summ.Text = "Корзина (" + StaticVars.summ + ")";
        }

        public FlowerPanel(string form_flower_id, string form_flower_name, string form_flower_photo, string form_flower_price)
        {
            try
            {
                InitializeComponent();
                flower_id = form_flower_id;
                flower_name = form_flower_name;
                flower_photo = form_flower_photo;
                flower_price = form_flower_price;

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
