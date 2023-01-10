using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LocalChatRoom
{
    public partial class FormServer : Form
    {
        Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket socketClient = null;


        public FormServer()
        {
            InitializeComponent();
        }

        private void FormServer_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread trStart = new Thread(new ThreadStart(startServer));
            trStart.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (socketClient != null)
                {
                    socketClient.Shutdown(SocketShutdown.Both);
                }
                if (socketServer != null)
                {
                    socketServer.Shutdown(SocketShutdown.Both);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                if (socketServer != null)
                {
                    socketServer.Shutdown(SocketShutdown.Both);
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1024];
            buffer = Encoding.Unicode.GetBytes(txtMessage.Text);
            socketClient.Send(buffer);
        }

        public void getMessages()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int recBytes = socketClient.Receive(buffer);
                    if (recBytes > 0)
                    {
                        lstbMessages.Items.Add("Client: " + Encoding.Unicode.GetString(buffer, 0, recBytes));
                    }
                }
            }
            catch (Exception)
            {

                ;
            }
        }

        private void startServer()
        {
            IPEndPoint iPEndPointServer = new IPEndPoint(IPAddress.Parse(txtIp.Text), int.Parse(txtPort.Text));
            socketServer.Bind(iPEndPointServer);
            socketServer.Listen(10);
            socketClient = socketServer.Accept();
            Thread trServer = new Thread(new ThreadStart(getMessages));
            trServer.Start();
        }
    }
}