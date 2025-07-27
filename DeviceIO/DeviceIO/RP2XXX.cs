using System;

namespace nanoFramework.Device
{
    public class RP2XXX
    {
        public class GPIO
        {
            public const int Gpio0 = 0;
            public const int Gpio1 = 1;
            public const int Gpio2 = 2;
            public const int Gpio3 = 3;
            public const int Gpio4 = 4;
            public const int Gpio5 = 5;
            public const int Gpio6 = 6;
            public const int Gpio7 = 7;
            public const int Gpio8 = 8;
            public const int Gpio9 = 9;
            public const int Gpio10 = 10;
            public const int Gpio11 = 11;
            public const int Gpio12 = 12;
            public const int Gpio13 = 13;
            public const int Gpio14 = 14;
            public const int Gpio15 = 15;
            public const int Gpio16 = 16;
            public const int Gpio17 = 17;
            public const int Gpio18 = 18;
            public const int Gpio19 = 19;
            public const int Gpio20 = 20;
            public const int Gpio21 = 21;
            public const int Gpio22 = 22;
            public const int Gpio23 = 23;
            public const int Gpio24 = 24;
            public const int Gpio25 = 25;
            public const int Gpio26 = 26;
            public const int Gpio27 = 27;
            public const int Gpio28 = 28;
            public const int Gpio29 = 29;

        }
        public class Adc
        {
            public const int ADC0 = 0;
            public const int ADC1 = 1;
            public const int ADC2 = 2;
        }
        public class I2c
        {
            public const int I2C0 = 0;
            public const int I2C1 = 1;
        }
        public class Pwm
        {
            public const int PWM0 = 0;
            public const int PWM1 = 1;
            public const int PWM2 = 2;
            public const int PWM3 = 3;
            public const int PWM4 = 4;
            public const int PWM5 = 5;
            public const int PWM6 = 6;
            public const int PWM7 = 7;
        }
        public class SPI
        {
            public const int SPI0 = 0;
            public const int SPI1 = 1;
        }
        public class Usart
        {
            public const int USART0 = 0;
            public const int USART1 = 1;
        }
        public class NominalDriveStrength
        {
            public const int Strength2ma = 0;
            public const int Strength4ma = 1;
            public const int Strength8ma = 2;
            public const int Strength12ma = 3;
            public const int StrengthDefault = Strength4ma;
        }
        public class SchmittTrigger
        {
            public const int SchmittEnable = 1;
            public const int SchmittDisable = 2;
            public const int ScmittDefault = SchmittEnable;
        }
        public class SlewRateLimiting
        {
            public const int SlewSlow = 0;
            public const int SlewFast = 1;
            public const int SlewDefault = SlewSlow;
        }
        public class PowerSaveFeatures
        {
            /// <summary>
            ///  Disable the driver. ??? Has priority over output enable from
            /// </summary>
            public const int OutputDriverDisabled = 0;
            /// <summary>
            /// Enable the output driver disabled at MCU boot/reset
            /// </summary>
            public const int OutputDriverEnabled = 1;
            /// <summary>
            /// Default is output driver disabled at MCU boot/reset
            /// </summary>
            public const int OutputDriverDefault = OutputDriverDisabled;
            /// <summary>
            /// Disable the input buffer to conserve power
            /// </summary>
            public const int InputBufferDisabled = 0;
            /// <summary>
            /// Enable the input buffer
            /// </summary>
            public const int InputBufferEnabled = 1;
            /// <summary>
            /// Default is input buffer disabled at MCU boot/reset
            /// </summary>
            public const int InputBufferDefault = InputBufferDisabled;
        }
        public class VoltageSelect
        {
            public const int Default = Voltage3_3V;
            public const int Voltage3_3V = 0;
            public const int Voltage1_8V = 1;
        }
    }
}
