using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace LocalChatRoom
{
    public partial class FormClient : Form
    {
        Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public FormClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void FormClient_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPEndPoint serverIp = new IPEndPoint(IPAddress.Parse(txtIp.Text), int.Parse(txtPort.Text));
            socketClient.Connect(serverIp);
            Thread t = new Thread(new ThreadStart(getMessages));
            t.Start();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (socketClient != null)
                {
                    socketClient.Shutdown(SocketShutdown.Both);
                }

                Environment.Exit(Environment.ExitCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Environment.Exit(Environment.ExitCode);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (socketClient != null)
                {
                    socketClient.Shutdown(SocketShutdown.Both);
                }

                Environment.Exit(Environment.ExitCode);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Environment.Exit(Environment.ExitCode);
                Application.Exit();
            }
        }

        private void getMessages()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int recBytes = socketClient.Receive(buffer);
                    if (recBytes > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer);
                        lstbMessages.Items.Add("Server: " + message);
                    }
                }
            }
            catch (Exception)
            {
                ;
            }
        }
    }
}
