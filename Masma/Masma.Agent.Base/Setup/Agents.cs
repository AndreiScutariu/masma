using System.Collections.Generic;

namespace Masma.Common.Setup
{
    public static class Agents
    {
        private static readonly List<string> _all = new List<string>();

        public static string[] All => _all.ToArray();

        public static void Add(string agentName)
        {
            _all.Add(agentName);
        }
    }
}