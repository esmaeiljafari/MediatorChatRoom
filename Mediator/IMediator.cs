using System.Net.Sockets;

namespace Mediator
{
    public interface IMediator
    {
        public void BroadCastMessage(UserClient user,string message);
        public Socket Register(UserClient user);

    }

}