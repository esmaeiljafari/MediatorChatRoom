using System.Net.Sockets;

namespace ServerChat
{
    public interface IMediator
    {
        public void BroadCastMessage();
        public void SeviceAddClient();

    }

}