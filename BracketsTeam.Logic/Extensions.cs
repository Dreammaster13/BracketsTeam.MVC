using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsTeam.Logic
{
    public static class Extensions
    {
        public static string Left(this string @this, int count)
        {
            return (@this.Length <= count ? @this : @this.Substring(0, count));
        }
    }
}
