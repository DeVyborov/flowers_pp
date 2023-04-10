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
using System.Windows.Shapes;

namespace flowers_pp
{
    /// <summary>
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        public CatalogWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SQLclass.OpenConnection();
                int show = 0;

                Fr.Children.Clear();
                List<string> services = SQLclass.Select($"SELECT * FROM [dbo].[categories]");

                for (int i = 0; i < services.Count; i += 3)
                {
                    CategoryPanel categoryPanel = new CategoryPanel(services[i+1], services[i + 2], services[i]);
                    Fr.Children.Add(categoryPanel);
                    show++;
                }
                SQLclass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
