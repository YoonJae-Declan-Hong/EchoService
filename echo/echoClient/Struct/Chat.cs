using System.Runtime.InteropServices;

namespace Client;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class Chat
{
    private string _message { get; set; }
    private int _roomId { get; set; }

    public Chat(string message, int roomId)
    {
        _message = message;
        _roomId = roomId;
    }

    public string GetMessage()
    {
        return _message;
    }

    public int GetRoomID()
    {
        return _roomId;
    }
    
    public Chat()
    {
    }
}