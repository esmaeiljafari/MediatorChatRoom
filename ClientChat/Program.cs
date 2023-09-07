
using ClientChat;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter Name?");
        string Name = Console.ReadLine();
        UserClient client = new UserClient(Name);

        Action[] actions = new Action[2];

        actions[0] = client.Send;
        actions[1] = client.Revice;
        Parallel.Invoke(actions);

        while (true)
        {

        }
    }
}