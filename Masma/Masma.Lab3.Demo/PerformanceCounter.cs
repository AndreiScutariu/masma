using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Masma.Lab3.Demo
{
    public class PerformanceCounter
    {
        private static readonly long Frecv;
        private static long _t1, _t2;

        static PerformanceCounter()
        {
            _t1 = 0;
            _t2 = 0;
            Frecv = 0;
            var init = QueryPerformanceFrequency(out Frecv);
            if (!init)
                throw new Exception("Performance counters not initialized");
            Reset();
        }

        [DllImport("kernel32", EntryPoint = "QueryPerformanceFrequency")]
        [SuppressUnmanagedCodeSecurity]
        private static extern bool QueryPerformanceFrequency(out long lpPerformanceFreq);

        [DllImport("kernel32", EntryPoint = "QueryPerformanceCounter")]
        [SuppressUnmanagedCodeSecurity]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        /// <summary>
        ///     Resets the counter
        /// </summary>
        public static void Reset()
        {
            QueryPerformanceCounter(out _t1);
        }

        /// <summary>
        ///     Gets the current counter value in seconds
        /// </summary>
        public static double GetValue()
        {
            QueryPerformanceCounter(out _t2);
            var difCounts = _t2 - _t1;
            var difSecs = difCounts/(double) Frecv;
            return difSecs;
        }
    }
}