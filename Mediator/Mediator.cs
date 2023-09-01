using Mediator.infrasturcture;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Mediator
    {

        private List<UserServerModel> users;
        private List<UserServerModel> userSended;
        private bool tokenSendMesage;
        private List<Task> task;
        private Socket socket;

        //   private readonly infoConnnection infomdl = infrasturcture.ReadConnection.GetConnection;

        public Mediator()
        {
            users = new List<UserServerModel>();
            userSended = new List<UserServerModel>();

            task = new List<Task>();

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var IP = IPAddress.Parse("127.0.0.1");
            var pointIP = new IPEndPoint(IP, 1212);
            socket.Bind(pointIP);
            socket.Listen();
            Console.WriteLine($"Connection to the tcp 127.0.0.1:1212");

        }


        public void BroadCastMessage()
        {

            while (true)
            {
                try
                {
                    Console.WriteLine(tokenSendMesage);
                    SeviceBehniah();
                    foreach (var item in userSended)
                    {
                        tskMessage(item);
                        Thread.Sleep(200);
                    }
                   
                }
                catch
                { }
            }
        }
        public void SeviceAddClient()
        {
            while (true)
            {
                var client = socket.Accept();
                try
                {
                    while (true)
                    {
                        byte[] b = new byte[512];
                        int len = client.Receive(b);
                        if (len <= 0) continue;
                        string message = Encoding.Unicode.GetString(b, 0, len);
                        if (message[0] == 'N')
                        {
                            string name = "";
                            for (int i = 1; i < message.Length; i++)
                            {
                                name += message[i];
                            }
                            Console.WriteLine(name);
                            
                            users.Add(new UserServerModel(client, name));
                            Console.WriteLine("Add Client Name= " + name);
                            tokenSendMesage = false;
                            break;
                        }
                    }
                }
                catch { }
            }
        }
        private Task tskMessage(UserServerModel user)
        {
            return Task.Run(() =>
            {
                try
                {
                    byte[] b = new byte[2048];
                    Console.WriteLine("wait Receive");
                    int len = user.network.Receive(b);
                    if (len <= 0) return;
                    string message = Encoding.Unicode.GetString(b, 0, len);
                    Console.WriteLine("before item user" + message);
                    foreach (var item in users)
                    {
                        Console.WriteLine("item user" + item.Name);
                        if (item != user)
                        {
                            string log = $"{user.Name} : {message}";

                            item.network.Send(Encoding.Unicode.GetBytes(log));
                            Console.WriteLine($"Message Send the {DateTime.Now.ToString()} === " + log);
                        }
                    }

                    tokenSendMesage = false;
                    userSended.Remove(user);
                }
                catch (SocketException e)
                {
                    tokenSendMesage = false;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Close Client. " + user.network.ProtocolType + $"--- FN={user.Name}---");
                    users.Remove(user);
                }
            });
        }

        private void SeviceBehniah()
        {
            while (true)
            {
                
                if (tokenSendMesage == false)
                {
                    foreach (var item in users)
                    {
                        if (userSended.Contains(item) == false)
                        {
                            userSended.Add(item);
                        }
                    }
                    foreach (var item in userSended)
                    {
                        if (users.Contains(item)==false)
                        {
                            userSended.Remove(item);
                        }
                    }
                    tokenSendMesage = true;
                    break;
                }
            }
        } 
    }
}
