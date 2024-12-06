using System;
using System.Diagnostics;
using System.Threading;
using System.Device.I2c;
using nanoFramework.Hardware.Stm32;

namespace I2CTest
{
    public class Program
    {
        public static void Main()
        {
            //Configuration.SetPinFunction(21, DeviceFunction.I2C1_DATA);
            //Configuration.SetPinFunction(22, DeviceFunction.I2C1_CLOCK);

            Debug.WriteLine("Hello from I2C Scanner!");
            SpanByte spanWrite = new byte[1] { 0xA8 };
            SpanByte spanRead = new byte[1];
            bool isDevice = false;

            while (true)
            {
                I2cDevice i2c1 = new(new I2cConnectionSettings(4, 0x54,I2cBusSpeed.StandardMode));
                var res1 = i2c1.WriteRead(spanWrite, spanRead);
            }


            // On a normal bus, not all those ranges are supported but scanning anyway
            for (int i = 0; i <= 0xFF; i++)
            {
                isDevice = false;
                I2cDevice i2c = new(new I2cConnectionSettings(1, i));
                // What we write is not important
                var res = i2c.WriteByte(0x07);
                // A successfull write will be: 0x10 Write: 1, transferred: 1
                // A non successful one: 0x0F Write: 4, transferred: 0
                Debug.Write($"0x{i:X2} Write: {res.Status}, transferred: {res.BytesTransferred}");
                isDevice = res.Status == I2cTransferStatus.FullTransfer;

                // What we read doesn't matter, reading only 1 element is what's needed
                res = i2c.Read(spanRead);
                // A successfull write will be: Read: 1, transferred: 1
                // A non successfull one: Read: 2, transferred: 0
                Debug.WriteLine($", Read: {res.Status}, transferred: {res.BytesTransferred}");

                // For most devices, success should be when you can write and read
                // Now, this can be adjusted with just read or write depending on the
                // device you are looking for
                isDevice &= res.Status == I2cTransferStatus.FullTransfer;
                Debug.WriteLine($"0x{i:X2} - {(isDevice ? "Present" : "Absent")}");

                // Just force to dispose so we can use the next one
                i2c.Dispose();
            }




            Thread.Sleep(Timeout.Infinite);
        }
    }
}


