﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomKeyLogger2
{
    class helper
    {
        public static string ToBinary(Int64 Decimal)
        {

            // Declare a few variables we're going to need

            Int64 BinaryHolder;

            char[] BinaryArray;

            string BinaryResult = "";
            while (Decimal > 0)
            {

                BinaryHolder = Decimal % 2;

                BinaryResult += BinaryHolder;

                Decimal = Decimal / 2;

            }


            // The algoritm gives us the binary number in reverse order (mirrored)

            // We store it in an array so that we can reverse it back to normal

            BinaryArray = BinaryResult.ToCharArray();

            Array.Reverse(BinaryArray);

            BinaryResult = new string(BinaryArray);


            return BinaryResult;

        }
    }
}
