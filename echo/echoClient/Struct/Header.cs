using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Client;

public enum Command
{
    Create,
    Delete,
    Join,
    Leave,
    Chat,
    Inquiry
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class Header
{
    private Command _cmd { get; set; }
    private int _length { get; set; }

    public Command GetCommand()
    {
        return _cmd;
    }

    public int GetLength()
    {
        return _length;
    }

    public Header(Command cmd, int length)
    {
        _cmd = cmd;
        _length = length;
    }

    public Header()
    {
        
    }
}