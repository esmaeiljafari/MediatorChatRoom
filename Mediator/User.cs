using System.Net.Sockets;

namespace Mediator
{
    public class User
    {
        private IMediator mediator;
        public User(IMediator mediator,string Name)
        {
            this.mediator = mediator;
            this.Name = Name;
        }
        public string Name { get; }

        public void Send(string message)
        {
            mediator.Send(this,message);
        }
    }

}