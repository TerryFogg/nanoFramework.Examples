#define STM32H7B3I_DK


using System.Diagnostics;
using System.Device.Gpio;
using System.Threading;


#if STM32H735G_DK
 using GpioDefinitions =  nanoFramework.DeviceIO.STM32H735G_DK;
#elif STM32H7B3I_DK
 using GpioDefinitions = nanoFramework.DeviceIO.STM32H7B3I_DK;
#elif NUCLEO_H743ZI2
 using GpioDefinitions = nanoFramework.DeviceIO.STM32H7B3I_DK;
#endif


namespace DeviceIOTest
{
    internal class GpioSTM32H7
    {
        GpioController gpioController { get; set; }
        int[] PinValues = new int[]
        {
            GpioDefinitions.ArduinoConnector.D0,
            GpioDefinitions.ArduinoConnector.D1,
            GpioDefinitions.ArduinoConnector.D2,
            GpioDefinitions.ArduinoConnector.D3,
            GpioDefinitions.ArduinoConnector.D4,
            GpioDefinitions.ArduinoConnector.D5,
            GpioDefinitions.ArduinoConnector.D6,
            GpioDefinitions.ArduinoConnector.D7,
            GpioDefinitions.ArduinoConnector.D8,
            GpioDefinitions.ArduinoConnector.D9,
            GpioDefinitions.ArduinoConnector.D10,
            GpioDefinitions.ArduinoConnector.D11,
            GpioDefinitions.ArduinoConnector.D12,
            GpioDefinitions.ArduinoConnector.D13,
            GpioDefinitions.ArduinoConnector.D14,
            GpioDefinitions.ArduinoConnector.D15,
        };

        public GpioSTM32H7()
        {
            gpioController = new GpioController();
        }
        public void Start()
        {
            GpioPin[] arduinoDigitalPins = new GpioPin[15];

            for (int iPin = 0; iPin < 16; iPin++)
            {
                arduinoDigitalPins[iPin] = gpioController.OpenPin(PinValues[iPin], PinMode.Output);
            }

            do
            {
                arduinoDigitalPins[0].Write(PinValue.High);
                arduinoDigitalPins[1].Write(PinValue.High);
                arduinoDigitalPins[3].Write(PinValue.High);
                arduinoDigitalPins[4].Write(PinValue.High);
                arduinoDigitalPins[5].Write(PinValue.High);
                arduinoDigitalPins[6].Write(PinValue.High);
                arduinoDigitalPins[7].Write(PinValue.High);
                arduinoDigitalPins[8].Write(PinValue.High);
                arduinoDigitalPins[9].Write(PinValue.High);
                arduinoDigitalPins[10].Write(PinValue.High);
                arduinoDigitalPins[11].Write(PinValue.High);
                arduinoDigitalPins[12].Write(PinValue.High);
                arduinoDigitalPins[13].Write(PinValue.High);
                arduinoDigitalPins[14].Write(PinValue.High);
                arduinoDigitalPins[15].Write(PinValue.High);

                //Debug.Write("High");
                //Thread.Sleep(300);

                arduinoDigitalPins[0].Write(PinValue.Low);
                arduinoDigitalPins[1].Write(PinValue.Low);
                arduinoDigitalPins[3].Write(PinValue.Low);
                arduinoDigitalPins[4].Write(PinValue.Low);
                arduinoDigitalPins[5].Write(PinValue.Low);
                arduinoDigitalPins[6].Write(PinValue.Low);
                arduinoDigitalPins[7].Write(PinValue.Low);
                arduinoDigitalPins[8].Write(PinValue.Low);
                arduinoDigitalPins[9].Write(PinValue.Low);
                arduinoDigitalPins[10].Write(PinValue.Low);
                arduinoDigitalPins[11].Write(PinValue.Low);
                arduinoDigitalPins[12].Write(PinValue.Low);
                arduinoDigitalPins[13].Write(PinValue.Low);
                arduinoDigitalPins[14].Write(PinValue.Low);
                arduinoDigitalPins[15].Write(PinValue.Low);

                Debug.Write("Low");
                Thread.Sleep(300);

            } while (true);
        }
    }
}