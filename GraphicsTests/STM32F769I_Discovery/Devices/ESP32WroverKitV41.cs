//using System;

//using nanoFramework.Hardware.Esp32;
//using nanoFramework.UI;


//namespace nf_Colours
//{
//    internal class ESP32WroverKitV41 : IMicroController
//    {
//        public void DisplayInitialize()
//        {
//            int backLightPin = 5;
//            int chipSelect = 22;
//            int dataCommand = 21;
//            int reset = 18;

//            Configuration.SetPinFunction(25, DeviceFunction.SPI1_MISO);
//            Configuration.SetPinFunction(23, DeviceFunction.SPI1_MOSI);
//            Configuration.SetPinFunction(19, DeviceFunction.SPI1_CLOCK);

//            // Adjust as well the size of your screen and the position of the screen on the driver
//            DisplayControl.Initialize(new SpiConfiguration(1, chipSelect, dataCommand, reset, backLightPin), new ScreenConfiguration(0, 0, 320, 240), 2 * 1024 * 1024);
//        }
//    }
//}
