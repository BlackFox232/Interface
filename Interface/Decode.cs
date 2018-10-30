using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    static class Decode
    {
        static public byte[] GetDecodeValues(byte[] val)
        {
            byte[] _val = new byte[val.Length - 4];
            int cnt = 0;
            int i = 0;

            foreach (var item in val)
            {
                if (cnt == 1 || cnt == 0)
                {

                }
                else if (cnt == val.Length - 1 || cnt == val.Length - 2)
                {

                }
                else
                {
                    _val[i] = item;
                    i++;
                }
                cnt++;
            }

            return _val;
        }

    }
}
