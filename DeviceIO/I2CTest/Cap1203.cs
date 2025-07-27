using DeviceQMC6310;
using System;
using System.Device.I2c;

namespace I2CTest
{
    public struct CapacitiveTouchValues
    {
        public bool Cap1ButtonTouched;
        public bool Cap2ButtonTouched;
        public bool Cap3ButtonTouched;
    }
    public class Cap1203
    {
        I2cConnectionSettings i2cSettings { get; set; }
        I2cDevice i2cDevice { get; set; }

        // One byte for an 8 bit register and one byte for an 8 bit value
        byte[] RegisterCommand = new byte[2];
        public class Register
        {
            public const byte MainControl = 0x00;
            public const byte GeneralStatus = 0x02;
            public const byte _SENSOR_INPUT_STATUS = 0x03;
            public const byte _SENSITIVITY_CONTROL = 0x1F;
            public const byte _CONFIG = 0x20;
            public const byte _INTERRUPT_ENABLE = 0x27;
            public const byte _MULTIPLE_TOUCH_CONFIG = 0x2A;
            public const byte _PRODUCT_ID = 0xFD;

            public const byte ChipInternalIdentifier = 0x6D;
        }
        public static class Volume
        {
            public const byte Vol1 = 1;
            public const byte Vol2 = 2;
            public const byte Vol3 = 3;
        }
        public class Sensitivity
        {
            public const byte Multiplier128 = 0;
            public const byte Multiplier64 = 1;
            public const byte Multiplier32 = 2;
            public const byte Multiplier16 = 3;
            public const byte Multiplier8 = 4;
            public const byte Multiplier4 = 5;
            public const byte Multiplier2 = 6;
            public const byte Multiplier1 = 7;
        }
        public CapacitiveTouchValues TouchValues
        {
            get
            {
                return new CapacitiveTouchValues { Cap1ButtonTouched = CapacitiveTouch1, Cap2ButtonTouched=CapacitiveTouch2, Cap3ButtonTouched=CapacitiveTouch3 };
            }
        }
        public Cap1203(int busId, int I2cAddress)
        {
            i2cSettings = new I2cConnectionSettings(busId, I2cAddress);
            i2cDevice = I2cDevice.Create(i2cSettings);

            //// Check the chip is correct
            //byte chipIdentfierRead;
            //if ((chipIdentfierRead= ReadCap1203Register(Register._PRODUCT_ID)) !=  Register.ChipInternalIdentifier)
            //{
            //    throw new Exception($"Chip identifier mismatch, return value is {chipIdentfierRead}");
            //}
            // At startup the cap1203 default is not in standyb
            ReadCap1203Register(Register._PRODUCT_ID);
            I2cTransferResult result = i2cDevice.Write(new byte[] { Register._MULTIPLE_TOUCH_CONFIG, 0x00, 0x80 });
            SetSensitivity(Sensitivity.Multiplier16);
        }
        I2cTransferResult SetSensitivity(byte sensitivity)
        {
            // Read the register and set sensitiy bits <4,5,6>
            i2cDevice.Write(new byte[] { Register._SENSITIVITY_CONTROL });
            byte newRegisterValue = i2cDevice.ReadByte();
            // Set the new sensitivity
            newRegisterValue &= 0b00111000;
            newRegisterValue |= sensitivity;
            I2cTransferResult result = SetCap1203Register(Register._SENSITIVITY_CONTROL, newRegisterValue);
            return result;
        }
        void ReadCap1203Register(byte register)
        {

            register = 0xFE;
            SpanByte writeSpanByteInternalIdentifier = new byte[1] { register };
            SpanByte readSpanByteResult = new byte[1];

            I2cTransferResult result = i2cDevice.WriteRead(writeSpanByteInternalIdentifier, readSpanByteResult);
            byte chipIdentfierRead = readSpanByteResult[0];

            if (chipIdentfierRead !=  Register.ChipInternalIdentifier)
            {
                throw new Exception($"Chip identifier mismatch, return value is {chipIdentfierRead}");
            }
        }
        I2cTransferResult SetCap1203Register(byte register, byte value)
        {
            RegisterCommand[0] = register;
            RegisterCommand[1] = value;
            I2cTransferResult result = i2cDevice.Write(RegisterCommand);
            return result;
        }

        #region Sensor Data
        byte[] SensorData = new byte[1]; //0x03
        internal void ReadSensors()
        {
            i2cDevice.Write(new byte[] { Register._SENSOR_INPUT_STATUS });
            SensorData[0] = (byte)(i2cDevice.ReadByte() & 0b00000111);
        }
        internal void Finish()
        {
            i2cDevice.Dispose();
        }
        private bool CapacitiveTouch1
        {
            // 0x01 <7:0> / 0x02 <15:8>
            get => (SensorData[0] & 0x001) == 1;
        }
        private bool CapacitiveTouch2
        {
            // 0x03 <7:0> / 0x04 <15:8>
            get => (SensorData[0] & 0x010) == 1;
        }
        private bool CapacitiveTouch3
        {
            // 0x05 <7:0> / 0x06 <15:8>
            get => (SensorData[0] & 0x100) == 1;
        }
        #endregion
    }
}
