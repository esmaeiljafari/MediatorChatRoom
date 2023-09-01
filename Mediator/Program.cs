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
            Console.WriteLine("Server - Client ?(s-c)");
            if (Console.ReadLine().ToLower().ToString() == "s")
            {
                Mediator mediator = new Mediator();
                Action[] actions = new Action[2];

                actions[0] = mediator.SeviceAddClient;
                actions[1] = mediator.BroadCastMessage;
                Parallel.Invoke(actions);
            }
            else
            {
                Console.WriteLine("Enter Name?");
                string Name = Console.ReadLine();
                UserClient client = new UserClient(Name);

                Action[] actions = new Action[2];

                actions[0] = client.Send;
                actions[1] = client.Revice;
                Parallel.Invoke(actions);


            }

            while (true)
            {
            }

        }
    }

}