using System;

namespace Masma.Messages.Common
{
    public interface IMessage
    {
        Guid CorrelationId { get; set; }

        Type Type { get; set; }
    }
}