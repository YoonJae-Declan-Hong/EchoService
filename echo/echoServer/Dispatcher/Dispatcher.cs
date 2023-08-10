using System.Net.Sockets;

namespace Server;

public class Dispatcher
{
    private readonly Dictionary<Command, IMessageHandler> _commands = new();

    public Dispatcher(IMessageHandler chatMessageHandler, IMessageHandler createMessageHandler, IMessageHandler joinMessageHandler, IMessageHandler inquiryMessageHandler)
    {
        Add(Command.Chat, chatMessageHandler);
        Add(Command.Inquiry, inquiryMessageHandler);
        Add(Command.Join, joinMessageHandler);
        Add(Command.Create, createMessageHandler);
    }
    
    private void Add(Command command, IMessageHandler messageHandler)
    {
        _commands.Add(command, messageHandler);
    }
    
    public void DispatchResponse(object request, Command command, Socket socket)
    {
        _commands[command].HandleResponse(request, socket);
    }
    
    public object DispatchRequest(Command command, MemoryStream stream)
    {
        return _commands[command].HandleRequest(stream);
    }
}