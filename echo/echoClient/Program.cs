using System.Net.Sockets;

namespace Client
{
    class Program
    {
        public static int RoomNum;

        public static void Main(string[] args)
        {
            var headerService = new HeaderService();
            var chatService = new ChatService(headerService);
            var createService = new CreateService(headerService);
            var joinService = new JoinService(headerService);
            var inquiryService = new InquiryService();
            var chatHandler = new ChatMessageHandler(chatService);
            var createHandler = new CreateMessageHandler(createService);
            var joinHandler = new JoinMessageHandler(joinService);
            var inquiryHandler = new InquiryMessageHandler(inquiryService, headerService);
            var dispatcher = new Dispatcher(chatHandler, createHandler, joinHandler, inquiryHandler);
            var chatClient = new ChatClient(dispatcher, headerService);
            
            chatClient.StartChat();
        }
    }
}