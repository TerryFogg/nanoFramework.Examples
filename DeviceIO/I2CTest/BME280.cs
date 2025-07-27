using System;
using System.Device.I2c;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime;
using I2CTest;
using System.Diagnostics;
using System.Threading;

namespace DeviceBME280
{
    #region definitions

    #region CTRL_MEAS
    // Operating mode set by the lower 2 bits of ctrl_meas
    public class OperatingMode
    {
        // SetOperatingMode mode: no operation, all registers accessible, lowest power, selected after startup.
        public const byte Sleep = 0b00;
        // Forced mode: perform one measurement, store results and return to sleep mode.
        public const byte Forced = 0b01;
        // Normal mode: perpetual cycling of measurements and inactive periods.
        public const byte Normal = 0b11;
    }
    // Pressure oversampling set by the bits 2,3 and 4 of ctrl_meas
    public class PressureOversampling
    {
        public const byte X0 = 0b000;
        public const byte X1 = 0b001;
        public const byte X2 = 0b010;
        public const byte X4 = 0b011;
        public const byte X8 = 0b100;
        public const byte X16 = 0b101;
    }
    // Pressure oversampling set by the bits 5,6 and 7 of ctrl_meas
    // Setup the values for an "&" operation to set bits
    public class TemperatureOversampling
    {
        public const byte X0 = 0b000;
        public const byte X1 = 0b001;
        public const byte X2 = 0b010;
        public const byte X4 = 0b011;
        public const byte X8 = 0b100;
        public const byte X16 = 0b101;
    }
    #endregion

    #region CTRL_HUM
    // Humidity oversampling set by the lower 3 bits of ctrl_hum 
    public class HumidityOversampling
    {
        public const byte X0 = 0b000;
        public const byte X1 = 0b001;
        public const byte X2 = 0b010;
        public const byte X4 = 0b011;
        public const byte X8 = 0b100;
        public const byte X16 = 0b101;
    }
    #endregion
    // Values set for an "&" operation to set the bits
    #region CONFIG
    public class Filter
    {
        public const byte Off = 0b00000000;
        public const byte coeff2 = 0b00000100;
        public const byte coeff4 = 0b00001000;
        public const byte coeff8 = 0b00001100;
        public const byte coeff16 = 0b00010000;
    }
    public class Standby
    {
        public const byte t_0_5 = 0b00000000;
        public const byte t_62_5 = 0b00100000;
        public const byte t_125 = 0b01000000;
        public const byte t_250 = 0b01100000;
        public const byte t_500 = 0b10000000;
        public const byte t_1000 = 0b10100000;
        public const byte t_10 = 0b11000000;
        public const byte t_20 = 0b11100000;
    }
    #endregion
    public class Register
    {
        public const byte ChipIdRegister = 0xD0;
        public const byte CTRL_HUM = 0xF2;
        public const byte Status = 0xF3;
        public const byte CTRL_MEAS_ADDR = 0xF4;
        public const byte Config = 0xF5;
        public const byte Reset = 0xE0;

        public const byte RESET_VALUE = 0xB6;
        public const byte ChipInternalIdentifier = 0x60;
    }
    public class StandbyMode
    {
        public const byte Standby_0_5MS = 0x00;
        public const byte Standby_62_5MS = 0x01;
        public const byte Standby_125MS = 0x02;
        public const byte Standby_250MS = 0x03;
        public const byte Standby_500MS = 0x04;
        public const byte Standby_1000MS = 0x05;
        public const byte Standby_10MS = 0x06;
        public const byte Standby_20MS = 0x07;
    }
    public class IIRFilter
    {
        public const byte FilterOff = 0x00;
        public const byte Filter2 = 0x01;
        public const byte Filter4 = 0x02;
        public const byte Filter8 = 0x03;
        public const byte Filter16 = 0x04;
    }
    #endregion
    public class BME280
    {
        double TemperatureFineResolution = 0;

        // 0x88 ==> 0x9F,xx,0xA1, ... 0xA0 bypassed , 0xA1
        byte[] calibration1 = new byte[26];

        // 0xE1 ==> 0xE7
        byte[] calibration2 = new byte[6];

        // One byte for an 8 bit register and one byte for an 8 bit value
        byte[] RegisterCommand = new byte[2];

        // Calibration constants
        UInt16 dig_T1;
        Int16 dig_T2, dig_T3;
        UInt16 dig_P1;
        Int16 dig_P2, dig_P3, dig_P4, dig_P5, dig_P6, dig_P7, dig_P8, dig_P9;

        byte dig_H1;
        Int16 dig_H2;
        byte dig_H3;
        Int16 dig_H4, dig_H5;
        sbyte dig_H6;

        public enum FeatureModes
        {
            WeatherMonitoring,
            HumiditySensing,
            IndoorNavigation,
            Gaming
        }
        I2cConnectionSettings i2cSettings { get; set; }
        I2cDevice i2cDevice { get; set; }

        public BME280(int busId, int I2cAddress)
        {
            I2cTransferResult result;

            i2cSettings = new I2cConnectionSettings(busId, I2cAddress);
            i2cDevice = I2cDevice.Create(i2cSettings);

            // Check the chip is correct
            {
                SpanByte writeSpanByteInternalIdentifier = new byte[1] { Register.ChipIdRegister };
                SpanByte readSpanByteResult = new byte[1];

                result = i2cDevice.WriteRead(writeSpanByteInternalIdentifier, readSpanByteResult);
                byte chipIdentfierRead = readSpanByteResult[0];

                if (chipIdentfierRead !=  Register.ChipInternalIdentifier)
                {
                    throw new Exception($"Chip identifier mismatch, return value is {chipIdentfierRead}");
                }
            }

            // Read first contiguous block of factory trimmed calibration values
            {
                SpanByte writeSpanByteCalibration1 = new byte[1] { 0x88 };
                result = i2cDevice.WriteRead(writeSpanByteCalibration1, calibration1);
            }
            // Read second contiguous block of factory trimmed calibration values
            {
                SpanByte writeSpanByteCalibration2 = new byte[1] { 0xE1 };
                result = i2cDevice.WriteRead(writeSpanByteCalibration2, calibration2);
            }

            // Move the factory trimmed calibration data into variables 
            #region Factory trimmed values
            dig_T1 = (UInt16)(calibration1[1] << 8 | calibration1[0]);                // 0x88/0x89   [7:0]/[15:8]
            dig_T2 = (Int16)(calibration1[3] << 8 | calibration1[2]);                 // 0x8A/0x8B   [7:0]/[15:8]
            dig_T3 = (Int16)(calibration1[5] << 8 | calibration1[4]);                 // 0x8C/0x8D   [7:0]/[15:8]
            dig_P1 = (UInt16)(calibration1[7] << 8 | calibration1[6]);                // 0x8E/0x8F   [7:0]/[15:8]
            dig_P2 = (Int16)(calibration1[9] << 8 | calibration1[8]);                 // 0x90/0x01   [7:0]/[15:8]
            dig_P3 = (Int16)(calibration1[11] << 8 | calibration1[10]);               // 0x92/0x93   [7:0]/[15:8]
            dig_P4 = (Int16)(calibration1[13] << 8 | calibration1[12]);               // 0x94/0x95   [7:0]/[15:8]
            dig_P5 = (Int16)(calibration1[15] << 8 | calibration1[14]);               // 0x96/0x97   [7:0]/[15:8]
            dig_P6=  (Int16)(calibration1[17] << 8 | calibration1[16]);               // 0x98/0x99   [7:0]/[15:8]
            dig_P7 = (Int16)(calibration1[19] << 8 | calibration1[18]);               // 0x9A/0x9B   [7:0]/[15:8]
            dig_P8 = (Int16)(calibration1[21] << 8 | calibration1[20]);               // 0x9C/0x9D   [7:0]/[15:8]
            dig_P9 = (Int16)(calibration1[23] << 8 | calibration1[22]);               // 0x9E/0x9F   [7:0]/[15:8]
                           //calibration1[24] - 0xA0 not used                         
            dig_H1 = calibration1[25];                                                // 0xA1        [7:0]
            dig_H2 = (Int16)(calibration2[1] << 8 | calibration2[0]);                 // 0xE1/0xE2   [7:0]/[15:8]
            dig_H3 = calibration2[2];                                                 // 0xE3        [7:0]

            dig_H4 = (Int16)(calibration2[3] << 4 | (calibration2[4] & 0b00001111) ); // 0xE4/0xE5   [11:4]/[3:0]
            dig_H5 = (Int16)(calibration2[5] << 4 | (calibration2[4]) >> 4);           // 0xE5/0xE6   [3:0]/[11:4]
            dig_H6 = (sbyte)calibration1[6];                            // 0xE7

            #endregion
            Reset();
            Thread.Sleep(10);
            WaitForCalibrationDataCopy();

            return;
        }
        internal void Finish()
        {
            i2cDevice.Dispose();
        }
        I2cTransferResult Reset()
        {
            return SetBME280Register(Register.Reset, Register.RESET_VALUE);
        }
        void WaitForCalibrationDataCopy()
        {
            byte registerValue;
            do
            {
                // Read the current Ctrl_Meas register and set the appropriate bits to sleep device without making other changes
                i2cDevice.Write(new byte[] { Register.Status });
                registerValue = i2cDevice.ReadByte();

            } while ((registerValue & 0b00000001) == 1);
        }
        public I2cTransferResult ChangeOperatingMode(byte mode)
        {
            // Read the current Ctrl_Meas register and set the appropriate bits to sleep device without making other changes
            i2cDevice.Write(new byte[] { Register.CTRL_MEAS_ADDR });
            byte newRegisterValue = i2cDevice.ReadByte();
            // Set the new mode
            newRegisterValue &= 0b00000011;
            newRegisterValue |= mode;
            I2cTransferResult result = SetBME280Register(Register.CTRL_MEAS_ADDR, newRegisterValue);
            return result;
        }
        public I2cTransferResult ReadSensorsForced()
        {
            // Read the current Ctrl_Meas register and set the appropriate bits to sleep device without making other changes
            i2cDevice.Write(new byte[] { Register.CTRL_MEAS_ADDR });
            byte currentRegisterValue = i2cDevice.ReadByte();
            byte newRegisterValue = (byte)(currentRegisterValue | OperatingMode.Forced);
            I2cTransferResult result = SetBME280Register(Register.CTRL_MEAS_ADDR, newRegisterValue);
            while (IsMeasuring()) ;
            ReadSensors();
            return result;
        }
        byte ReadBME280Register(byte Register)
        {
            i2cDevice.Write(new byte[] { Register });
            return i2cDevice.ReadByte();
        }
        bool IsMeasuring()
        {
            // Read the current Status register and check if a measurement is in progress
            i2cDevice.Write(new byte[] { Register.Status });
            byte statusIMValue = (byte)( i2cDevice.ReadByte() & 0b0000001);
            return !(statusIMValue == 0);
        }
        I2cTransferResult SetBME280Register(byte register, byte value)
        {
            RegisterCommand[0] = register;
            RegisterCommand[1] = value;
            I2cTransferResult result = i2cDevice.Write(RegisterCommand);
            return result;
        }
        /// <summary>
        /// Sets characteristics for reading the sensors. 
        /// The BME280 is in sleep mode after the change and operating mode must be changed to read
        /// </summary>
        /// <param name="FeatureMode"></param>
        public void SetFeatureMode(FeatureModes FeatureMode)
        {
            byte newCtrlMeasValue = 0;
            byte newCtrlHumValue = 0;
            byte newCtrlConfig = 0;
            // Sensor must be in SLEEPMODE to set control parameters
            ChangeOperatingMode(OperatingMode.Sleep);
            switch (FeatureMode)
            {
                // Low data rate, noise from pressure is of no concern
                // Sensor Mode         : Forced Mode
                // Oversample settings : pressure * 1, temperature * 1, humidity * 1
                // IIRFilter settings  : Off
                case FeatureModes.WeatherMonitoring:
                    newCtrlMeasValue = OperatingMode.Forced | (PressureOversampling.X1 << 2) | (TemperatureOversampling.X1 << 5);
                    newCtrlHumValue = HumidityOversampling.X1;
                    newCtrlConfig = Filter.Off;
                    newCtrlConfig = Filter.Off <<2 |  StandbyMode.Standby_500MS << 5;
                    break;

                // Low data rate
                // Sensor Mode         : Forced Mode,
                // Oversample settings : Oversample pressure = 0, temperature = 1, humidity = 1,
                // IIRFilter settings  : IIRFilter = Off
                case FeatureModes.HumiditySensing:
                    newCtrlMeasValue = OperatingMode.Forced | (PressureOversampling.X0 << 2) | (TemperatureOversampling.X1 << 5);
                    newCtrlHumValue = HumidityOversampling.X1;
                    newCtrlConfig = Filter.Off <<2 |  StandbyMode.Standby_500MS << 5;
                    break;

                // Lowest possible altitude noise is needed. A very low bandwidth is preferred. Humidity is measured to help detect room changes.
                // Sensor Mode         : Normal Mode
                // Oversample settings : pressure * 16, temperature * 2, humidity * 1
                // IIRFilter settings  : filter coefficient 16
                case FeatureModes.IndoorNavigation:
                    newCtrlMeasValue = OperatingMode.Forced | (PressureOversampling.X16 << 2) | (TemperatureOversampling.X2 << 5);
                    newCtrlHumValue = HumidityOversampling.X1;
                    newCtrlConfig = Filter.coeff16 <<2 |  StandbyMode.Standby_0_5MS << 5;
                    break;

                // Low altitude noise is needed. A bandwidth of `2Hx in order to respond quickly to altitude changes.
                // Sensor Mode         : Normal Mode, t_Standby = 0.5ms
                // Oversample settings : pressure * 4, temperature * 1, humidity * 0
                // IIRFilter settings  : filter coefficient 16
                case FeatureModes.Gaming:
                    newCtrlMeasValue = OperatingMode.Forced | (PressureOversampling.X4 << 2) | (TemperatureOversampling.X1 << 5);
                    newCtrlHumValue = HumidityOversampling.X0;
                    newCtrlConfig = Filter.coeff16 <<2 |  StandbyMode.Standby_0_5MS << 5;
                    break;
            }
            SetBME280Register(Register.Status, newCtrlConfig);
            SetBME280Register(Register.CTRL_HUM, newCtrlHumValue);
            SetBME280Register(Register.CTRL_MEAS_ADDR, newCtrlMeasValue);

            return;
        }
        public double Temperature()
        {
            // Returns temperature in DegC, double precision. (for example, 51.23 == 51.23 Degrees Celcius)
            // TemperatureFineResolution carries fine temperature as a global value
            TemperatureFineResolution = (RawTemperature/16384.0 - dig_T1/1024.0)*dig_T2 + ((RawTemperature/131072.0 - dig_T1/8192.0) *(RawTemperature/131072.0 - dig_T1/8192.0))*dig_T3;
            double Temperature = TemperatureFineResolution / 5120.0;
            return Temperature;
        }
        public double Pressure()
        {
            // Returns pressure in Pa as double. Output value of "96386.2" equals 96386.2 Pa = 963.862 hPa
            double var1;
            double var2;
            double p;
            var1 = TemperatureFineResolution/2.0 - 64000.0;
            var2 = var1 * (var1 * dig_P6) / 32768.0;
            var2 = var2 + var1 * dig_P5 * 2.0;
            var2 = var2/4.0 + dig_P4 *65536.0;

            var1 = ((dig_P3 *var1 * var1) / 524288.0 + dig_P2 * var1) / 524288.0;
            var1 = (1.0 + (var1 / 32768.0)) * dig_P1;

            if (var1 != 0.0)
            {
                p = 1048576.0 - RawPressure;
                p = (p - (var2 / 4096.0)) * 6250.0 / var1;
                var1 = dig_P9 * p * p / 2147483648.0;
                var2 = p * dig_P8 / 32768.0;
                p = p + (var1 + var2 + dig_P7) / 16.0;
            }
            else
            {
                throw new Exception($"Pressure calculation results in a device by zero error");
            }

            return p;
        }
        public double Humidity()
        {
            // Returns humidity in %rH as as double. Output value of "46.332" represents 46.332 %rH
            double var_H;
            var_H = TemperatureFineResolution - 76800.0;
            var_H = (RawHumidity - (dig_H4 * 64.0 + dig_H5 / 16384.0 * var_H)) * (dig_H2 / 65536.0 * (1.0 + dig_H6 / 67108864.8 * var_H * (1.0 + dig_H3 / 67108864.0 * var_H)));
            var_H = var_H * (1.0 - dig_H1 * var_H / 524288.0);

            if (var_H > 100.0)
            {
                var_H = 100.0;
            }
            else if (var_H < 0.0)
            {
                var_H = 0.0;
            }
            return var_H;
        }
        internal void ReadSensors()
        {
            SpanByte writeSpanByte = new byte[1] { 0xF7 };
            I2cTransferResult result = i2cDevice.WriteRead(writeSpanByte, SensorData);
        }

        #region Sensor Data
        byte[] SensorData = new byte[8]; //0xF7 ==> 0xFE
        private Double RawPressure
        {
            // 0xF7 <19:12> / 0xF8 <11:4>   /0XF9 <3:0>
            get => (Double)(SensorData[0] << 12  | SensorData[1] << 4 | (SensorData[2]>> 4));
        }
        private Double RawTemperature
        {
            // 0xFA <19:12> / 0xFB <11:4>   /0XFC <3:0>
            get => (Double)(SensorData[3] << 12  | SensorData[4] << 4 | (SensorData[5] >> 4));
        }
        private Double RawHumidity
        {
            // 0xFD <15:8> /0xFE <7:0>
            get => (Double)(SensorData[6] << 8 | SensorData[7]);
        }
        #endregion
    }
}