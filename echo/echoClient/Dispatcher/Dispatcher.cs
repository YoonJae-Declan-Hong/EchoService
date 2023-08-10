using System.Net.Sockets;
using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;

namespace Client;

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
    
    public void DispatchResponse(Command command, MemoryStream stream)
    {
        _commands[command].HandleResponse(stream);
    }
    
    public void DispatchRequest(Socket client)
        {
            var message = Console.ReadLine();
            var index = message.IndexOf(' ');
            if (index < 0)
            {
                index = 0;
            }
            
            var cmd = message.Substring(0, index);
            
            if (index == 0)
            {
                cmd = message;
            }
            
            var cmdPart = Regex.Replace(cmd, @"(^\w)", match => match.Value.ToUpper());
            if (false == Enum.TryParse<Command>(cmdPart, out var command))
            {
                command = cmdPart == "Inquiry" ? Command.Inquiry : Command.Chat;
            }

            string otherParts = null;
            
            otherParts = command is Command.Chat or Command.Inquiry ? null : message.Substring(index + 1, message.Length - (index + 1));

            if (otherParts == null)
            {
                otherParts = message;
            }
            _commands[command].HandleRequest(otherParts, client);
        }
}