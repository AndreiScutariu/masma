using Masma.Messages.Common;

namespace Masma.Lab3.Messages
{
    public class AddThisNumbersRequest : HeaderMessage
    {
        public int Left { get; set; }

        public int Right { get; set; }
    }
}