using System;
using Masma.Messages.Common;

namespace Masma.Messages
{
    public class WhatIsTheTimeResponse : HeaderMessage
    {
        public string Value { get; set; }
    }
}