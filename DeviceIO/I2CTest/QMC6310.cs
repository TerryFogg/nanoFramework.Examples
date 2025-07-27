using System;
using System.Device.I2c;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime;
using I2CTest;
using System.Diagnostics;
using System.Threading;

namespace DeviceQMC6310
{
    public class Register
    {
        public const byte Status = 0x09;
        public const byte Ctrl1 = 0x0A;
        public const byte Ctrl2 = 0x0B;
        public const byte Sign = 0x29;
    }
    public class Mode
    {
        public const byte Suspend = 0x00;
        public const byte Normal = 0x01;
        public const byte Single = 0x10;
        public const byte Continuous = 0x11;
    }
    public class OutputDataRate
    {
        public const byte Hz10 = 0x00;
        public const byte Hz50 = 0x01;
        public const byte Hz100 = 0x10;
        public const byte Hz200 = 0x11;
    }
    public class OverSampling
    {
        public const byte By8 = 0x00;
        public const byte By4 = 0x01;
        public const byte By2 = 0x10;
        public const byte By1 = 0x11;
    }
    public class DownSampling
    {
        public const byte By1 = 0x00;
        public const byte By2 = 0x01;
        public const byte By4 = 0x10;
        public const byte By5 = 0x11;
    }
    public class FieldRange
    {
        public const byte Gauss30 = 0x00;
        public const byte Gauss12 = 0x01;
        public const byte Gauss8 = 0x10;
        public const byte Gauss2 = 0x11;
    }
    public struct MagneticDirections
    {
        public Int16 X;
        public Int16 Y;
        public Int16 Z;
    }
    public class QMC6310
    {
        I2cConnectionSettings i2cSettings { get; set; }
        I2cDevice i2cDevice { get; set; }
        // One byte for an 8 bit register and one byte for an 8 bit value
        byte[] RegisterCommand = new byte[2];
        public MagneticDirections Directions
        {
            get
            {
                return new MagneticDirections { X = X_Direction, Y=Y_Direction, Z=Z_Direction };
            }
        }
        public QMC6310(int busId, int I2cAddress)
        {
            i2cSettings = new I2cConnectionSettings(busId, I2cAddress);
            i2cDevice = I2cDevice.Create(i2cSettings);

            // Setup some defaults
            // Write Register 0BH by 0x08(Define Set/Reset mode, with Set/Reset On, Field Range 8Guass)
            // Write Register 0AH by 0xCD(set normal mode, set ODR=200Hz)

            // Setup sign for x,y and z axis
            SetQMC6310Register(Register.Sign, 0x06);

            // Set/Reset On, Field Range 8 Gauss
            SetQMC6310Register(Register.Ctrl2, 0x08);

            // Normal mode, Output Data Rate = 200Hz
            SetQMC6310Register(Register.Ctrl1, 0xCD);

            return;
        }
        internal void Finish()
        {
            i2cDevice.Dispose();
        }
        I2cTransferResult Reset()
        {
            return SetQMC6310Register(Register.Ctrl2, 0b00000001);
        }
        byte ReadQMC6310Register(byte Register)
        {
            i2cDevice.Write(new byte[] { Register });
            return i2cDevice.ReadByte();
        }
        I2cTransferResult SetOutputDataRate(byte odr)
        {
            // Read the current Ctrl1 register and update
            i2cDevice.Write(new byte[] { Register.Ctrl1 });
            byte newRegisterValue = i2cDevice.ReadByte();
            // Set the new output data rate
            newRegisterValue &= 0b00001100;
            newRegisterValue |= (byte)(odr << 2);
            return SetQMC6310Register(Register.Ctrl1, newRegisterValue);
        }
        I2cTransferResult SetOversampleRate(byte overSampleRate)
        {
            // Read the current Ctrl1 register and update
            i2cDevice.Write(new byte[] { Register.Ctrl1 });
            byte newRegisterValue = i2cDevice.ReadByte();
            // Set the new output data rate
            newRegisterValue &= 0b00110000;
            newRegisterValue |= (byte)(overSampleRate << 4);
            return SetQMC6310Register(Register.Ctrl1, newRegisterValue);
        }
        I2cTransferResult DownSamplingRate(byte downSamplingRate)
        {
            // Read the current Ctrl1 register and update
            i2cDevice.Write(new byte[] { Register.Ctrl1 });
            byte newRegisterValue = i2cDevice.ReadByte();
            // Set the new down sampling rate
            newRegisterValue &= 0b11100000;
            newRegisterValue |= (byte)(downSamplingRate << 6);
            return SetQMC6310Register(Register.Ctrl1, newRegisterValue);
        }
        I2cTransferResult SetFieldRange(byte fieldRange)
        {
            // Read the current Ctrl1 register and update
            i2cDevice.Write(new byte[] { Register.Ctrl2 });
            byte newRegisterValue = i2cDevice.ReadByte();
            // Set the new field range
            newRegisterValue &= 0b00001100;
            newRegisterValue |= (byte)(fieldRange << 2);
            return SetQMC6310Register(Register.Ctrl1, newRegisterValue);
        }
        bool DataReady()
        {
            // Read the current Status register and check if a measurement is in progress
            i2cDevice.Write(new byte[] { Register.Status });
            byte statusIMValue = (byte)(i2cDevice.ReadByte() & 0b0000001);
            return (statusIMValue == 1);
        }
        bool Overflow()
        {
            // Read the current Status register and check if an overflow occured
            // when the range exceeds [-30000,30000]
            i2cDevice.Write(new byte[] { Register.Status });
            byte statusIMValue = (byte)(i2cDevice.ReadByte() & 0b0000010);
            return (statusIMValue == 1);
        }
        I2cTransferResult SetQMC6310Register(byte register, byte value)
        {
            RegisterCommand[0] = register;
            RegisterCommand[1] = value;
            I2cTransferResult result = i2cDevice.Write(RegisterCommand);
            return result;
        }
        internal void ReadSensors()
        {
            SpanByte writeSpanByte = new byte[1] { 0x01 };
            I2cTransferResult result = i2cDevice.WriteRead(writeSpanByte, SensorData);
        }

        #region Sensor Data
        byte[] SensorData = new byte[6]; //0x01 ==> 0x06
        private Int16 X_Direction
        {
            // 0x01 <7:0> / 0x02 <15:8>
            get => (Int16)(SensorData[1] << 8  | SensorData[0]);
        }
        private Int16 Y_Direction
        {
            // 0x03 <7:0> / 0x04 <15:8>
            get => (Int16)(SensorData[3] << 8  | SensorData[2]);
        }
        private Int16 Z_Direction
        {
            // 0x05 <7:0> / 0x06 <15:8>
            get => (Int16)(SensorData[5] << 8 | SensorData[4]);
        }
        #endregion
    }
}