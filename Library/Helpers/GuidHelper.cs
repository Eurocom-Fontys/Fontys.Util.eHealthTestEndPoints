using System;
using System.Collections.Generic;
using System.Text;

namespace EurocomFontysHealth.Library.Helpers
{
    public static class GuidHelper
    {
        public static Guid GenerateGuid(int a, short b = 0, short c = 0)
        {
            return new Guid(a, b, c, new byte[8]);
        }

        public static Guid? GetFromString(string val)
        {
            if (string.IsNullOrWhiteSpace(val)) { return null; }
            if(!Guid.TryParse(val, out var res))
            {
                return null;
            }
            return res;
        }
    }
}
