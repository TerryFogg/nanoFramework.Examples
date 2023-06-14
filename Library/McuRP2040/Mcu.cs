using System;
using System.Device.Gpio;

namespace nanoFramework.Mcu
{
    //  RP2040 has 36 multi-functional General Purpose Input / Output(GPIO) pins, divided into two banks.
    //  (QSPI_SS, QSPI_SCLK and QSPI_SD0 to QSPI_SD3) are used to execute code from an external flash device.
    //  This leaves the User bank(GPIO0 to GPIO29) for the general use.
    //  All GPIOs support digital input and output
    //  GPIO26 to GPIO29 can also be used as Analogue to Digital Converter (ADC).
    //  Each GPIO can have one function selected at a time.
    //  Each peripheral input (e.g.UART0 RX) should only be selected on one _GPIO_ at a time.
    //  If the same peripheral input is connected to multiple GPIOs, the peripheral sees the logical OR of these
    //  GPIO inputs.
    public class McuRP2040
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
        public class GPIO
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

            /// <summary>
            /// The GPIOs on RP2040 have four different output drive strengths,
            /// These are not hard limits, nor do they mean that they will always be sourcing (or sinking)
            /// the selected amount of milliamps. 
            /// NOTE: The amount of current a GPIO sources or sinks is dependant on the load attached to it.
            /// </summary>
            public enum NominalDriveStrength
            {
                /// <summary>
                /// Limit current to 2 milliamps
                /// </summary>
                Strength2ma = 0,
                /// <summary>
                /// Limit current to 4 milliamps
                /// </summary>
                Strength4ma = 1,
                /// <summary>
                /// Limit current to 8 milliamps
                /// </summary>
                Strength8ma = 2,
                /// <summary>
                /// Limit current to 12 milliamps
                /// </summary>
                Strength12ma = 3,
                /// <summary>
                /// Default value after MCU reset/boot
                /// </summary>
                StrengthDefault = Strength4ma,
            }

            /// <summary>
            /// Input hysteresis (schmitt trigger mode)
            /// </summary>
            public enum SchmittTrigger
            {
                /// <summary>
                /// Enable
                /// </summary>
                SchmittEnable = 1,
                /// <summary>
                /// Disable
                /// </summary>
                SchmittDisable = 2,
                /// <summary>
                /// Schmitt trigger is enabled at MCU boot/reset
                /// </summary>
                ScmittDefault = SchmittEnable,
            }

            /// <summary>
            /// How fast to drive the Pin 
            /// Slew Rate
            /// </summary>
            public enum SlewRateLimiting
            {
                /// <summary>
                /// Slow
                /// </summary>
                SlewSlow = 0,
                /// <summary>
                /// Fast
                /// </summary>
                SlewFast = 1,
                /// <summary>
                /// Default is slow at MCU boot/reset
                /// </summary>
                SlewDefault = SlewSlow,
            }

            /// <summary>
            /// The input buffer can be disabled, 
            /// to reduce current consumption when the pad is unused,
            /// unconnected or connected to an analogue signal.
            /// peripherals
            /// </summary>
            public enum PowerSaveFeatures
            {
                /// <summary>
                ///  Disable the driver. ??? Has priority over output enable from
                /// </summary>
                OutputDriverDisabled = 0,
                /// <summary>
                /// Enable the output driver disabled at MCU boot/reset
                /// </summary>
                OutputDriverEnabled = 1,
                /// <summary>
                /// Default is output driver disabled at MCU boot/reset
                /// </summary>
                OutputDriverDefault = OutputDriverDisabled,
                /// <summary>
                /// Disable the input buffer to conserve power
                /// </summary>
                InputBufferDisabled = 0,
                /// <summary>
                /// Enable the input buffer
                /// </summary>
                InputBufferEnabled = 1,
                /// <summary>
                /// Default is input buffer disabled at MCU boot/reset
                /// </summary>
                InputBufferDefault = InputBufferDisabled,
            }

            /// <summary>
            ///  Using IOVDD voltages greater than 1.8V, with the input thresholds set for 1.8V may result in damage to the chip
            /// </summary>
            public enum VoltageSelect
            {
                Default = Voltage3_3V,
                Voltage3_3V = 0,
                Voltage1_8V = 1,
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
        public class I2C
        {
            public enum I2CInstance
            {
                I2C0 = 0,
                I2C1 = 1
            }
            public enum I2cMode
            {
                Slave = 0,
                Master = 1,
                Default = Master
            }

            public const int I2C0SCL_Gpio1 = GPIO.Gpio1;
            public const int I2C0SCL_Gpio5 = GPIO.Gpio5;
            public const int I2C0SCL_Gpio9 = GPIO.Gpio9;
            public const int I2C0SCL_Gpio13 = GPIO.Gpio13;
            public const int I2C0SCL_Gpio17 = GPIO.Gpio17;
            public const int I2C0SCL_Gpio21 = GPIO.Gpio21;
            public const int I2C0SCL_Gpio25 = GPIO.Gpio25;
            public const int I2C0SCL_Gpio29 = GPIO.Gpio29;

            public const int I2C0SDA_Gpio0 = GPIO.Gpio0;
            public const int I2C0SDA_Gpio8 = GPIO.Gpio8;
            public const int I2C0SDA_Gpio12 = GPIO.Gpio12;
            public const int I2C0SDA_Gpio16 = GPIO.Gpio16;
            public const int I2C0SDA_Gpio20 = GPIO.Gpio20;
            public const int I2C0SDA_Gpio24 = GPIO.Gpio24;
            public const int I2C0SDA_Gpio28 = GPIO.Gpio28;

            public const int I2C1SCL_Gpio3 = GPIO.Gpio3;
            public const int I2C1SCL_Gpio7 = GPIO.Gpio7;
            public const int I2C1SCL_Gpio11 = GPIO.Gpio11;
            public const int I2C1SCL_Gpio15 = GPIO.Gpio15;
            public const int I2C1SCL_Gpio19 = GPIO.Gpio19;
            public const int I2C1SCL_Gpio23 = GPIO.Gpio23;
            public const int I2C1SCL_Gpio27 = GPIO.Gpio27;

            public const int I2C1SDA_Gpio2 = GPIO.Gpio2;
            public const int I2C1SDA_Gpio6 = GPIO.Gpio6;
            public const int I2C1SDA_Gpio10 = GPIO.Gpio10;
            public const int I2C1SDA_Gpio14 = GPIO.Gpio14;
            public const int I2C1SDA_Gpio18 = GPIO.Gpio18;
            public const int I2C1SDA_Gpio22 = GPIO.Gpio22;
            public const int I2C1SDA_Gpio26 = GPIO.Gpio26;

            public enum I2CSpeed
            {
                StandardMode = 100,
                FastMode = 400,
                FastModePlus = 1000,
                Default = FastMode
            }
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
        public class Adc
        {
            public int NumberOfAdcChannels = 5;
            public const int Adc0 = GPIO.Gpio26;
            public const int Adc1 = GPIO.Gpio27;
            public const int Adc2 = GPIO.Gpio28;
            public const int Adc3 = GPIO.Gpio29;
            public const int AdcInternalTemperature = 0;

            public enum AdcMode
            {
                RoundRobinSampling = 0,
            }
        }


        /// <summary>
        /// The RP2040 PWM block has 8 identical slices.Each slice can drive two PWM output signals, or measure the frequency
        /// or duty cycle of an input signal.This gives a total of up to 16 controllable PWM outputs.
        /// All 30 GPIO pins can be driven by the PWM block.
        /// Each PWM slice is equipped with the following:
        ///   16-bit counter
        ///   8.4 fractional clock divider
        ///   Two independent output channels, duty cycle from 0% to 100% inclusive
        ///   Dual slope and trailing edge modulation
        ///   Edge-sensitive input mode for frequency measurement
        ///   Level-sensitive input mode for duty cycle measurement
        ///   Configurable counter wrap value
        ///   Wrap and level registers are double buffered and can be changed race-free while PWM is running
        ///   Interrupt request and DMA request on counter wrap
        ///   Phase can be precisely advanced or retarded while running(increments of one count)
        /// Slices can be enabled or disabled simultaneously via a single, global control register.The slices then run in perfect
        /// lockstep, so that more complex power circuitry can be switched by the outputs of multiple slices.
        /// </summary>
        public class PWM
        {
            public const int PWM0A_Gpio0 = GPIO.Gpio0;
            public const int PWM0A_Gpio16 = GPIO.Gpio16;
            public const int PWM1A_Gpio2 = GPIO.Gpio2;
            public const int PWM1A_Gpio18 = GPIO.Gpio18;
            public const int PWM2A_Gpio4 = GPIO.Gpio4;
            public const int PWM2A_Gpio20 = GPIO.Gpio20;
            public const int PWM3A_Gpio6 = GPIO.Gpio6;
            public const int PWM3A_Gpio22 = GPIO.Gpio22;
            public const int PWM4A_Gpio8 = GPIO.Gpio8;
            public const int PWM4A_Gpio24 = GPIO.Gpio24;
            public const int PWM5A_Gpio10 = GPIO.Gpio10;
            public const int PWM5A_Gpio26 = GPIO.Gpio26;
            public const int PWM6A_Gpio12 = GPIO.Gpio12;
            public const int PWM6A_Gpio28 = GPIO.Gpio28;
            public const int PWM7A_Gpio14 = GPIO.Gpio14;

            public const int PWM0B_Gpio1 = GPIO.Gpio1;
            public const int PWM0B_Gpio17 = GPIO.Gpio17;
            public const int PWM1B_Gpio3 = GPIO.Gpio3;
            public const int PWM1B_Gpio19 = GPIO.Gpio19;
            public const int PWM2B_Gpio5 = GPIO.Gpio5;
            public const int PWM2B_Gpio21 = GPIO.Gpio21;
            public const int PWM3B_Gpio7 = GPIO.Gpio7;
            public const int PWM3B_Gpio23 = GPIO.Gpio23;
            public const int PWM4B_Gpio9 = GPIO.Gpio9;
            public const int PWM4B_Gpio25 = GPIO.Gpio25;
            public const int PWM5B_Gpio11 = GPIO.Gpio11;
            public const int PWM5B_Gpio27 = GPIO.Gpio27;
            public const int PWM6B_Gpio13 = GPIO.Gpio13;
            public const int PWM6B_Gpio29 = GPIO.Gpio29;
            public const int PWM7B_Gpio15 = GPIO.Gpio15;
        }
        public class SPI
        {
            public const int SPI0CSN_Gpio1 = GPIO.Gpio1;
            public const int SPI0CSN_Gpio5 = GPIO.Gpio5;
            public const int SPI0CSN_Gpio17 = GPIO.Gpio17;
            public const int SPI0CSN_Gpio21 = GPIO.Gpio21;

            public const int SPI0RX_Gpio0 = GPIO.Gpio0;
            public const int SPI0RX_Gpio4 = GPIO.Gpio4;
            public const int SPI0RX_Gpio16 = GPIO.Gpio16;
            public const int SPI0RX_Gpio20 = GPIO.Gpio20;

            public const int SPI0SCK_Gpio2 = GPIO.Gpio2;
            public const int SPI0SCK_Gpio6 = GPIO.Gpio6;
            public const int SPI0SCK_Gpio18 = GPIO.Gpio18;
            public const int SPI0SCK_Gpio22 = GPIO.Gpio22;

            public const int SPI0TX_Gpio3 = GPIO.Gpio3;
            public const int SPI0TX_Gpio7 = GPIO.Gpio7;
            public const int SPI0TX_Gpio19 = GPIO.Gpio19;
            public const int SPI0TX_Gpio23 = GPIO.Gpio23;

            public const int SPI1CSN_Gpio9 = GPIO.Gpio9;
            public const int SPI1CSN_Gpio13 = GPIO.Gpio13;
            public const int SPI1CSN_Gpio25 = GPIO.Gpio25;
            public const int SPI1CSN_Gpio29 = GPIO.Gpio29;

            public const int SPI1RX_Gpio8 = GPIO.Gpio8;
            public const int SPI1RX_Gpio12 = GPIO.Gpio12;
            public const int SPI1RX_Gpio24 = GPIO.Gpio24;
            public const int SPI1RX_Gpio28 = GPIO.Gpio28;

            public const int SPI1SCK_Gpio10 = GPIO.Gpio10;
            public const int SPI1SCK_Gpio14 = GPIO.Gpio14;
            public const int SPI1SCK_Gpio26 = GPIO.Gpio26;

            public const int SPI1TX_Gpio11 = GPIO.Gpio11;
            public const int SPI1TX_Gpio15 = GPIO.Gpio15;
            public const int SPI1TX_Gpio27 = GPIO.Gpio27;
        }
        public class ClockOut
        {
            public const int GPOut0 = GPIO.Gpio21;
            public const int GPOut1 = GPIO.Gpio23;
            public const int GPOut2 = GPIO.Gpio24;
            public const int GPOut3 = GPIO.Gpio25;
        }

        /// <summary>
        /// The RP2040 has 2 identical instances of a UART peripheral, based on the ARM Primecell UART (PL011)
        /// 
        /// Supports a maximum baud rate of UARTCLK / 16 in UART mode (7.8 Mbaud at 125MHz)
        /// 
        ///  Each instance supports the following features:
        ///   Separate 32×8 Tx and 32×12 Rx FIFOs
        ///   Programmable baud rate generator, clocked by clk_peri(see Section 2.15.1)
        ///   Standard asynchronous communication bits(start, stop, parity) added on transmit and removed on receive
        ///   line break detection
        ///   programmable serial interface (5, 6, 7, or 8 bits)
        ///   1 or 2 stop bits
        ///   programmable hardware flow control
        ///   
        /// Offers similar functionality to the industry-standard 16C650 UART device
        /// </summary>
        public class UART
        {
            public const int NumberOfUarts = 2;

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

            public const int UART0CTS_Gpio2 = GPIO.Gpio2;
            public const int UART0CTS_Gpio14 = GPIO.Gpio14;
            public const int UART0CTS_Gpio18 = GPIO.Gpio18;

            public const int UART0RTS_Gpio3 = GPIO.Gpio3;
            public const int UART0RTS_Gpio15 = GPIO.Gpio15;
            public const int UART0RTS_Gpio19 = GPIO.Gpio19;

            public const int UART0RX_Gpio1 = GPIO.Gpio1;
            public const int UART0RX_Gpio13 = GPIO.Gpio13;
            public const int UART0RX_Gpio17 = GPIO.Gpio17;
            public const int UART0RX_Gpio29 = GPIO.Gpio29;

            public const int UART0TX_Gpio0 = GPIO.Gpio0;
            public const int UART0TX_Gpio12 = GPIO.Gpio12;
            public const int UART0TX_Gpio16 = GPIO.Gpio16;
            public const int UART0TX_Gpio28 = GPIO.Gpio28;

            public const int UART1CTS_Gpio6 = GPIO.Gpio6;
            public const int UART1CTS_Gpio10 = GPIO.Gpio10;
            public const int UART1CTS_Gpio22 = GPIO.Gpio22;
            public const int UART1CTS_Gpio26 = GPIO.Gpio26;

            public const int UART1RTS_Gpio7 = GPIO.Gpio7;
            public const int UART1RTS_Gpio11 = GPIO.Gpio11;
            public const int UART1RTS_Gpio23 = GPIO.Gpio23;
            public const int UART1RTS_Gpio27 = GPIO.Gpio27;

            public const int UART1RX_Gpio5 = GPIO.Gpio5;
            public const int UART1RX_Gpio9 = GPIO.Gpio9;
            public const int UART1RX_Gpio21 = GPIO.Gpio21;
            public const int UART1RX_Gpio25 = GPIO.Gpio25;

            public const int UART1TX_Gpio4 = GPIO.Gpio4;
            public const int UART1TX_Gpio8 = GPIO.Gpio8;
            public const int UART1TX_Gpio20 = GPIO.Gpio20;
            public const int UART1TX_Gpio24 = GPIO.Gpio24;

        }
    }
}

