using System;
using System.Collections.Generic;
using System.Text;

namespace NetTools.Helpers
{
    class FormatToEUI
    {
        /// <summary>
        /// Format hexadecimals to EUI-48 address. Returns string.
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public string ToEUI48(string hex)
        {
            string newHex = String.Empty;
            if (hex.Length % 2 != 0 && hex.Length < 6)
            {
                return "Invalid MAC address";
            }
            for (int i = 0; i < hex.Length; i++)
            {
                if (i % 2 == 0 && i > 0)
                {
                    newHex += "-";
                }
                newHex += hex[i];
            }
            return newHex;
        }
    }
}
