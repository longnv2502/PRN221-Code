using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace ReverseRemoteClient01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TcpListener tcpListener;
        Socket socketForServer;
        NetworkStream networkStream;
        StreamWriter streamWriter;
        StreamReader streamReader;
        StringBuilder strInput;
        Thread th_StartListen, th_RunClient;
        public MainWindow()
        {
            InitializeComponent();
            th_StartListen = new Thread(new ThreadStart(StartListen));
            th_StartListen.Start();
            textBox2.Focus();
        }
        private void StartListen()
        {
            tcpListener = new TcpListener(System.Net.IPAddress.Any, 6666);
            tcpListener.Start();
            //toolStripStatusLabel1.Text = "Listening on port 6666 ...";
            for (; ; )
            {
                socketForServer = tcpListener.AcceptSocket();
                IPEndPoint ipend = (IPEndPoint)socketForServer.RemoteEndPoint;
                //toolStripStatusLabel1.Text = "Connection from " + IPAddress.Parse(ipend.Address.ToString());
                th_RunClient = new Thread(new ThreadStart(RunClient));
                th_RunClient.Start();
            }
        }

        private void RunClient()
        {
            networkStream = new NetworkStream(socketForServer);
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            strInput = new StringBuilder();

            while (true)
            {
                try
                {
                    strInput.Append(streamReader.ReadLine());
                    strInput.Append("\r\n");
                }
                catch (Exception err)
                {
                    Cleanup();
                    break;
                }
                DisplayMessage(strInput.ToString());
                strInput.Remove(0, strInput.Length);
            }
        }

        private void Cleanup()
        {
            try
            {
                streamReader.Close();
                streamWriter.Close();
                networkStream.Close();
                socketForServer.Close();
            }
            catch (Exception err) { }
           
        }

        private delegate void DisplayDelegate(string message);
        private void DisplayMessage(string message)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new DisplayDelegate(DisplayMessage), new object[] { message });
                return;
            }
            else
            {
                textBox1.AppendText(message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                strInput.Append(textBox2.Text.ToString());
                streamWriter.WriteLine(strInput);
                streamWriter.Flush();
                strInput.Remove(0, strInput.Length);
                if (textBox2.Text == "exit") Cleanup();
                if (textBox2.Text == "terminate") Cleanup();
                if (textBox2.Text == "cls") textBox1.Text = "";
                textBox2.Text = "";

            }
            catch (Exception err) { }
        }

        
    }
}
