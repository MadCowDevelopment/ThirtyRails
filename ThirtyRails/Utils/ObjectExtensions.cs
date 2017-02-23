using System.Collections;
using System.Linq;

namespace ThirtyRails.Utils
{
    public static class ObjectExtensions
    {
        public static bool In(this object obj, params object[] items)
        {
            return items.Any(p => p.Equals(obj));
        }
    }
}