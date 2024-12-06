using System;
using System.Diagnostics;
using System.Threading;
using nanoFramework.Hardware.Esp32;
using nanoFramework.UI;
using ct = ColourTests.ColourTests;
using nanoFramework.UI.GraphicDrivers;
using System.Device.Gpio;

namespace ESP32GenericDisplay
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
            const int DataCommand = 22;
            const int Reset = 21;

             // LCD connected to ESP32 HSPI channel 2 
             const byte SPI_BUS = 2;
             const int SPI_MOSI = 13;
             const int SPI_MISO = 12;
             const int SPI_CLOCK = 14;
             const int ChipSelect = 15;


            const int DisplayXStartOffset = 0;
            const int DisplayYStartOffset = 0;
            const int DisplayWidth = 240;
            const int DisplayHeight = 240;
            const int GraphicsReservedMemory = 2 * 1024 * 1024;

            Configuration.SetPinFunction(SPI_MISO, DeviceFunction.SPI2_MISO);
            Configuration.SetPinFunction(SPI_MOSI, DeviceFunction.SPI2_MOSI);
            Configuration.SetPinFunction(SPI_CLOCK, DeviceFunction.SPI2_CLOCK);


            GraphicDriver BoardDisplay = ST7789.GraphicDriver;
            DisplayControl.Initialize(new SpiConfiguration(SPI_BUS, ChipSelect, DataCommand, Reset, BackLightPin),
                                      new ScreenConfiguration(DisplayXStartOffset, DisplayYStartOffset, DisplayWidth, DisplayHeight, BoardDisplay), GraphicsReservedMemory);


            // This board has an inverted backlight pin enable
            // Using standard code, all is black, need to set pin high to turn it on 
            
            GpioController gc = new GpioController();
            gc.OpenPin(BackLightPin, PinMode.Output);
            gc.Write(BackLightPin, PinValue.High);




        }
    }
}

//#if defined(ESP32_WROVER_KIT_V41)

//    DisplayInterfaceConfig displayConfig;
//    displayConfig.Spi.spiBus = 1; // Index into array of pin values ( spiBus - 1) == 0
//    displayConfig.Spi.chipSelect.pin = GPIO_NUM_22;
//    displayConfig.Spi.chipSelect.type.activeLow = true;
//    displayConfig.Spi.dataCommand.pin = GPIO_NUM_21;
//    displayConfig.Spi.dataCommand.type.commandLow = true;
//    displayConfig.Spi.reset.pin = GPIO_NUM_18;
//    displayConfig.Spi.reset.type.activeLow = true;
//    displayConfig.Spi.backLight.pin = GPIO_NUM_5;
//    displayConfig.Spi.backLight.type.activeLow = true;
//    g_DisplayInterface.Initialize(displayConfig);
//    g_DisplayDriver.Initialize();

//    // Touch
//    CLR_UINT8 TouchI2cAddress = 0x38;
//    GPIO_PIN TouchInterruptPin = GPIO_NUM_34;
//    i2c_port_t TouchI2cBus = I2C_NUM_0;
//    int busSpeed = 0; // 10,000Khz
//    nanoI2C_Init(TouchI2cBus, busSpeed);
//    g_TouchInterface.Initialize(TouchI2cBus, TouchI2cAddress);
//    g_TouchDevice.Initialize(TouchInterruptPin);
//    g_GestureDriver.Initialize();
//    g_InkDriver.Initialize();
//    g_TouchPanelDriver.Initialize();

//#elif defined(MAKERFAB_GRAPHICS_35)
//    DisplayInterfaceConfig displayConfig;
//    displayConfig.Spi.spiBus = 2; // Index into array of pin values ( spiBus - 1) == 1
//    displayConfig.Spi.chipSelect.pin = GPIO_NUM_15;
//    displayConfig.Spi.chipSelect.type.activeLow = true;
//    displayConfig.Spi.dataCommand.pin = GPIO_NUM_33;
//    displayConfig.Spi.dataCommand.type.commandLow = true;
//    displayConfig.Spi.reset.pin = IMPLEMENTED_IN_HARDWARE;
//    displayConfig.Spi.reset.type.activeLow = true;
//    displayConfig.Spi.backLight.pin = IMPLEMENTED_IN_HARDWARE;
//    displayConfig.Spi.backLight.type.activeLow = true;
//    g_DisplayInterface.Initialize(displayConfig);
//    g_DisplayDriver.Initialize();

//    //Touch 
//    CLR_UINT8 TouchI2cAddress = 0x38;
//    GPIO_PIN TouchInterruptPin = GPIO_NUM_34;
//    i2c_port_t TouchI2cBus = I2C_NUM_0;
//    int busSpeed = 0; // 10,000Khz
//    nanoI2C_Init(TouchI2cBus, busSpeed);
//    g_TouchInterface.Initialize(TouchI2cBus, TouchI2cAddress);
//    g_TouchDevice.Initialize(TouchInterruptPin);
//    g_GestureDriver.Initialize();
//    g_InkDriver.Initialize();
//    g_TouchPanelDriver.Initialize();

//#elif defined(MAKERFAB_MAKEPYTHON)
