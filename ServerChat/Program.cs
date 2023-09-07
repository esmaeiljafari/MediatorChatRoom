using Newtonsoft.Json;
using System;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading;

namespace ServerChat
{
    class Program
    {
        public static void Main(string[] args)
        {

                Mediator mediator = new Mediator();
                Action[] actions = new Action[2];
                actions[0] = mediator.SeviceAddClient;
                actions[1] = mediator.BroadCastMessage;
                Parallel.Invoke(actions);

            while (true)
            {
            }

        }
    }

}