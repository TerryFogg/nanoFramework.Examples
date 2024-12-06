using System;
using System.Diagnostics;
using System.Threading;
using nanoFramework.Hardware.Esp32;
using nanoFramework.UI;
using ct = ColourTests.ColourTests;
using nanoFramework.UI.GraphicDrivers;


namespace Esp32Wrover
{
    public class Program
    {
        public static void Main()
        {
            SetupHardwareForSpiTFTDisplay();
            ct.StartColourTests();
            Thread.Sleep(Timeout.Infinite);
        }
        public static void SetupHardwareForSpiTFTDisplay()
        {
            const int BackLightPin = 5;
            const int DataCommand = 21;
            const int Reset = 18;

            // LCD connected to ESP32 HSPI channel 2 
            const byte SPI_BUS = 1;
            const int SPI_MOSI = 23;
            const int SPI_MISO = 25;
            const int SPI_CLOCK = 19;
            const int ChipSelect = 22;

            const int DisplayXStartOffset = 0;
            const int DisplayYStartOffset = 0;
            const int DisplayWidth = 320;
            const int DisplayHeight = 240;
            const int GraphicsReservedMemory = 2 * 1024 * 1024;

            Configuration.SetPinFunction(SPI_MISO, DeviceFunction.SPI1_MISO);
            Configuration.SetPinFunction(SPI_MOSI, DeviceFunction.SPI1_MOSI);
            Configuration.SetPinFunction(SPI_CLOCK, DeviceFunction.SPI1_CLOCK);

            GraphicDriver BoardDisplay = Ili9341.GraphicDriver;
            DisplayControl.Initialize(new SpiConfiguration(SPI_BUS, ChipSelect, DataCommand, Reset, BackLightPin),
                                      new ScreenConfiguration(DisplayXStartOffset, DisplayYStartOffset, DisplayWidth, DisplayHeight, BoardDisplay), GraphicsReservedMemory);

            ////
            //int backLightPin = 5;
            //int chipSelect = 22;
            //int dataCommand = 21;
            //int reset = 18;

            //Configuration.SetPinFunction(25, DeviceFunction.SPI1_MISO);
            //Configuration.SetPinFunction(23, DeviceFunction.SPI1_MOSI);
            //Configuration.SetPinFunction(19, DeviceFunction.SPI1_CLOCK);

            //// Adjust as well the size of your screen and the position of the screen on the driver
            //DisplayControl.Initialize(new SpiConfiguration(1, chipSelect, dataCommand, reset, backLightPin), new ScreenConfiguration(0, 0, 320, 240), 2 * 1024 * 1024);

        }
    }
}
