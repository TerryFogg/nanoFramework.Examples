
using static RasberryPiPico.RasberryPiPico;

namespace RasberryPiPico
{
    public partial class RasberryPiPico
    {
        public class Functions
        {
            public const int GpioFunctionXIP = 0;
            public const int GpioFunctionSPI = 1;
            public const int GpioFunctionUART = 2;
            public const int GpioFunctionI2C = 3;
            public const int GpioFunctionPWM = 4;
            public const int GpioFunctionSIO = 5;
            public const int GpioFunctionPIO0 = 6;
            public const int GpioFunctionPIO1 = 7;
            public const int GpioFunctionGPCK = 8;
            public const int GpioFunctionUSB = 9;
        }
        /// <summary>
        /// Fault Tolerant, Default driver 4ma.
        /// Each individual GPIO pin can be connected to an internal peripheral via the GPIO functions defined below.
        /// Some internal peripheral connections appear in multiple places to allow some system level flexibility.
        /// SIO, PIO0 and PIO1 can connect to all GPIO pins and are controlled by software (or software controlled state machines) 
        /// so can be used to implement many functions.
        /// </summary>
        public class PinDefinitions
        {
            public const int GpioNONE = -1;
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
        public class BaseFunctions
        {

        }

        public partial class AlternateFunction
        {
            public class I2C0
            {
                public class SDA
                {
                    public const int Gpio0 = PinDefinitions.Gpio0;
                    public const int Gpio4 = PinDefinitions.Gpio4;
                    public const int Gpio8 = PinDefinitions.Gpio8;
                    public const int Gpio12 = PinDefinitions.Gpio12;
                    public const int Gpio16 = PinDefinitions.Gpio16;
                    public const int Gpio20 = PinDefinitions.Gpio20;
                    public const int Gpio24 = PinDefinitions.Gpio24;
                    public const int Gpio28 = PinDefinitions.Gpio28;

                }
                public class SCL
                {
                    public const int Gpio1 = PinDefinitions.Gpio1;
                    public const int Gpio5 = PinDefinitions.Gpio5;
                    public const int Gpio9 = PinDefinitions.Gpio9;
                    public const int Gpio13 = PinDefinitions.Gpio13;
                    public const int Gpio17 = PinDefinitions.Gpio17;
                    public const int Gpio21 = PinDefinitions.Gpio21;
                    public const int Gpio25 = PinDefinitions.Gpio25;
                    public const int Gpio29 = PinDefinitions.Gpio29;
                }
            }
            public class I2C1
            {
                public class SDA
                {
                    public const int SDA_2 = PinDefinitions.Gpio2;
                    public const int SDA_6 = PinDefinitions.Gpio6;
                    public const int SDA_10 = PinDefinitions.Gpio10;
                    public const int SDA_14 = PinDefinitions.Gpio14;
                    public const int SDA_18 = PinDefinitions.Gpio18;
                    public const int SDA_22 = PinDefinitions.Gpio22;
                    public const int SDA_26 = PinDefinitions.Gpio26;
                }
                public class SCL
                {
                    public const int SCL_3 = PinDefinitions.Gpio3;
                    public const int SCL_7 = PinDefinitions.Gpio7;
                    public const int SCL_11 = PinDefinitions.Gpio11;
                    public const int SCL_15 = PinDefinitions.Gpio15;
                    public const int SCL_19 = PinDefinitions.Gpio19;
                    public const int SCL_23 = PinDefinitions.Gpio23;
                    public const int SCL_27 = PinDefinitions.Gpio27;
                }
            }
            public class UART0
            {
                public class TX
                {
                    public const int Gpio0 = PinDefinitions.Gpio0;
                    public const int Gpio12 = PinDefinitions.Gpio12;
                    public const int Gpio16 = PinDefinitions.Gpio16;
                    public const int Gpio28 = PinDefinitions.Gpio28;
                }
                public class RX
                {
                    public const int Gpio1 = PinDefinitions.Gpio1;
                    public const int Gpio13 = PinDefinitions.Gpio13;
                    public const int Gpio17 = PinDefinitions.Gpio17;
                    public const int Gpio29 = PinDefinitions.Gpio28;
                }
                public class CTS
                {
                    public const int Gpio3 = PinDefinitions.Gpio3;
                    public const int Gpio14 = PinDefinitions.Gpio14;
                    public const int Gpio18 = PinDefinitions.Gpio18;
                }
                public class RTS
                {
                    public const int Gpio4 = PinDefinitions.Gpio4;
                    public const int Gpio15 = PinDefinitions.Gpio15;
                    public const int Gpio19 = PinDefinitions.Gpio19;
                }
            }
            public class UART1
            {
                public class TX
                {
                    public const int Gpio4 = PinDefinitions.Gpio4;
                    public const int Gpio8 = PinDefinitions.Gpio8;
                    public const int Gpio20 = PinDefinitions.Gpio20;
                    public const int Gpio24 = PinDefinitions.Gpio24;

                }
                public class RX
                {
                    public const int Gpio5 = PinDefinitions.Gpio5;
                    public const int Gpio9 = PinDefinitions.Gpio9;
                    public const int Gpio21 = PinDefinitions.Gpio21;
                    public const int Gpio25 = PinDefinitions.Gpio25;

                }
                public class CTS
                {
                    public const int Gpio6 = PinDefinitions.Gpio6;
                    public const int Gpio10 = PinDefinitions.Gpio10;
                    public const int Gpio22 = PinDefinitions.Gpio22;
                    public const int Gpio26 = PinDefinitions.Gpio26;

                }
                public class RTS
                {
                    public const int Gpio7 = PinDefinitions.Gpio7;
                    public const int Gpio11 = PinDefinitions.Gpio11;
                    public const int Gpio23 = PinDefinitions.Gpio23;
                    public const int Gpio27 = PinDefinitions.Gpio27;
                }
            }
            public class SPI0
            {
                public class RX
                {
                    public const int Gpio0 = PinDefinitions.Gpio0;
                    public const int Gpio4 = PinDefinitions.Gpio4;
                    public const int Gpio16 = PinDefinitions.Gpio16;
                    public const int Gpio20 = PinDefinitions.Gpio20;
                }
                public class TX
                {
                    public const int Gpio3 = PinDefinitions.Gpio3;
                    public const int Gpio7 = PinDefinitions.Gpio7;
                    public const int Gpio19 = PinDefinitions.Gpio19;
                    public const int Gpio23 = PinDefinitions.Gpio23;

                }
                public class SCK
                {
                    public const int Gpio2 = PinDefinitions.Gpio2;
                    public const int Gpio6 = PinDefinitions.Gpio6;
                    public const int Gpio18 = PinDefinitions.Gpio18;
                    public const int Gpio22 = PinDefinitions.Gpio22;

                }
                public class CSn
                {
                    public const int Gpio1 = PinDefinitions.Gpio1;
                    public const int Gpio5 = PinDefinitions.Gpio5;
                    public const int Gpio17 = PinDefinitions.Gpio17;
                    public const int Gpio21 = PinDefinitions.Gpio21;

                }

            }
            public class SPI1
            {
                public class RX
                {
                    public const int RX_8 = PinDefinitions.Gpio8;
                    public const int RX_12 = PinDefinitions.Gpio12;
                    public const int RX_24 = PinDefinitions.Gpio24;
                    public const int RX_28 = PinDefinitions.Gpio28;
                }
                public class TX
                {
                    public const int TX_11 = PinDefinitions.Gpio11;
                    public const int TX_15 = PinDefinitions.Gpio15;
                    public const int TX_27 = PinDefinitions.Gpio27;
                }
                public class SCK
                {
                    public const int SCK_10 = PinDefinitions.Gpio10;
                    public const int SCK_14 = PinDefinitions.Gpio14;
                    public const int SCK_26 = PinDefinitions.Gpio26;
                }
                public class CSn
                {
                    public const int CSn_9 = PinDefinitions.Gpio9;
                    public const int CSn_13 = PinDefinitions.Gpio13;
                    public const int CSn_25 = PinDefinitions.Gpio25;
                    public const int CSn_29 = PinDefinitions.Gpio29;
                }
            }
            public class PMW
            {
                public class PWM0A
                {
                    public const int Gpio0 = PinDefinitions.Gpio0;
                    public const int Gpio16 = PinDefinitions.Gpio16;
                }
                public class PWM1A
                {
                    public const int Gpio2 = PinDefinitions.Gpio2;
                    public const int Gpio18 = PinDefinitions.Gpio18;
                }
                public class PWM2A
                {
                    public const int Gpio4 = PinDefinitions.Gpio4;
                    public const int Gpio20 = PinDefinitions.Gpio20;
                }
                public class PWM3A
                {
                    public const int Gpio6 = PinDefinitions.Gpio6;
                    public const int Gpio22 = PinDefinitions.Gpio22;
                }
                public class PWM4A
                {
                    public const int Gpio8 = PinDefinitions.Gpio8;
                    public const int Gpio24 = PinDefinitions.Gpio24;
                }
                public class PWM5A
                {
                    public const int Gpio10 = PinDefinitions.Gpio10;
                    public const int Gpio26 = PinDefinitions.Gpio26;
                }
                public class PWM6A
                {
                    public const int Gpio12 = PinDefinitions.Gpio12;
                    public const int Gpio28 = PinDefinitions.Gpio28;
                }
                public class PWM7A
                {
                    public const int Gpio14 = PinDefinitions.Gpio14;
                }

                public class PWM0B
                {
                    public const int Gpio1 = PinDefinitions.Gpio1;
                    public const int Gpio17 = PinDefinitions.Gpio17;
                }
                public class PWM1B
                {
                    public const int Gpio3 = PinDefinitions.Gpio3;
                    public const int Gpio19 = PinDefinitions.Gpio19;
                }
                public class PWM2B
                {
                    public const int Gpio5 = PinDefinitions.Gpio5;
                    public const int Gpio21 = PinDefinitions.Gpio21;
                }
                public class PWM3B
                {
                    public const int Gpio7 = PinDefinitions.Gpio7;
                    public const int Gpio23 = PinDefinitions.Gpio23;
                }
                public class PWM4B
                {
                    public const int Gpio9 = PinDefinitions.Gpio9;
                    public const int Gpio25 = PinDefinitions.Gpio25;
                }
                public class PWM5B
                {
                    public const int Gpio11 = PinDefinitions.Gpio11;
                    public const int Gpio27 = PinDefinitions.Gpio27;
                }
                public class PWM6B
                {
                    public const int Gpio13 = PinDefinitions.Gpio13;
                    public const int Gpio29 = PinDefinitions.Gpio29;
                }
                public class PWM7B
                {
                    public const int Gpio15 = PinDefinitions.Gpio15;
                }
            }

            public class ADC
            {
                public const int Adc0 = PinDefinitions.Gpio26;
                public const int Adc1 = PinDefinitions.Gpio27;
                public const int Adc2 = PinDefinitions.Gpio28;
                public const int Adc3 = PinDefinitions.Gpio29;
                public const int AdcInternalTemperature = 0;
            }
            public class CLOCKOUT
            {
                public const int GPOut0 = PinDefinitions.Gpio21;
                public const int GPOut1 = PinDefinitions.Gpio23;
                public const int GPOut2 = PinDefinitions.Gpio24;
                public const int GPOut3 = PinDefinitions.Gpio25;
            }
        }
    }
    /// <summary>
    /// The GPIOs on RP2040/RP2350 have four different output drive strengths,
    /// These are not hard limits, nor do they mean that they will always be sourcing (or sinking)
    /// the selected amount of milliamps. 
    /// NOTE: The amount of current a GPIO sources or sinks is dependant on the load attached to it.
    /// </summary>
    public class NominalDriveStrength : BaseFunctions
    {
        /// <summary>
        /// Limit current to 2 milliamps
        /// </summary>
        public const int Strength2ma = 100;
        /// <summary>
        /// Limit current to 4 milliamps
        /// </summary>
        public const int Strength4ma = 101;
        /// <summary>
        /// Limit current to 8 milliamps
        /// </summary>
        public const int Strength8ma = 102;
        /// <summary>
        /// Limit current to 12 milliamps
        /// </summary>
        public const int Strength12ma = 103;
        /// <summary>
        /// Default value after MCU reset/boot
        /// </summary>
        public const int StrengthDefault = Strength4ma;
    }

    /// <summary>
    /// Input hysteresis (schmitt trigger mode)
    /// </summary>
    public class SchmittTrigger : BaseFunctions
    {
        /// <summary>
        /// Enable
        /// </summary>
        public const int SchmittEnable = 201;
        /// <summary>
        /// Disable
        /// </summary>
        public const int SchmittDisable = 202;
        /// <summary>
        /// Schmitt trigger is enabled at MCU boot/reset
        /// </summary>
        public const int ScmittDefault = SchmittEnable;
    }

    /// <summary>
    /// How fast to drive the Pin 
    /// Slew Rate
    /// </summary>
    public class SlewRateLimiting : BaseFunctions
    {
        /// <summary>
        /// Slow
        /// </summary>
        public const int SlewSlow = 300;
        /// <summary>
        /// Fast
        /// </summary>
        public const int SlewFast = 301;
        /// <summary>
        /// Default is slow at MCU boot/reset
        /// </summary>
        public const int SlewDefault = SlewSlow;
    }

    /// <summary>
    /// The input buffer can be disabled, 
    /// to reduce current consumption when the pad is unused,
    /// unconnected or connected to an analogue signal.
    /// peripherals
    /// </summary>
    public class PowerSaveFeatures : BaseFunctions
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

    /// <summary>
    ///  Using IOVDD voltages greater than 1.8V, with the input thresholds set for 1.8V may result in damage to the chip
    /// </summary>
    public class VoltageSelect : BaseFunctions
    {
        /// <summary>
        /// Default voltage
        /// </summary>
        public const int Default = Voltage3_3V;
        /// <summary>
        /// voltage 3.3v
        /// </summary>
        public const int Voltage3_3V = 0;
        /// <summary>
        /// voltage 1.8v
        /// </summary>
        public const int Voltage1_8V = 1;
    }
}

/// <summary>
///  The I2C block must only be programmed to operate in either master OR slave mode only.
///  Operating as a master and slave simultaneously is not supported
///  The I2C block can operate in these modes
///  - standard mode (with data rates from 0 to 100kbps)
///  - fast mode (with data rates less than or equal to 400kbps)
///  - fast mode plus(with data rates less than or equal to 1000kbps).
/// </summary>
public enum I2cMode
{
    Slave = 0,
    Master = 1,
    Default = Master
}


public enum I2CSpeed
{
    StandardMode = 100,
    FastMode = 400,
    FastModePlus = 1000,
    Default = FastMode
}

/// <summary>
///  RP2040 has an internal analogue-digital converter (ADC) with the following feature
///  SAR ADC
///  Nominally an ADC moves from one digital value to the next digital value, colloquially expressed as “no missing codes”.
///  The RP2040 ADC has a DNL which is mostly flat, and below 1 LSB.
///  At four values — 512, 1,536, 2,560, and 3,584 — the ADC’s Differential Non-Linearity(DNL) error peaks due to the design of the ADC.
///  This reduces the 12-bit resolution to an ADC with an effective number of bits of 8.7 with extensive measurement.
///
///  Four inputs that are available on package pins shared with GPIO
///  One input is dedicated to the internal temperature sensor
///  
/// One-shot or free-running capture mode
///  Pacing timer (16 integer bits, 8 fractional bits) for setting free-running sample rate
///   Round-robin sampling of multiple channels in free-running capture mode
///   The temperature sensor measures the Vbe voltage of a biased bipolar diode, connected to the fifth ADC channel
///   The on board temperature sensor is very sensitive to errors in the reference voltage.
///   
/// </summary>
/// 
    public enum AdcMode
    {
        RoundRobinSampling = 0,
    }



    public enum UARTInstance
    {
        UART0 = 0,
        UART1 = 1
    }
    public enum UartBaudRate
    {
        B50 = 50,
        B75 = 75,
        B110 = 110,
        B134 = 134,
        B150 = 150,
        B200 = 200,
        B300 = 300,
        B600 = 600,
        B1200 = 1200,
        B1800 = 1800,
        B2400 = 2400,
        B4800 = 4800,
        B9600 = 9600,
        B19200 = 19200,
        B28800 = 28800,
        B38400 = 38400,
        B57600 = 57600,
        B76800 = 76800,
        B115200 = 115200,
        B230400 = 230400,
        B460800 = 460800,
        B576000 = 576000,
        B921600 = 921600,
        Maximum = 7800000
    }
}