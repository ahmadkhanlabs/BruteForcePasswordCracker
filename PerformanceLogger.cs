using System;
using System.Text;

namespace BruteForcePasswordCracker
{
    public class PerformanceLogger
    {
        public long SingleThreadedMs { get; private set; }
        public long MultiThreadedMs { get; private set; }

        public void Record(long singleThreadedMs, long multiThreadedMs)
        {
            SingleThreadedMs = singleThreadedMs;
            MultiThreadedMs = multiThreadedMs;
        }

        public string GetReport()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("Performance Comparison:");
            report.AppendLine($"Single-threaded: {SingleThreadedMs} ms");
            report.AppendLine($"Multi-threaded:  {MultiThreadedMs} ms");

            if (MultiThreadedMs > 0)
            {
                double speedup = (double)SingleThreadedMs / MultiThreadedMs;
                report.AppendLine($"Speedup: {speedup:F2}x faster");
            }

            return report.ToString();
        }
    }
}