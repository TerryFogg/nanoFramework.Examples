using System;
using System.Diagnostics;
using System.Threading;
using System.Device.Gpio;

using GpioDefinitions = nanoFramework.DeviceIO.STM32H7B3I_DK;
using static nanoFramework.DeviceIO.STM32H7;

namespace DeviceIOTest
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            GpioController gpioController = new GpioController();

            TestInterruptInputs(gpioController);

            //TestBasicInputs(gpioController);
            //TestOutputs(gpioController);
            //TestInputInterrupts(gpioController);

            Thread.Sleep(Timeout.Infinite);
        }

        private static void TestInterruptInputs(GpioController gpioController)
        {
            GpioPin pinD0 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D0, PinMode.Input);
            pinD0.ValueChanged+=PinD0_ValueChanged;
        }

        private static void PinD0_ValueChanged(object sender, PinValueChangedEventArgs e)
        {
            switch (e.ChangeType)
            {
                case PinEventTypes.Rising:
                    Debug.WriteLine("Rising");
                    break;
                case PinEventTypes.Falling:
                    Debug.WriteLine("Falling");
                    break;
                case PinEventTypes.None:
                    Debug.WriteLine("None");
                    break;
                default:
                    Debug.WriteLine("Unknown");
                    break;
            }
        }

        private static void TestInputInterrupts(GpioController gpioController)
        {
            //  NOTE:

            //  D10 = PinNameValue.PI0;	0	1	1	1
            //  D4 = PinNameValue.PE2;	2	2	2	2
            //  D9 = PinNameValue.PI7;	7	3	3	3
            //  D2 = PinNameValue.PI9;	9	4		
            //  D3 = PinNameValue.PH9;	9		4	4
            //  D6 = PinNameValue.PH10;	10	5		
            //  D7 = PinNameValue.PI10;	10		5	
            //  D8 = PinNameValue.PF10;	10			5
            //  D5 = PinNameValue.PH11;	11	6	6	6
            //  D13 = PinNameValue.PA12;	12	7	7	7
            //  D1 = PinNameValue.PH13;	13	8	8	8
            //  D0 = PinNameValue.PH14;	14	9		
            //  D12 = PinNameValue.PB14;	14		9	9
            //  D11 = PinNameValue.PB15;	15	10	10	10
            //  D14 = PinNameValue.PD13; I2c
            //  D15 = PinNameValue.PD12; I2c
        }

        private static void TestOutputs(GpioController gpioController)
        {
            GpioPin pinD0 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D0, PinMode.Output);
            GpioPin pinD1 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D1, PinMode.Output);
            GpioPin pinD2 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D2, PinMode.Output);
            GpioPin pinD3 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D3, PinMode.Output);
            GpioPin pinD4 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D4, PinMode.Output);
            GpioPin pinD5 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D5, PinMode.Output);
            GpioPin pinD6 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D6, PinMode.Output);
            GpioPin pinD7 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D7, PinMode.Output);
            GpioPin pinD8 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D8, PinMode.Output);
            GpioPin pinD9 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D9, PinMode.Output);
            GpioPin pinD10 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D10, PinMode.Output);
            GpioPin pinD11 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D11, PinMode.Output);
            GpioPin pinD12 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D12, PinMode.Output);
            GpioPin pinD13 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D13, PinMode.Output);

            TestWrite(pinD2);
            TestWrite(pinD3);
            TestWrite(pinD4);
            TestWrite(pinD5);
            TestWrite(pinD6);
            TestWrite(pinD7);
            TestWrite(pinD8);
            TestWrite(pinD9);
            TestWrite(pinD11);
            TestWrite(pinD12);
            TestWrite(pinD13);
        }

        static void TestWrite(GpioPin pin)
        {
            pin.Write(PinValue.High);
            pin.Write(PinValue.Low);
            pin.Write(PinValue.High);
            pin.Write(PinValue.Low);
        }

        private static void TestBasicInputs(GpioController gpioController)
        {
            GpioPin pinD0 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D0, PinMode.Input);
            GpioPin pinD1 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D1, PinMode.Input);
            GpioPin pinD2 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D2, PinMode.Input);
            GpioPin pinD3 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D3, PinMode.Input);
            GpioPin pinD4 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D4, PinMode.Input);
            GpioPin pinD5 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D5, PinMode.Input);
            GpioPin pinD6 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D6, PinMode.Input);
            GpioPin pinD7 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D7, PinMode.Input);
            GpioPin pinD8 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D8, PinMode.Input);
            GpioPin pinD9 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D9, PinMode.Input);
            GpioPin pinD10 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D10, PinMode.Input);
            GpioPin pinD11 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D11, PinMode.Input);
            GpioPin pinD12 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D12, PinMode.Input);
            GpioPin pinD13 = gpioController.OpenPin(GpioDefinitions.ArduinoConnector.D13, PinMode.Input);

            TestRead(pinD0);
            TestRead(pinD1);
            TestRead(pinD2);

            TestRead(pinD3);
            TestRead(pinD4);
            TestRead(pinD5);
            TestRead(pinD6);
            TestRead(pinD7);
            TestRead(pinD8);
            TestRead(pinD9);
            TestRead(pinD10);
            TestRead(pinD11);
            TestRead(pinD12);
            TestRead(pinD13);





        }

        private static void TestRead(GpioPin pinValue)
        {
            Debug.WriteLine(pinValue.Read().ToString());
            Debug.WriteLine(pinValue.Read().ToString());
            Debug.WriteLine(pinValue.Read().ToString());

        }
    }
}
