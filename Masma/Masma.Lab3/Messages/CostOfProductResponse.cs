using Masma.Lab3.ProductRepository;
using Masma.Messages.Common;

namespace Masma.Lab3.Messages
{
    public class CostOfProductResponse : HeaderMessage
    {
        public Product Product { get; set; }
    }
}