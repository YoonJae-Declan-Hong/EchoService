using System.Net.Sockets;

namespace Client;

public class ChatClient
{
    private readonly Dispatcher _dispatcher;
    private readonly HeaderService _headerService;

    public ChatClient(Dispatcher dispatcher, HeaderService headerService)
    {
        _dispatcher = dispatcher;
        _headerService = headerService;
    }

    public void StartChat()
    {
        Socket client = null;
        try
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            MessageReceiver messageReceiver = new MessageReceiver(client, _dispatcher, _headerService);
            client.Connect("localhost", 5555);
            Console.WriteLine("연결 성공!");
                
            Task.Run(() => messageReceiver.ReceiveMessagesAsync());
                
            while (true)
            {
                _dispatcher.DispatchRequest(client);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (client != null) client.Close();
        }
    }
}