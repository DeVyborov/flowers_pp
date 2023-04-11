using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace flowers_pp
{
    /// <summary>
    /// Логика взаимодействия для CategoryPanel.xaml
    /// </summary>
    public partial class CategoryPanel : UserControl
    {
        string categoryName, categoryPhoto, categoryId;

        public CategoryPanel()
        {
            InitializeComponent();
        }

        private void btn_basket_MouseEnter(object sender, MouseEventArgs e)
        {
            back_main.Background = new SolidColorBrush(Color.FromRgb(88,85,79));
        }

        private void btn_basket_MouseLeave(object sender, MouseEventArgs e)
        {
            back_main.Background = new SolidColorBrush(Color.FromArgb(88, 85, 79, 0));
        }

        private void btn_basket_Click(object sender, RoutedEventArgs e)
        {
            CatalogWindow catalogWindow = new CatalogWindow("2", categoryId);
            catalogWindow.UpdateData(categoryId);
        }

        public CategoryPanel(string form_category_name, string form_category_photo, string form_category_id)
        {
            try
            {
                InitializeComponent();
                categoryId = form_category_id;
                categoryName = form_category_name;
                categoryPhoto = form_category_photo;

                title_category.Text = categoryName;
                photo_category.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/PreviewCategory/" + form_category_photo, UriKind.Absolute));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
