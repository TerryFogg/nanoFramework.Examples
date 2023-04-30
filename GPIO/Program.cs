using System;
using System.Diagnostics;
using System.Threading;
using System.Device.Gpio;
using static nanoFramework.IO.RP2040.RP2040.GPIO;

namespace GPIO
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("GPIO example");

            GpioController gc = new GpioController();
            gc.OpenPin(Gpio0, PinMode.Output);

            bool WriteHigh = true;
            while (true)
            {
                if (WriteHigh)
                {
                    gc.Write(1, PinValue.High);
                }
                else
                {
                    gc.Write(1, PinValue.Low);
                }
                Thread.Sleep(1000);
                WriteHigh = !WriteHigh;
            }
        }

    }
}