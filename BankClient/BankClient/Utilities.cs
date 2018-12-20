using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace BankClient
{
    class Utilities
    {
        public static TcpClient ConnectToServer(TcpClient client, IPAddress ip, int port, ListBox console)
        {
            try
            {
                client.Connect(ip, port);
                console.Items.Add("Connecting to Server");
                return client;
            }
            catch (Exception e)
            {
                console.Items.Add(e.Message);
                return null;
            }
        }

        public static void ReadMessage(TcpClient client, NetworkStream clientStream, ListBox console)
        {
            string message = "";
            //NetworkStream clientStream = client.GetStream();
            byte[] dataReceived = new byte[client.ReceiveBufferSize];
            while (client != null)
            {
                clientStream.Read(dataReceived, 0, dataReceived.Length);
                message = Encoding.ASCII.GetString(dataReceived).Trim('\0');
                console.Items.Add(message);
                clientStream.Flush();
                break;
            }
        }

        public static void SendMessage(TcpClient client, NetworkStream stream, string request, ListBox console)
        {
            byte[] clientOutput = Encoding.ASCII.GetBytes(request);
            stream.Write(clientOutput, 0, clientOutput.Length);
        }

    }
}
