using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickDeploy4.Data
{
    public static class DataExtensions
    {

        public static bool ToBoolean(this int val)
        {
            return val switch
            {
                0 => false,
                1 => true,
                _ => throw new InvalidOperationException("Invalid value for boolean conversion"),
            };
        }

    }
}
