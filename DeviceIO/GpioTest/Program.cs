#define RP2XXX
//#define STM32H7

using System;
using System.Threading;
using System.Diagnostics;
using System.Device.Gpio;


#if RP2XXX
using Device = nanoFramework.Device.RP2XXX;
public static class MCU
{
    public static int[] PinArray = { Device.GPIO.Gpio0,
                                     Device.GPIO.Gpio1,
                                     Device.GPIO.Gpio2,
                                     Device.GPIO.Gpio3,
                                     Device.GPIO.Gpio4,
                                     Device.GPIO.Gpio5,
                                     Device.GPIO.Gpio6,
                                     Device.GPIO.Gpio7,
                                     Device.GPIO.Gpio8,
                                     Device.GPIO.Gpio9,
                                     Device.GPIO.Gpio10,
                                     Device.GPIO.Gpio11,
                                     Device.GPIO.Gpio12,
                                     Device.GPIO.Gpio13,
                                     Device.GPIO.Gpio14,
                                     Device.GPIO.Gpio15,
                                     Device.GPIO.Gpio16,
                                     Device.GPIO.Gpio17,
                                     Device.GPIO.Gpio18,
                                     Device.GPIO.Gpio19,
                                     Device.GPIO.Gpio20,
                                     Device.GPIO.Gpio21,
                                     Device.GPIO.Gpio22,
                                     Device.GPIO.Gpio23,
                                     Device.GPIO.Gpio24,
                                     Device.GPIO.Gpio25,
                                     Device.GPIO.Gpio26,
                                     Device.GPIO.Gpio27,
                                     Device.GPIO.Gpio28,
                                     Device.GPIO.Gpio29
                                   };
}
#endif

#if STM32H7
public static class MCU
{

int[] PinArray = { Device.GPIO.PA0,
                 };
}
using Device = nanoFramework.Device.STM32H7;
#endif

// using Device = nanoFramework.Device.STM32H7;

// nanoFramework doesn't support enumerating enums,so load array for this
public static class GpioFeatures
{
    public static PinMode[] OutputPinModes = {
                                         PinMode.Output,
                                         PinMode.OutputOpenDrain,
                                         PinMode.OutputOpenDrainPullUp,
                                         PinMode.OutputOpenSource,
                                         PinMode.OutputOpenSourcePullDown
                                       };
    public static PinMode[] InputPinModes = { PinMode.Input,
                                         PinMode.InputPullDown,
                                         PinMode.InputPullUp
                                       };
}

namespace GpioTest
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            RPXXX_Test();

            Thread.Sleep(Timeout.Infinite);
        }
        private static void RPXXX_Test()
        {
            Tests ts = new Tests();

            // Check pin outputs
            ts.TestPinCount();

            // Check mode support for each pin
            foreach (int gpioPinNumber in MCU.PinArray)
            {
                foreach (PinMode pinMode in GpioFeatures.OutputPinModes)
                {
                    ts.IsPinModeSupported(gpioPinNumber, pinMode);
                }
                foreach (PinMode pinMode in GpioFeatures.InputPinModes)
                {
                    ts.IsPinModeSupported(gpioPinNumber, pinMode);
                }
            }

            // Check pin outputs
            foreach (int gpioPinNumber in MCU.PinArray)
            {
                if (!(gpioPinNumber == 23 || gpioPinNumber == 24 || gpioPinNumber == 25) && gpioPinNumber > 16)
                {
                    foreach (PinMode pinMode in GpioFeatures.OutputPinModes)
                    {
                        ts.TestOutputMode(gpioPinNumber, pinMode);
                    }
                }
            }

            //ts.TestPinOutput(Device.GPIO.Gpio1);

            //// Check pin inputs
            //ts.TestPinInputWithDebounce(Device.GPIO.Gpio0);

            //// Check pin inputs with debounce times
            //ts.TestPinInputWithDebounce(Device.GPIO.Gpio0);


        }
    }
}


//gpioController.RegisterCallbackForPinValueChangedEvent(
//    Device.GPIO.Gpio0,
//    PinEventTypes.Falling | PinEventTypes.Rising,
//    UserButton_ValueChanged);

