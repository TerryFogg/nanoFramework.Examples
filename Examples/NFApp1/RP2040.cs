using System;
using System.Collections;
using System.ComponentModel;
using static nanoFramework.IO.RP2040;
using System.Device.Gpio;

namespace nanoFramework.IO
{
    [DesignOnly(true)]
    internal class RP2040
    {
        internal enum PinType
        {
            [Description("""
                         Input Only/Standard Digital. 
                         Programmable Pull-Up, Pull-Down, Slew Rate,
                         Schmitt Trigger and Drive Strength.
                         Default Drive Strength is 4mA.
                         """
                         )]
            DigitalIn,
            [Description("""
                         Bi-directional/Standard Digital. 
                         Programmable Pull-Up, Pull-Down, Slew Rate,
                         Schmitt Trigger and Drive Strength.
                         Default Drive Strength is 4mA.
                         """
                          )]
            DigitalBidirectional,
            [Description("""
                          Input Only/Fault Tolerant Digital. 
                          These pins are described as Fault Tolerant
                          which in this case means that very little current flows into the pin
                          whilst it is below 3.63V and IOVDD is 0V.
                          There is also enhanced ESD protection on these pins.
                          Programmable Pull-Up, Pull-Down, Slew Rate
                          Schmitt Trigger and Drive Strength.
                          Default Drive Strength is 4mA.
                          """
                        )]
            DigitalInput_FaultTolerant,
            [Description("""
                          Bi-directional/Fault Tolerant Digital. 
                          These pins are described as Fault Tolerant
                          which in this case means that very little current flows into the pin
                          whilst it is below 3.63V and IOVDD is 0V.
                          There is also enhanced ESD protection on these pins.
                          Programmable Pull-Up, Pull-Down, Slew Rate
                          Schmitt Trigger and Drive Strength.
                          Default Drive Strength is 4mA.
                          """
                      )]
            DigitalBidirectional_FaultTolerant,
            [Description("""
                          Bi-directional/Standard Digital and ADC input. 
                          Programmable Pull-Up, Pull-Down,
                          Slew Rate, Schmitt Trigger and Drive Strength. Default 
                          Drive Strength is 4mA.
                          """
                      )]
            DigitalBidirectional_Analogue,
            [Description("""
                          These pins are for USB use, and contain internal pull-up and pull-down
                          resistors, as per the USB specification. Note that external 27Ω series
                          resistors are required for USB operation
                          """
                      )]
            UsbBidirectional,



        }
        internal enum GpioPinAssignment
        {
            Gpio0 = 2,
            Gpio1 = 3,
            Gpio2 = 4,
            Gpio3 = 5,
            Gpio4 = 6,
            Gpio5 = 7,
            Gpio6 = 8,
            Gpio7 = 9,
            Gpio8 = 11,
            Gpio9 = 12,
            Gpio10 = 13,
            Gpio11 = 14,
            Gpio12 = 15,
            Gpio13 = 16,
            Gpio14 = 17,
            Gpio15 = 18,
            Gpio16 = 27,
            Gpio17 = 28,
            Gpio18 = 29,
            Gpio19 = 30,
            Gpio20 = 31,
            Gpio21 = 32,
            Gpio22 = 34,
            Gpio23 = 35,
            Gpio24 = 36,
            Gpio25 = 37,
            Gpio26 = 38,
            Gpio27 = 39,
            Gpio28 = 40,
            Gpio29 = 41,
            ADC0 = 38,
            ADC1 = 39,
            ADC2 = 40,
            ADC3 = 41

        }
        internal enum GpioFeatures
        {
            [Description("""
                         Output disable. Has priority over output enable from
                         """
                        )]
            OutputDriverDisabled = 0,
            OutputDriverEnabled = 1,
            OutputDriverDefault = OutputDriverDisabled,
            [Description("""
                         The input buffer can be disabled, 
                         to reduce current consumption when the pad is unused,
                         unconnected or connected to an analogue signal.
                         peripherals
                         """
                        )]
            InputBufferDisabled = 0,
            InputBufferEnabled = 1,
            InputBufferDefault = InputBufferDisabled,
            [Description("""
                         A pull-up or pull-down can be enabled,
                         to set the output signal level when the output driver is disabled
                         """
                        )]
            PullUpDisabled = 0,
            PullUpEnabled = 1,
            PullUpDefault = PullDownDisabled,
            PullDownDisabled = 0,
            PullDownEnabled = 1,
            PullDownDefault = PullDownDisabled,
            [Description("""
                         The GPIOs on RP2040 have four different output drive strengths,
                         which are nominally called 2, 4, 8 and 12mA modes.
                         These are not hard limits, nor do they mean that they will always be sourcing (or sinking)
                         the selected amount of milliamps. The amount of current a GPIO sources or sinks
                         is dependant on the load attached to it.
                         """
                         )]
            Strength2ma = 0,
            Strength4ma = 1,
            Strength8ma = 2,
            Strength12ma = 3,
            StrengthDefault = Strength4ma,

            [Description("""
                         Input hysteresis (schmitt trigger mode)"
                         """
                         )]
            SchmittEnable = 1,
            SchmittDisable = 2,
            ScmittDefault = SchmittEnable,

            SlewSlow = 0,
            SlewFast = 1,
            SlewDefault = SlewSlow,
        }
        internal enum GpioVoltageSelect
        {
            [Description("Using IOVDD voltages greater than 1.8V, with the input thresholds set for 1.8V may result in damage to the chip")]
            Voltage3_3V = 0,
            Voltage1_8V = 1,
            Default = Voltage3_3V
        }
        internal struct BoardPin
        {
            public string Name;
            public GpioPinAssignment Pin;
            public PinType Type;
            public GpioFeatures Drive;
            public GpioVoltageSelect PinVoltage;
        }
        enum Functions
        {
            I2C0,
            I2C1,
            SPI0,
            SPI1,
            UART0,
            UART1,
            PWM0A,
            PWM0B,
            PWM1A,
            PWM1B,
            PWM2A,
            PWM2B,
            PWM3A,
            PWM3B,
            PWM4A,
            PWM4B,
            PWM5A,
            PWM5B,
            PWM6A,
            PWM6B,
            PWM7A,
            PWM7B,
            CLOCK_GPIN0,
            CLOCK_GPOUT0,
            CLOCK_GPIN1,
            CLOCK_GPOUT1,
            CLOCK_GPOUT2,
            CLOCK_GPOUT3
        }


        [Description("""
                      The I2C block must only be programmed to operate in either master OR slave mode only. Operating as a master and
                      slave simultaneously is not supported.
                      """
                    )]
        enum I2C
        {
            [Description("The I2C block can operate in these modes
                         "standard mode (with data rates from 0 to 100kbps)
                " fast mode (with data rates less than or equal to 400kbps)
                fast mode plus (with data rates less than or equal to 1000kbps).")]
            StandardMode = 100,
            FastMode = 400,
            FastModePlus = 1000



        }
    }
    public static class XIAO_RP2040
    {
        public static ArrayList XIAOPinDefinition = new ArrayList();
        static XIAO_RP2040()
        {
            XIAOPinDefinition.Add(new BoardPin { Name = "TX", Pin = GpioPinAssignment.Gpio0, Type = PinType.DigitalBidirectional_FaultTolerant, PinVoltage = default, Drive = default });
            XIAOPinDefinition.Add(new BoardPin { Name = "RX", Pin = GpioPinAssignment.Gpio1, Type = PinType.DigitalBidirectional_FaultTolerant, PinVoltage = default, Drive = default });
            XIAOPinDefinition.Add(new BoardPin { Name = "RX", Pin = GpioPinAssignment.Gpio1, Type = PinType.DigitalBidirectional_FaultTolerant, PinVoltage = default, Drive = default });


        }
    }

    public class PicoBoard
    {
        public PicoBoard() { }
    }

}


