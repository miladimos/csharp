using System.Net.Sockets;

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
    }
}