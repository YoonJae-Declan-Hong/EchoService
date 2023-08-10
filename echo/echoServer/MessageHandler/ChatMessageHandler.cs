using System.Net.Sockets;

namespace Server;

public class ChatMessageHandler : IMessageHandler
{
    private readonly ChatService _chatService;
    private readonly RoomRepository _roomRepository;

    public ChatMessageHandler(ChatService chatService, RoomRepository roomRepository)
    {
        _chatService = chatService;
        _roomRepository = roomRepository;
    }
    
    public void HandleResponse(object request, Socket socket)
    {
        Chat chat = (Chat) request;
        MemoryStream sendBuffer = new MemoryStream();
        _chatService.SerializeTo(chat, sendBuffer);
        var sockets = _roomRepository.FindRoomInfoBy(chat.GetRoomID());

        foreach (var client in sockets.GetSocketList())
        {
            client.Send(sendBuffer.ToArray());
        }
    }

    public object HandleRequest(MemoryStream stream)
    {
        var chat = _chatService.DeserializeFrom(stream);
        return chat;
    }
}