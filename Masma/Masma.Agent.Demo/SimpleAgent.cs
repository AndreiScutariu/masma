using System;
using System.Collections.Generic;
using Masma.Agent.Base;

namespace Masma.Agent.Demo
{
    public class SimpleAgent : BaseAgent
    {
        public override void setup()
        {
            logMyDetails();
        }
    }
}