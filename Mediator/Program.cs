using Newtonsoft.Json;
using System;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading;

namespace Mediator
{
    class Program
    {
        public static void Main(string[] args)
        {

            Mediator chat = new Mediator();
            User user1 = new User(chat, "Ali");
            User user2 = new User(chat, "Reza");
            User user3 = new User(chat, "Omid");

            chat.RegisterUser(user1);
            chat.RegisterUser(user2);
            chat.RegisterUser(user3);

            user1.Send("salam");
            user2.Send("khobi ali");
            user3.Send("ba ba .dostan");



        }
    }

}