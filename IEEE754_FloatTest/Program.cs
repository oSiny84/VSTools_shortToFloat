using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEEE754_FloatTest
{
    class Program
    {
        static float fVal;

        unsafe static float shortToFloat(ushort *msb, ushort *lsb)
        {
            uint merge;
            merge = (uint)((*msb) << 16 | (*lsb));
            return *((float*)&merge);
        }

        //https://gregstoll.dyndns.org/~gregstoll/floattohex/
         static void Main(string[] args)
        {
            //------------------
            Int16 iTest = 0x7FFF;
            Console.WriteLine("iValue 0xFFFF is {0}", iTest);

            //string hexString = "435CFDA2";
            string hexString = "1D8538A9";
            //  fe 7e 1a 45

            fVal = 2471.937f;

            uint num = uint.Parse(hexString, System.Globalization.NumberStyles.AllowHexSpecifier);
            byte[] floatVals = BitConverter.GetBytes(num);
            fVal = BitConverter.ToSingle(floatVals, 0);

            //fVal |= ((0x451A) << 16);
 
            Console.WriteLine("Float val is {0}", fVal);

            ushort a = 0x457A;// 0x435C;
            ushort b = 0x0;// 0xFDA2;
            float result;

            unsafe
            {
                result = shortToFloat(&a, &b);
                Console.WriteLine("Float val is {0}", result);
            }
        }
    }
}
