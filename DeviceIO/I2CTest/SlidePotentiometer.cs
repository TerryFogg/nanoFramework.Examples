using System;
using System.Device.I2c;
namespace DeviceSlidePotentiometer
{
    public class SlidePotentiometer
    {
        I2cConnectionSettings i2cSettings { get; set; }
        I2cDevice i2cDevice { get; set; }

        // One byte for an 8 bit register and one byte for an 8 bit value
        byte[] RegisterCommand = new byte[2];

        public class Register
        {
            public const byte ChipIdentifier = 0x1;
            public const byte pot_value = 0x5;
        }
        public SlidePotentiometer(int busId, int I2cAddress)
        {
            I2cTransferResult result;
            const short ChipInternalIdentifier = 411;
            i2cSettings = new I2cConnectionSettings(busId, I2cAddress);
            i2cDevice = I2cDevice.Create(i2cSettings);


            // Check the chip is correct
            {
                SpanByte writeSpanByteInternalIdentifier = new byte[1] { 2 };
                SpanByte readSpanByteResult = new byte[2];

                result = i2cDevice.WriteRead(writeSpanByteInternalIdentifier, readSpanByteResult);
                short chipIdentfierRead = (short)(readSpanByteResult[0] << 8 |readSpanByteResult[1]);
                if (chipIdentfierRead !=  ChipInternalIdentifier)
                {
                    throw new Exception($"Chip identifier mismatch, return value is {chipIdentfierRead}");
                }
            }
        }
        public short ReadSlideValue()
        {
            I2cTransferResult result;
            SpanByte writeSpanByte = new byte[1] { Register.pot_value };
            SpanByte readSpanByteResult = new byte[2];
            result = i2cDevice.WriteRead(writeSpanByte, readSpanByteResult);
            short adcValue = (short)(readSpanByteResult[0] << 8 |readSpanByteResult[1]);
            return adcValue;
        }
        internal void Finish()
        {
            i2cDevice.Dispose();
        }
    }
}
