using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

namespace ClientChat
{
    public class UserClient
    {
        public string Name { get; }

        private Socket _socket { get; set; }
        public UserClient(string Name)
        {
            invoke();
            this.Name = Name;
            byte[] n = Encoding.Unicode.GetBytes("N" + Name);
            _socket.Send(n);




        }

        public void Send()
        {

                while (true)
                {
                    string txt = Console.ReadLine();
                    _socket.Send(Encoding.Unicode.GetBytes(txt));
                      System.Threading.Thread.Sleep(500);
                }
           
        }
        public void Revice()
        {

                while (true)
                {
                    byte[] b = new byte[2048];
                    int len = _socket.Receive(b);
                    if (len <= 0) continue;
                    string message = Encoding.Unicode.GetString(b, 0, len);
                    Console.WriteLine(message);
                }

        }


        private void invoke()
        {

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress IP = IPAddress.Parse("127.0.0.1");
            IPEndPoint endpoint = new IPEndPoint(IP, 1212);
            _socket.Connect(endpoint);
        }
    }

}