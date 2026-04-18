using Chat_Client.ServiceChat;
using System.Net.Sockets;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace Chat_Client
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, Chat_Client.ServiceChat.IServiceChatCallback
  {
    bool isConnected = false;
    ServiceChat.ServiceChatClient client;
    int ID;
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      
    }

    void ConnectUser() 
    {
      if (!isConnected) 
      {
        client = new ServiceChatClient(new InstanceContext(this));
        ID = client.Connect(tbUserName.Text);
        tbUserName.IsEnabled = false;
        isConnected = true;
        btConDiscon.Content = "Disconnect";
      }
    }

    void DisconnectUser() 
    {
      if (isConnected)
      {
        client.Disconnect(ID);
        client = null;
        tbUserName.IsEnabled = true;
        isConnected = false;
        btConDiscon.Content = "Connect";
      }
        
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (isConnected)
        DisconnectUser();
      else
        ConnectUser();
    }

    public void MsgCallBack(string msg)
    {
      lbChat.Items.Add(msg);
      lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count-1]);
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      DisconnectUser();
    }

    private void tbMessage_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        if (client != null) 
        {
          client.SendMsg(tbMessage.Text, ID);
          tbMessage.Text = string.Empty;
        }
      }
    }
  }
}
