using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    static List<TcpClient> clients = new List<TcpClient>();
    static void ProcessMessage(object pram)
    {
        string data;
        int count;
        try
        {
            TcpClient client = pram as TcpClient;
            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            // Get a stream object for reading and writing
            NetworkStream readStream = client.GetStream();

            // Loop to receive all the data sent by the client.                 
            while ((count = readStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                List<NetworkStream> writeStreams = clients.Where(x => x != client).Select(s => s.GetStream()).ToList();
                // Translate data bytes to a ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);
                Console.WriteLine($"Received: {data} at {DateTime.Now:t}");
                // Process the data sent by the client.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                foreach (NetworkStream networkStream in writeStreams)
                {
                    // Send back a response.
                    networkStream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Sent: {data}");
                }
            }
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0}", ex.Message);
            Console.WriteLine("Waiting message...");
        }
    }//end ProcessMessage
    // Shutdown and end connection

    public static void Main()
    {
        string host = "127.0.0.1";
        // Set the TcpListener on port 13000.
        int port = 13000;

        ExecuteServer(host, port);
    }//end Main

    static void ExecuteServer(string host, int port)
    {
        int Count = 0;
        TcpListener server = null;
        try
        {
            Console.Title = "Server Application";
            IPAddress localAddr = IPAddress.Parse(host);
            server = new TcpListener(localAddr, port);
            // Start listening for client requests.
            server.Start();
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("Waiting for a connection... ");
            // Enter the listening loop.
            while (true)
            {
                // Perform a blocking call to accept requests.
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                Console.WriteLine($"Number of client connected: {++Count}");
                Console.WriteLine(new string('*', 40));
                //Create a thread to receive and send message
                Thread thread = new Thread(new ParameterizedThreadStart(ProcessMessage));
                thread.Start(client);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: {0}", ex.Message);
        }
        finally
        {
            server.Stop();
            Console.WriteLine("Server stopped. Press any key to");
            Console.Read();
        }
    }

}//end Program

