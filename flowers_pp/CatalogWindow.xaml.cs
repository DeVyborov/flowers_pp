using System;
using System.Collections.Generic;
using System.Windows;

namespace flowers_pp
{
    /// <summary>
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        string type_list, category_list = "";
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
                SQLclass.OpenConnection();

                if (type_list == "1") // catalog
                {
                    Fr.Children.Clear();
                    List<string> services = SQLclass.Select($"SELECT * FROM [dbo].[categories]");

                    for (int i = 0; i < services.Count; i += 3)
                    {
                        CategoryPanel categoryPanel = new CategoryPanel(services[i + 1], services[i + 2], services[i]);
                        Fr.Children.Add(categoryPanel);
                    }
                }
                else if (type_list == "2") // flower
                {
                    Fr.Children.Clear();
                    List<string> services = SQLclass.Select($"SELECT * FROM [dbo].[items] WHERE id_categories = '" + category_list + "'");

                    for (int i = 0; i < services.Count; i += 5)
                    {
                        FlowerPanel flowerPanel = new FlowerPanel(services[i], services[i + 1], services[i + 2], services[i + 3]);
                        Fr.Children.Add(flowerPanel);
                    }
                }
                else
                    MessageBox.Show("Error");

                SQLclass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateData(string category_id)
        {
            this.Close();
            CatalogWindow catalog = new CatalogWindow("2", category_id);
            catalog.Show();
        }
    }
}
