using System;
using System.Diagnostics;
using System.Threading;
using System.Device.Gpio;

using Device = nanoFramework.Device.RP2XXX;
//using Device = nanoFramework.Device.STM32H7;

namespace GpioTest
{
    public class Tests
    {
        static GpioController gpioController;
        internal Tests()
        {
            gpioController = new GpioController();
        }
        internal void TestPinCount()
        {
            int PinCount = gpioController.PinCount;
            Debug.WriteLine($"Pin Count = {PinCount}");
        }
        internal void IsPinModeSupported(int pinNumber, PinMode requestedGpioMode)
        {
            try
            {
                bool pinModeSupported = gpioController.IsPinModeSupported(pinNumber, requestedGpioMode);
                if (pinModeSupported)
                {
                    Debug.WriteLine($"Pin:{pinNumber},mode {requestedGpioMode} support is {pinModeSupported}");
                }
            }
            catch
            {
                Debug.WriteLine($"Pin {requestedGpioMode} support through an exception");
            }
        }
        internal void TestOutputMode(int pinNumber, PinMode requestedGpioMode)
        {
            if (!gpioController.IsPinModeSupported(pinNumber, requestedGpioMode))
            {
                Debug.WriteLine($"Gpio pin {pinNumber} {requestedGpioMode} output mode not supported");
                return;
            }
            if (gpioController.IsPinOpen(pinNumber))
            {
                Debug.WriteLine($"Gpio pin {pinNumber} is already open ( reserved)");
                return;
            }
            // toggle 
            GpioPin gpioPin = gpioController.OpenPin(pinNumber, requestedGpioMode);
            for (int i = 0; i<10; i++)
            {
                Debug.WriteLine($"Write gpio pin {pinNumber} high");
                gpioPin.Write(PinValue.High);
                Thread.Sleep(200);
                Debug.WriteLine($"Write gpio pin {pinNumber} low");
                gpioPin.Write(PinValue.Low);
                Thread.Sleep(200);
            }

            Debug.WriteLine($"Now use the Toggle function for {pinNumber}");
            for (int i = 0; i<30; i++)
            {
                gpioPin.Toggle();
                Thread.Sleep(100);
            }
        }
        internal void TestInputModes(int pinNumber, PinMode pinMode)
        {
            GpioPin pin = gpioController.OpenPin(pinNumber);

            try
            {
                bool supportsOutputMode = pin.IsPinModeSupported(pinMode);
                if (supportsOutputMode)
                {
                    pin.SetPinMode(pinMode);
                    Debug.WriteLine($"Waiting for input on pin number: {pinNumber}");
                    int countOfdetectedHighs = 0;
                    while (countOfdetectedHighs < 5)
                    {
                        PinValue value = pin.Read();
                        Debug.WriteLine($"Pin Number Value: {value}");
                    }
                }
                else
                {
                    Debug.WriteLine($"Input mode {pinMode} not supported on this pin number: {pinNumber}");
                }
            }
            catch (InvalidOperationException)
            {
                Debug.WriteLine($"Invalid pin number or other internal problem: {pinNumber}");
            }
        }
        internal void TestPinInputWithDebounce(int pinNumber)
        {
            gpioController.OpenPin(pinNumber, PinMode.Input);
            for (int i = 0; i<20; i++)
            {
                Debug.WriteLine($"Input");
                gpioController.Write(pinNumber, PinValue.High);
                Thread.Sleep(500);
                gpioController.Write(pinNumber, PinValue.Low);
            }
        }
    }
}