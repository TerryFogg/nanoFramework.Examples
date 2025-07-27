using System;
using System.Device.I2c;
namespace DeviceBuzzerP18
{
    public class BuzzerP18
    {
        I2cConnectionSettings i2cSettings { get; set; }
        I2cDevice i2cDevice { get; set; }

        public class Register
        {
            public const byte _regDevID = 0x11;
            public const byte _regStatus = 0x01;
            public const byte _regI2cAddr = 0x04;
            public const byte _regTone = 0x05;
            public const byte _regVolume = 0x06;
            public const byte _regLed = 0x07;

            public const byte ChipInternalIdentifier = 0x51;
        }
        public static class Volume
        {
            public const byte Vol1 = 1;
            public const byte Vol2 = 2;
            public const byte Vol3 = 3;
        }
        public BuzzerP18(int busId, int I2cAddress)
        {
            i2cSettings = new I2cConnectionSettings(busId, I2cAddress);
            i2cDevice = I2cDevice.Create(i2cSettings);

            // Check the chip is correct
            byte chipIdentfierRead;
            if ((chipIdentfierRead= ReadBuzzerRegister(Register._regDevID)) !=  Register.ChipInternalIdentifier)
            {
                throw new Exception($"Chip identifier mismatch, return value is {chipIdentfierRead}");
            }
        }
        byte ReadBuzzerRegister(byte Register)
        {
            i2cDevice.Write(new byte[] { Register });
            return i2cDevice.ReadByte();
        }
        I2cTransferResult SetBuzzerRegister(byte register, byte value)
        {
            byte[] RegisterCommand = new byte[] { register, value };
            I2cTransferResult result = i2cDevice.Write(RegisterCommand);
            return result;
        }
        public void SetPowerOnLed(bool On)
        {
            byte value = (byte)(On ? 1 : 0);
            SetBuzzerRegister(Register._regLed, value);
        }
        public void SetTone(Int16 Frequency, Int16 Duration)
        {
            SpanByte writeFrequencyAndDuration = new byte[] { Register._regTone, (byte)(Frequency >> 8), (byte)(Frequency), (byte)(Duration >> 8), (byte)(Duration) };
            I2cTransferResult result = i2cDevice.Write(writeFrequencyAndDuration);
        }
        public void Mute()
        {
            SetTone(0, 0);
        }
        public byte Status()
        {
            return ReadBuzzerRegister(Register._regStatus);
        }
        internal void Finish()
        {
            i2cDevice.Dispose();
        }
    }
}
