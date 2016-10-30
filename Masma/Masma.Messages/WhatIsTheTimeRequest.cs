using Masma.Messages.Common;

namespace Masma.Messages
{
    public class WhatIsTheTimeRequest : HeaderMessage
    {
        public string Value { get; set; }
    }
}