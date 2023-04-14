using System;
using System.Collections.Generic;
using System.Windows;

namespace flowers_pp
{
    /// <summary>
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    /// 

    public partial class CatalogWindow : Window
    {
        string type_list, category_list = "";
        bool goto_bucket = false;

        public CatalogWindow(string form_type, string form_category)
        {
            InitializeComponent();
            type_list = form_type;
            category_list = form_category;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ChangeSelect(type_list, category_list);              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ChangeSelect(string type,string catregory)
        {
            Fr.Children.Clear();
            SQLclass.OpenConnection();
            if (type == "1") // catalog
            {
                summ_basket.Text = "Корзина(" + StaticVars.summ + ")";
                List<string> services_category = SQLclass.Select($"SELECT * FROM [dbo].[categories]");

                for (int i = 0; i < services_category.Count; i += 3)
                {
                    CategoryPanel categoryPanel = new CategoryPanel(services_category[i + 1], services_category[i + 2], services_category[i]);
                    categoryPanel.change_list = this.change_block;
                    Fr.Children.Add(categoryPanel);
                }
            }
            else if (type == "2") // flower
            {
                summ_basket.Text = "Корзина(" + StaticVars.summ + ")";
                btn_exit.Visibility = Visibility.Visible;
                List<string> services_flower = SQLclass.Select($"SELECT * FROM [dbo].[items] WHERE id_categories = '" + catregory + "'");

                for (int i = 0; i < services_flower.Count; i += 5)
                {
                    FlowerPanel flowerPanel = new FlowerPanel(services_flower[i], services_flower[i + 1], services_flower[i + 2], services_flower[i + 3], "1");
                    flowerPanel.summ = this.summ_basket;
                    Fr.Children.Add(flowerPanel);
                }
            }
            else if (type == "3") // basket
            {
                btn_exit.Visibility = Visibility.Visible;
                List<string> services_flower = SQLclass.Select($"SELECT * FROM [dbo].[items]");

                for (int i = 0; i < services_flower.Count; i += 5)
                {
                    FlowerPanel flowerPanel = new FlowerPanel(services_flower[i], services_flower[i + 1], services_flower[i + 2], services_flower[i + 3], "2");
                    flowerPanel.summ = this.summ_basket;
                    flowerPanel.select = this.change_backet;

                    if (StaticVars.basket.Count == 0)
                    {
                        ChangeSelect("1", "");                        
                    }
                    else
                    {
                        for (int y = 0; y < StaticVars.basket.Count; y++)
                        {
                            if (StaticVars.basket[y] == services_flower[i])
                            {
                                Fr.Children.Add(flowerPanel);
                            }
                        }
                    }                   
                }
            }
            SQLclass.CloseConnection();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            ChangeSelect("1", "");
            summ_basket.Text = "Корзина(" + StaticVars.summ + ")";
            btn_exit.Visibility = Visibility.Hidden;
            goto_bucket = false;
        }

        private void btn_basket_Click(object sender, RoutedEventArgs e)
        {
            if (goto_bucket == true)
            {
                this.Hide();
                OrderWindow orderWindow = new OrderWindow();
                orderWindow.Show();
            }
            else if (StaticVars.summ > 0)
            {
                ChangeSelect("3", "");
                summ_basket.Text = "Оформить(" + StaticVars.summ + ")";
                goto_bucket = true;
            }
            else
                Notification.Notify("Произошла ошибка", "В вашей корзине нет товаров");
        }

        private void change_backet_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (change_backet.Text.Length >= 1)
            {
                ChangeSelect("3", "");
            }           
        }

        private void change_block_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (change_block.Text.Length >= 1)
            {
                ChangeSelect("2", change_block.Text);
            }
        }
    }
}
