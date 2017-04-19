using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            url_box.GotFocus += RemoveText;
            url_box.LostFocus += AddText;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (string.Equals(url_box.Text, "Enter URL..."))
            {
                url_box.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(url_box.Text))
            {
                url_box.Text = "Enter URL...";
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            page_content.Text = GetContent(url_box.Text).Result;
        }

        private async Task<string> GetContent(string url)
        {
            string content = "Error";

            try
            {
                HttpClient httpClient = new HttpClient();

                content = await httpClient
                    .GetStringAsync(url)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                content = ex.Message + '\n' + ex.StackTrace;
            }

            return content;
        }
    }
}
