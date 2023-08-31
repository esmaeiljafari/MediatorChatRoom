using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Mediator : IMediator
    {
        private List<User> users = new List<User>();
        public void RegisterUser(User user)
        {
            users.Add(user);
        }

        public void Send(User user, string message)
        {
            Console.WriteLine($"send message by {user.Name} : {message}");

            foreach (var item in users)
            {
                if (user != item)
                {
                    Console.WriteLine($"Revice message {user.Name} : {message}");
                }
            }
        }
    }
}
