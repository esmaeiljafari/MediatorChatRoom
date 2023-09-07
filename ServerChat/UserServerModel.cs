using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerChat
{
    public class UserServerModel
    {
        public UserServerModel(Socket network,string Name)
        {
            this.network = network;
            this.Name = Name;
        }
        public Socket network { get; set; }
        public string Name { get; set; }
    }
}
