using System;
using System.Device.Gpio;
using System.Device.I2c;
using System.Diagnostics;
using System.Threading;
using static GPIOTest.RP2XXX;
using static GPIOTest.RP2XXX.PICO2;

namespace GPIOTest
{
    public class Program
    {
        static GpioController gpioController = new GpioController();

        public static void Main()
        {
            Debug.WriteLine("Testing GPIO on Raspberry PI RP2350");
            I2CTest();
        }
        static void I2CTest()
        {
            GpioPin gpioPin8 = gpioController.OpenPin(GP8.Gpio);
            GpioPin gpioPin9 = gpioController.OpenPin(GP9.Gpio);

            // Both these do the same thing but use different native code calls
            gpioController.SetPinMode(GP8.I2C0_SDA, (PinMode)PinFunction.I2C);
            gpioPin8.SetPinMode((PinMode)PinFunction.I2C);

            gpioController.SetPinMode(GP9.I2C0_SCL, (PinMode)PinFunction.I2C);
            gpioPin9.SetPinMode((PinMode)PinFunction.I2C);

            int deviceAddress = 0x17;
            I2cConnectionSettings I2CSettings = new I2cConnectionSettings(I2C.I2C0, deviceAddress, I2cBusSpeed.StandardMode);
            I2cDevice i2cDevice = I2cDevice.Create(I2CSettings);
            i2cDevice.WriteByte(0);


        }
    }
}



using System;

using nanoframework.Hardware;
using static nanoframework.Hardware.PICO2;

namespace Test
{
    /// <summary>
    /// 
    /// </summary>
    public class test
    {
        /// <summary>
        /// 
        /// </summary>
        public void test1()
        {
            GP0 gp0 = new GP0();
            gp0.SetPinFunction(GP0.PinFunction.UART0_TX);

            GP0 gp1 = new GP0();
            gp0.SetPinFunction(GP1.PinFunction.UART0_TX);


        }

    }
}
