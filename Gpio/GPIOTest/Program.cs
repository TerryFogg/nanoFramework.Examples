using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;
using static nanoFramework.GpioEx.RP2XXX;

namespace GPIOTest
{
    public class Program
    {
        static GpioController gpioController = new GpioController();

        public static void Main()
        {
            Debug.WriteLine("Testing GPIO on Raspberry PI RP2350");
            InputReadTest();
        }
        public static void InputReadTest()
        {
            Debug.WriteLine("Testing GPIO on Raspberry PI RP2350");

            nanoFramework.GpioEx.RP2XXX.GP16.PinFunction(Pi)

            GpioPin gpioPin0 = gpioController.OpenPin(GP0.Gpio, PinMode.InputPullUp);
            GpioPin gpioPin1 = gpioController.OpenPin(GP1.Gpio, PinMode.Input);
            GpioPin gpioPin2 = gpioController.OpenPin(GP2.Gpio, PinMode.Input);
            GpioPin gpioPin3 = gpioController.OpenPin(GP3.Gpio, PinMode.Input);
            GpioPin gpioPin4 = gpioController.OpenPin(GP4.Gpio, PinMode.Input);
            GpioPin gpioPin5 = gpioController.OpenPin(GP5.Gpio, PinMode.Input);
            GpioPin gpioPin6 = gpioController.OpenPin(GP6.Gpio, PinMode.Input);
            GpioPin gpioPin7 = gpioController.OpenPin(GP7.Gpio, PinMode.Input);
            GpioPin gpioPin8 = gpioController.OpenPin(GP8.Gpio, PinMode.Input);
            GpioPin gpioPin9 = gpioController.OpenPin(GP9.Gpio, PinMode.Input);
            GpioPin gpioPin10 = gpioController.OpenPin(GP10.Gpio, PinMode.Input);
            GpioPin gpioPin11 = gpioController.OpenPin(GP11.Gpio, PinMode.Input);
            GpioPin gpioPin12 = gpioController.OpenPin(GP12.Gpio, PinMode.Input);
            GpioPin gpioPin13 = gpioController.OpenPin(GP13.Gpio, PinMode.Input);
            GpioPin gpioPin14 = gpioController.OpenPin(GP14.Gpio, PinMode.Input);
            GpioPin gpioPin15 = gpioController.OpenPin(GP15.Gpio, PinMode.Input);
            GpioPin gpioPin16 = gpioController.OpenPin(GP16.Gpio, PinMode.Input);
            GpioPin gpioPin17 = gpioController.OpenPin(GP17.Gpio, PinMode.Input);
            GpioPin gpioPin18 = gpioController.OpenPin(GP18.Gpio, PinMode.Input);
            GpioPin gpioPin19 = gpioController.OpenPin(GP19.Gpio, PinMode.Input);
            GpioPin gpioPin20 = gpioController.OpenPin(GP20.Gpio, PinMode.Input);
            GpioPin gpioPin21 = gpioController.OpenPin(GP21.Gpio, PinMode.Input);
            GpioPin gpioPin22 = gpioController.OpenPin(GP22.Gpio, PinMode.Input);
            GpioPin gpioPin26 = gpioController.OpenPin(GP26.Gpio, PinMode.Input);
            GpioPin gpioPin27 = gpioController.OpenPin(GP27.Gpio, PinMode.Input);
            GpioPin gpioPin28 = gpioController.OpenPin(GP28.Gpio, PinMode.Input);

            while (true)
            {
                if (gpioPin0.Read() == true)
                {
                    Debug.WriteLine("gpioPin0 High");
                }
                if (gpioPin1.Read() == true)
                { 
                    Debug.WriteLine("gpioPin1 High"); 
                }
                if (gpioPin2.Read() == true)
                { Debug.WriteLine("gpioPin2 High");
                }
                if (gpioPin3.Read() == true)
                { Debug.WriteLine("gpioPin3 High");
                }
                if (gpioPin4.Read() == true)
                { Debug.WriteLine("gpioPin4 High"); 
                }
                if (gpioPin5.Read() == true)
                { Debug.WriteLine("gpioPin5 High"); 
                }
                if (gpioPin6.Read() == true)
                { Debug.WriteLine("gpioPin6 High");
                }
                if (gpioPin7.Read() == true)
                { Debug.WriteLine("gpioPin7 High");
                }
                if (gpioPin8.Read() == true)
                { Debug.WriteLine("gpioPin8 High");
                }
                if (gpioPin10.Read()== true)
                { Debug.WriteLine("gpioPin10 High"); 
                }
                if (gpioPin11.Read()== true)
                { Debug.WriteLine("gpioPin11 High"); 
                }
                if (gpioPin13.Read()== true)
                { Debug.WriteLine("gpioPin13 High");
                }
                if (gpioPin14.Read()== true)
                { Debug.WriteLine("gpioPin14 High");
                }
                if (gpioPin15.Read()== true)
                { Debug.WriteLine("gpioPin15 High"); 
                }
                if (gpioPin16.Read()== true)
                { Debug.WriteLine("gpioPin16 High"); 
                }
                if (gpioPin17.Read()== true)
                { Debug.WriteLine("gpioPin17 High"); 
                }
                if (gpioPin18.Read()== true)
                { Debug.WriteLine("gpioPin18 High");
                }
                if (gpioPin19.Read()== true)
                { Debug.WriteLine("gpioPin19 High");
                }
                if (gpioPin20.Read()== true)
                { Debug.WriteLine("gpioPin20 High"); 
                }
                if (gpioPin21.Read()== true)
                { Debug.WriteLine("gpioPin21 High"); 
                }
                if (gpioPin22.Read()== true)
                { Debug.WriteLine("gpioPin22 High"); 
                }
                if (gpioPin26.Read()== true)
                { Debug.WriteLine("gpioPin26 High"); 
                }
                if (gpioPin27.Read()== true)
                { Debug.WriteLine("gpioPin27 High"); 
                }
                if (gpioPin28.Read()== true) 
                { Debug.WriteLine("gpioPin28 High"); 
                }
            }
            //            if (gpioPin9.Read() == true) Debug.WriteLine("gpioPin9  High");
            //            if (gpioPin12.Read()== true) Debug.WriteLine("gpioPin12 High");
        }
        private static void ReadPin(GpioPin gpioPin)
        {
            PinValue p = gpioPin.Read();
            Debug.WriteLine(p.ToString());
        }
        public static void OutputTest()
        {
            Debug.WriteLine("Testing GPIO on Raspberry PI RP2350");

            GpioController gpioController = new GpioController();
            GpioPin gpioPin0 = gpioController.OpenPin(GP27.PinNumber, PinMode.Output);
            GpioPin gpioPin1 = gpioController.OpenPin(GP28.Gpio, PinMode.Output);
            GpioPin gpioPin2 = gpioController.OpenPin(GP18.Gpio, PinMode.Output);
            GpioPin gpioPin3 = gpioController.OpenPin(GP19.Gpio, PinMode.Output);
            GpioPin gpioPin4 = gpioController.OpenPin(GP20.Gpio, PinMode.Output);
            GpioPin gpioPin5 = gpioController.OpenPin(GP21.Gpio, PinMode.Output);
            GpioPin gpioPin6 = gpioController.OpenPin(GP22.Gpio, PinMode.Output);
            GpioPin gpioPin7 = gpioController.OpenPin(GP26.Gpio, PinMode.Output);

            while (true)
            {
                gpioPin0.Write(PinValue.High);
                gpioPin1.Write(PinValue.High);
                gpioPin2.Write(PinValue.High);
                gpioPin3.Write(PinValue.High);
                gpioPin4.Write(PinValue.High);
                gpioPin5.Write(PinValue.High);
                gpioPin6.Write(PinValue.High);
                gpioPin7.Write(PinValue.High);

                gpioPin0.Write(PinValue.Low);
                gpioPin1.Write(PinValue.Low);
                gpioPin2.Write(PinValue.Low);
                gpioPin3.Write(PinValue.Low);
                gpioPin4.Write(PinValue.Low);
                gpioPin5.Write(PinValue.Low);
                gpioPin6.Write(PinValue.Low);
                gpioPin7.Write(PinValue.Low);
            }
        }
    }
}

