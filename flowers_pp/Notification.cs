using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace flowers_pp
{
    public static class Notification
    {
        private static PopupNotifier popup = null;
        public static void Notify(string mess1, string mess2)
        {
            popup = new PopupNotifier();
            popup.Image = Properties.Resources.flower_icon;
            popup.ImageSize = new Size(42, 42);
            popup.Size = new Size(300, 70);
            popup.ShowGrip = false;
            popup.ImagePadding = new Padding(8, 15, 0, 0);
            popup.TitlePadding = new Padding(5, 3, 0, 0);
            popup.ContentPadding = new Padding(5, 3, 0, 0);
            popup.TitleColor = Color.FromArgb(4, 160, 255);
            popup.ContentColor = Color.FromArgb(4, 160, 255);
            popup.BodyColor = Color.FromArgb(231, 250, 191);
            popup.ContentFont = new System.Drawing.Font("Montserrat", 10F, FontStyle.Bold);
            popup.HeaderHeight = 1;
            popup.TitleText = mess1;
            popup.ContentText = mess2;
            popup.Popup();
        }
    }
}
