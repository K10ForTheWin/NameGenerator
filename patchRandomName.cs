using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGenerator
{
    public class patchRandomName
    {
        internal static void Postfix(ref string __source)
        {
            source = "Meowdy";
        }
    }
}