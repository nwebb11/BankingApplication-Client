using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace BankClient
{
    public partial class Form1 : Form
    {

        TcpClient clientConnection = new TcpClient();
        IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        int portNum = 5005;
        NetworkStream clientStream = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (Utilities.ConnectToServer(clientConnection, serverIP, portNum, lBoxConsole) != null)  {
                clientStream = clientConnection.GetStream();
                Utilities.SendMessage(clientConnection, clientStream, "Client connecting to server", lBoxConsole);
                Utilities.ReadMessage(clientConnection, clientStream, lBoxConsole);
                Utilities.SendMessage(clientConnection, clientStream, "Client connected to server", lBoxConsole);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (clientStream != null)
            {
                Utilities.SendMessage(clientConnection, clientStream, "hello back", lBoxConsole);
            }
        }
    }
}
