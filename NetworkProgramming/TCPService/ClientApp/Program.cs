using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void ConnectServer(TcpClient client)
    {
        Thread sentThread = new Thread(new ParameterizedThreadStart(sentMessage));
        Thread receivedThread = new Thread(new ParameterizedThreadStart(receivedMessage));
        sentThread.Start(client);
        receivedThread.Start(client);
    }//end ConnectServer

    static void sentMessage(object pram)
    {
        string message, responseData;
        int bytes;
        TcpClient client = pram as TcpClient;
        try
        {
            Console.Title = "Client Application";
            NetworkStream stream = null;
            while (true)
            {
                Console.Write("Input message <press Enter to exit>");
                message = Console.ReadLine();
                if (message == string.Empty)
                {
                    break;
                }
                stream = client.GetStream();
                // Translate the passed message into ASCII and store it as a byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes($"{message}");
                // Get a client stream for reading and writing.
                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);
            }
            // Shutdown and end connection
            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e.Message);
        }
    }

    static void receivedMessage(object pram)
    {
        string message, responseData;
        int bytes;
        TcpClient client = pram as TcpClient;

        try
        {
            Console.Title = "Client Application";
            NetworkStream stream = null;
            while (true)
            {
                stream = client.GetStream();
                Byte[] data = new Byte[256];
                // Read the first batch of the TcpServer response bytes.
                bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
            }
            // Shutdown and end connection
            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e.Message);
        }
    }


    static void Main(string[] args)
    {
        string server = "127.0.0.1";
        // Set the TepListener on port 13000.
        int port = 13000;
        TcpClient client = new TcpClient(server, port);
        Console.Title = "Client Application";
        ConnectServer(client);
    }//end Main
}//end Program
