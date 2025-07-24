using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperEditor
{
    public static class Helper
    {
        public static uint ComputeStringHash(string s)
        {
            if (s == null)
                return 0;

            uint hash = 2166136261u;
            for (int i = 0; i < s.Length; i++)
                hash = (hash ^ s[i]) * 16777619;
            return hash;
        }
    }
}
