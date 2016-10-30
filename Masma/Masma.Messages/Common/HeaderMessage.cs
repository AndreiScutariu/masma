using System;

namespace Masma.Messages.Common
{
    public class HeaderMessage : IMessage
    {
        public HeaderMessage()
        {
            Type = GetType();
        }

        public Guid CorrelationId { get; set; }

        public Type Type { get; set; }
    }
}