using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WebPageViewer {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void AlwaysOnTop_checked(object sender, RoutedEventArgs e) {
            this.Topmost = true;
        }

        private void AlwaysOnTop_unchecked(object sender, RoutedEventArgs e) {
            this.Topmost = false;
        }

        private void b_openURL_Click(object sender, RoutedEventArgs e) {
            String url = URLinputBox.Text;
            Regex checkHTTP = new Regex(@"^https?://");
            Regex checkURL = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            if (!(checkHTTP.IsMatch(url))) {
                url = "http://" + url;
            }
            if (checkURL.IsMatch(url)) {
                try {
                    webbrowser.Source = new Uri(url);
                } catch (UriFormatException ufe) {
                }
            }
        }

        private void webbrower_navigated(object sender, NavigationEventArgs e) {
            URLinputBox.Text = webbrowser.Source.ToString();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e) {
            if (e.Key == Key.Return) {
                b_openURL_Click(sender, e);
            }
        }
    }
}
