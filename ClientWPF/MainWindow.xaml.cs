using System.ComponentModel;
using System.ServiceModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Messenger.Library;

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChannelFactory<IChatService> _channelFactory;
        private IChatService _client;


        public MainWindow ()
        {
            InitializeComponent ();
            _channelFactory = new ChannelFactory<IChatService>("myTcpBinding");
            _client = _channelFactory.CreateChannel ();
            Closing += OnClosing;

            listBox.ItemsSource = _client.GetMessages ();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            _channelFactory.Close();
        }

        private void onSend (object sender, RoutedEventArgs e)
        {
            _client.SendMessage(textBox.Text);
            listBox.ItemsSource = _client.GetMessages ();
            textBox.Clear();
        }

        private void onSave (object sender, RoutedEventArgs e)
        {
            _client.SaveMessages();
        }

        private void onLoad (object sender, RoutedEventArgs e)
        {
            _client.LoadMessages();
            listBox.ItemsSource = _client.GetMessages ();
        }

        private void onClear (object sender, RoutedEventArgs e)
        {
            _client.Clear();
            listBox.ItemsSource = _client.GetMessages ();
        }

        private void onEnterPressed (object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                onSend(sender, e);
            }
        }
    }
}
