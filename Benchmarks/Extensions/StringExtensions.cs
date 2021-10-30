using System;

namespace Benchmarks.Extensions
{
    public static class StringExtensions
    {
        public static string ToEmail(this string name)
        {
            return name + "_" + Guid.NewGuid() + "@mail.com";
        }
    }
}
