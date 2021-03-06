﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
using System.Xml.Serialization;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*System.Net.Sockets.UdpClient udpclient = new System.Net.Sockets.UdpClient();
            System.Net.IPEndPoint localEp = new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 24000);
            udpclient.Client.Bind(localEp);
            udpclient.Client.ReceiveTimeout = 10000;
            udpclient.Receive();*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TcpListener list;
            Int32 port1 = 40399;
            list = new TcpListener(port1);
            list.Start();
            TcpClient client = list.AcceptTcpClient();
            Console.WriteLine("Client trying to connect");
            Stream stream = client.GetStream();
            XmlSerializer mySerializer = new XmlSerializer(typeof(File));
            File myObject = (File)mySerializer.Deserialize(stream);
            Console.WriteLine("name: " + myObject.Name);
            list.Stop();
            client.Close();
        }
    }
}
