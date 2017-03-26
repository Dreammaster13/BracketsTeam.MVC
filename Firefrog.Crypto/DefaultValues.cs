using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firefrog.Crypto
{
    internal static class DefaultValues
    {
        internal static int SaltLength { get { return 16; } }
        internal static int HashLength { get { return 20; } }
        internal static int Iterations { get { return 10000; } }
    }
}
