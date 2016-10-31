using Masma.Messages.Common;

namespace Masma.Lab3.Messages
{
    public class CostOfProductRequest : HeaderMessage
    {
        public int ProductId { get; set; }
    }
}