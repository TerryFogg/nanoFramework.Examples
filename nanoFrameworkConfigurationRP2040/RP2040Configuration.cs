using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace nanoFrameworkConfigurationRP2040
{
    [Serializable]
    public static class RP2040Configuration
    {


        static RP2040Configuration()
        {

            Debug.WriteLine("Hello from RP2040Configuration");

        }
        public static byte xx = 0xde;

        /// <summary>
        /// Place a known series of bytes at the begining of the block as a valid configuration block in memory
        /// </summary>
        [SerializationHints(ArraySize = 16, Options = SerializationOptions.PointerNeverNull)]
        public static char[] charSignature = new char[16] { 'n', 'a', 'n', 'o', 'F', 'r', 'a', 'm', 'e', 'w', 'o', 'r', 'k', '1', '0', '0' };



        [SerializationHints(Options = SerializationOptions.PointerNeverNull | SerializationOptions.ElementsNeverNull | SerializationOptions.FixedType)]
        public static bool UseGraphics = true;
        //    [SerializationHints(ArraySize = 16, Options = SerializationOptions.PointerNeverNull)]
        //    public char[] GraphicsDriverName = new char[16] { 'L', 'C', 'D', '-', '1', '.', '1', '4', ' ', ' ', ' ', ' ', ' ',' ',' ',' '};


        //    [SerializationHints(ArraySize = 10, Options = SerializationOptions.PointerNeverNull)]
        //    public byte[] byteType = new byte[10];

    }
}
