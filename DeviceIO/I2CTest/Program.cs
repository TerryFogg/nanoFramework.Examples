//#define SCANNER_TEST 
//#define BME280_TEST 
//#define QMC6310_TEST 
#define BUZZERP18_TEST 
//#define CAP1203_TEST 
//#define SLIDE_POTENTIOMETER_P22_TEST
//#define SSD1306P14
//#define VL53L1X
//#define MS5637
//#define UltrasonicRangeFinderP30

using DeviceBME280;
using DeviceBuzzerP18;
using DeviceQMC6310;
using DeviceSlidePotentiometer;
using System;
using System.Diagnostics;
using System.Threading;

namespace I2CTest
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Testing I2C");
            I2CTest();
        }
        static void I2CTest()
        {
            // Change here, when connecting to different devices. 
            SelectedDevice selectedDevice = new(DeviceType.RP2350);

#if SCANNER_TEST
            int lastAddressToScan = 127;
            I2cScannerTest(selectedDevice, lastAddressToScan);
#endif
#if BME280_TEST
            // Connecting pin SDO to GND gives 0x76, connecting SDO to VDD gives 0x77
            const int BME280I2cAddress = 0x77;
            TestBME280(selectedDevice, BME280I2cAddress);
#endif
#if QMC6310_TEST
            // The value is 0x1C for QMC6310U and 0x3C for the QMC6310N.
            const int QMC6310I2cAddress = 0x1C;
            TestQMC6310(selectedDevice, QMC6310I2cAddress);
#endif
#if BUZZERP18_TEST
            // Switch 1 = OFF:2 = OFF - Address 0x5C
            // Switch 1 = ON :2 = OFF - Address 0x09
            // Switch 1 = ON :2 = ON  - Address 0x0B
            const int BuzzerI2cAddress = 0x5C;
            TestBuzzerP18(selectedDevice, BuzzerI2cAddress);
#endif
#if CAP1203_TEST
            // piicoDev capacitive touch module
            const int Cap1203I2cAddress = 0x28;
            TestCap1203Touch(selectedDevice, Cap1203I2cAddress);
#endif
#if SLIDE_POTENTIOMETER_P22_TEST
            // piicoDev capacitive touch module
            // Switch 1 = OFF:2 = OFF:3 = OFF:4 = OFF - Address 0x35
            // Switch 1 = ON :2 = OFF:3 = OFF:4 = OFF - Address 0x09
            // Switch 1 = OFF:2 = ON :3 = OFF:4 = OFF - Address 0x0A
            // Switch 1 = OFF:2 = OFF:3 = ON :4 = OFF - Address 0x0C
            // ../
            // Switch 1 = OFF:2 = OFF:3 = ON :4 = OFF - Address 0x0D
            // ...
            // Switch 1 = OFF:2 = OFF:3 = ON :4 = ON  - Address 0x14
            // ../
            // Switch 1 = ON :2 = ON :3 = ON :4 = ON  - Address 0x17
            const int SlidePotentiometerP22I2cAddress = 0x35;
            TestSlidePotentiometerP22(selectedDevice, SlidePotentiometerP22I2cAddress);
#endif
#if SSD1306P14
            // OLED Display  128x64
            // Switch 1 = OFF - Address 0x3C
            // Switch 1 = ON  - Address 0x3D
            const int SSD1306P14I2cAddress = 0x3C;
            TestSSD1306P14(selectedDevice, SSD1306P14I2cAddress);
#endif
#if VL53L1X
            // OLED Display  128x64
            const int VL531XP7I2cAddress = 0x29;
            TestVL531XP7(selectedDevice, VL531XP7I2cAddress);
#endif
#if MS5637
            // OLED Display  128x64
            const int MS5637P11I2cAddress = 0x76;
            TestMS5637(selectedDevice, MS5637P11I2cAddress);
#endif
#if UltrasonicRangeFinderP30
            // OLED Display  128x64
            const int UltrasonicRangeFinderP30I2cAddress = 0x35;
            TestUltrasonicRangeFinderP30(selectedDevice, UltrasonicRangeFinderP30I2cAddress);
#endif
        }
        private static void I2cScannerTest(SelectedDevice selectedDevice, int lastAddressToScan)
        {
            I2CScanner cScanner = new(selectedDevice.GetI2cBusId());
            cScanner.Scan(lastAddressToScan);
            do
            {
                for (int i = 1; i < lastAddressToScan; i++)
                {
                    if (cScanner.ScanResult[i].Success)
                    {
                        Debug.WriteLine($"Address {i}/{i.ToString("X")} : Response received, bytes Transferred:{cScanner.ScanResult[i].bytesTransferred}");
                    }
                }
                cScanner.Finish();
                Thread.Sleep(1000);
            } while (true);
        }
        private static void TestUltrasonicRangeFinderP30(SelectedDevice selectedDevice, int ultrasonicRangeFinderP30I2cAddress)
        {
            throw new NotImplementedException();
        }
        private static void TestMS5637(SelectedDevice selectedDevice, int mS5637P11I2cAddress)
        {
            throw new NotImplementedException();
        }
        private static void TestVL531XP7(SelectedDevice selectedDevice, int vL531XP7I2cAddress)
        {
            throw new NotImplementedException();
        }
        private static void TestSSD1306P14(SelectedDevice selectedDevice, int sSD1306P14I2cAddress)
        {
            throw new NotImplementedException();
        }
        private static void TestCap1203Touch(SelectedDevice selectedDevice, int Cap1203I2cAddress)
        {
            Cap1203 cap1203 = new(selectedDevice.GetI2cBusId(), Cap1203I2cAddress);
            // Run test for 20 seconds
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            do
            {
                Debug.WriteLine($"Capacitive button 1 {cap1203.TouchValues.Cap1ButtonTouched}    , Capacitive button 2 {cap1203.TouchValues.Cap2ButtonTouched}         , Capacitive button 3 {cap1203.TouchValues.Cap3ButtonTouched}");
            } while ((stopWatch.Elapsed.TotalSeconds < 20));
            cap1203.Finish();
        }
        private static void TestBuzzerP18(SelectedDevice selectedDevice, int BuzzerI2cAddress)
        {
            BuzzerP18 buzP18 = new(selectedDevice.GetI2cBusId(), BuzzerI2cAddress);
            short duration = 0; // infinite

            buzP18.SetPowerOnLed(false);
            buzP18.SetPowerOnLed(true);

            buzP18.SetTone(262, duration);
            buzP18.Finish();
        }
        private static void TestBME280(SelectedDevice selectedDevice, int BME280I2cAddress)
        {
            BME280 bme280 = new(selectedDevice.GetI2cBusId(), BME280I2cAddress);
            bme280.SetFeatureMode(BME280.FeatureModes.WeatherMonitoring);
            for (int i = 0; i< 100; i++)
            {
                bme280.ReadSensorsForced();
                //Temperature: The temperature readings range from -40°C to 85°C.
                double temperature = bme280.Temperature();
                // Pressure: The pressure data ranges from 300 hPa to 1100 hPa, with a temperature coefficient offset (TCO) of ±1.5 Pa/K. 
                double pressure = bme280.Pressure();
                // Humidity: The sensor provides relative humidity data ranging from 10% to 90% within a temperature range of 0°C to 65°C.
                double humidity = bme280.Humidity();

                Debug.WriteLine($"Temp {temperature}    , Pressure {pressure}         , Humidity {humidity}");
                Thread.Sleep(1000);
            }
        }
        private static void TestQMC6310(SelectedDevice selectedDevice, int QMC6310I2cAddress)
        {
            QMC6310 qmc6310 = new(selectedDevice.GetI2cBusId(), QMC6310I2cAddress);
            for (int i = 0; i< 100; i++)
            {
                qmc6310.ReadSensors();
                MagneticDirections dir = qmc6310.Directions;
                Debug.WriteLine($"X {dir.X}    , Y {dir.Y}         , Z {dir.Z}");
                Thread.Sleep(1000);
            }
            qmc6310.Finish();
        }
        private static void TestSlidePotentiometerP22(SelectedDevice selectedDevice, int SlidePotentiometerP22I2cAddress)
        {
            SlidePotentiometer slidePotentiometer = new(selectedDevice.GetI2cBusId(), SlidePotentiometerP22I2cAddress);
            for (int i = 0; i< 100; i++)
            {
                short value= slidePotentiometer.ReadSlideValue();
                Debug.WriteLine($"Pot Value {value}");
                Thread.Sleep(200);
            }
            slidePotentiometer.Finish();
        }
    }
}