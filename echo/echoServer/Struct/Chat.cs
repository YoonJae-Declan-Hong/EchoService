using System.Runtime.InteropServices;

namespace Server;

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
        return this._message;
    }

    public int GetRoomID()
    {
        return this._roomId;
    }
    
    public Chat()
    {
    }
}