using System.Runtime.InteropServices;

namespace Client;

public class CreateRoom
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CreateRoomReq
    {
        private string _title { get;  set; }

        public CreateRoomReq(string title)
        {
            _title = title;
        }

        public CreateRoomReq()
        {
        
        }

        public string GetTitle()
        {
            return _title;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CreateRoomAns
    {
        private int _roomNum { get; set; }

        public CreateRoomAns(int roomNum)
        {
            _roomNum = roomNum;
        }

        public CreateRoomAns()
        {
        
        }

        public int GetRoomNum()
        {
            return _roomNum;
        }
    }
}