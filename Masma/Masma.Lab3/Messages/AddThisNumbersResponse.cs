using Masma.Messages.Common;

namespace Masma.Lab3.Messages
{
    public class AddThisNumbersResponse : HeaderMessage
    {
        public int Value { get; set; }
    }
}