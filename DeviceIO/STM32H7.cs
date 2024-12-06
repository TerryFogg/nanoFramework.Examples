using System;
using nanoFramework.DeviceIOBase;
using static nanoFramework.DeviceIO.STM32H7;

namespace nanoFramework.DeviceIO
{
    public class STM32H7
    {
        // Keep in sync with native "DeviceRegistration.h"
        public class DevicePinFunction
        {
            public const int NONE = 1;
            //When a STM32 device I/O pin is configured as input, one of three options must be selected:
            // • Input with internal pull-up.Pull-up resistors are used in STM32 devices to ensure a
            //   well-defined logical level in case of floating input signal.Depending on application
            // requirements, an external pull-up can be used instead.
            // • Input with internal pull-down.Pull-down resistors are used in STM32 devices to ensure
            //   a well-defined logical level in case of floating input signal.Depending on application
            //   requirements, an external pull-down can be used instead.
            // • Floating input. Signal level follows the external signal. When no external signal is 
            //   present, the Schmitt trigger randomly toggles between the logical levels induced by the
            //   external noise. This increases the overall consumption.
            public const int GPIO = 2;
            public const int ADC = 4;
            public const int DAC = 8;
            public const int SPI = 16;
            public const int PWM = 32;
            public const int I2C = 64;
            public const int USART = 128;
            public const int CAN = 256;
            public const int COUNTER = 512;
            public const int TIMER = 1024;
            public const int I2S = 2048;
            public const int WAKEUP = 4096;
            public const int SD = 8192;
        }
        public class PinNameValue
        {
            public const int NONE = -1;
            public const int GND = -1;
            public const int VCC = -1;
            public const int V5V = -1;
            public const int VDD = -1;
            public const int NC = -1;
            public const int NRST = -1;
            public const int PA0_C = 100;
            public const int PA1_C = 101;
            public const int PC2_C = 102;
            public const int PC3_C = 103;
            public const int PA0 = 0;
            public const int PA1 = 1;
            public const int PA2 = 2;
            public const int PA3 = 3;
            public const int PA4 = 4;
            public const int PA5 = 5;
            public const int PA6 = 6;
            public const int PA7 = 7;
            public const int PA8 = 8;
            public const int PA9 = 9;
            public const int PA10 = 10;
            public const int PA11 = 11;
            public const int PA12 = 12;
            public const int PA13 = 13;
            public const int PA14 = 14;
            public const int PA15 = 15;
            public const int PB0 = 16;
            public const int PB1 = 17;
            public const int PB2 = 18;
            public const int PB3 = 19;
            public const int PB4 = 20;
            public const int PB5 = 21;
            public const int PB6 = 22;
            public const int PB7 = 23;
            public const int PB8 = 24;
            public const int PB9 = 25;
            public const int PB10 = 26;
            public const int PB11 = 27;
            public const int PB12 = 28;
            public const int PB13 = 29;
            public const int PB14 = 30;
            public const int PB15 = 31;
            public const int PC0 = 32;
            public const int PC1 = 33;
            public const int PC2 = 34;
            public const int PC3 = 35;
            public const int PC4 = 36;
            public const int PC5 = 37;
            public const int PC6 = 38;
            public const int PC7 = 39;
            public const int PC8 = 40;
            public const int PC9 = 41;
            public const int PC10 = 42;
            public const int PC11 = 43;
            public const int PC12 = 44;
            public const int PC13 = 45;
            public const int PC14 = 46;
            public const int PC15 = 47;
            public const int PD0 = 48;
            public const int PD1 = 49;
            public const int PD2 = 50;
            public const int PD3 = 51;
            public const int PD4 = 52;
            public const int PD5 = 53;
            public const int PD6 = 54;
            public const int PD7 = 55;
            public const int PD8 = 56;
            public const int PD9 = 57;
            public const int PD10 = 58;
            public const int PD11 = 59;
            public const int PD12 = 60;
            public const int PD13 = 61;
            public const int PD14 = 62;
            public const int PD15 = 63;
            public const int PE0 = 64;
            public const int PE1 = 65;
            public const int PE2 = 66;
            public const int PE3 = 67;
            public const int PE4 = 68;
            public const int PE5 = 69;
            public const int PE6 = 70;
            public const int PE7 = 71;
            public const int PE8 = 72;
            public const int PE9 = 73;
            public const int PE10 = 74;
            public const int PE11 = 75;
            public const int PE12 = 76;
            public const int PE13 = 77;
            public const int PE14 = 78;
            public const int PE15 = 79;
            public const int PF0 = 80;
            public const int PF1 = 81;
            public const int PF2 = 82;
            public const int PF3 = 83;
            public const int PF4 = 84;
            public const int PF5 = 85;
            public const int PF6 = 86;
            public const int PF7 = 87;
            public const int PF8 = 88;
            public const int PF9 = 89;
            public const int PF10 = 90;
            public const int PF11 = 91;
            public const int PF12 = 92;
            public const int PF13 = 93;
            public const int PF14 = 94;
            public const int PF15 = 95;
            public const int PG0 = 96;
            public const int PG1 = 97;
            public const int PG2 = 98;
            public const int PG3 = 99;
            public const int PG4 = 100;
            public const int PG5 = 101;
            public const int PG6 = 102;
            public const int PG7 = 103;
            public const int PG8 = 104;
            public const int PG9 = 105;
            public const int PG10 = 106;
            public const int PG11 = 107;
            public const int PG12 = 108;
            public const int PG13 = 109;
            public const int PG14 = 110;
            public const int PG15 = 111;
            public const int PH0 = 112;
            public const int PH1 = 113;
            public const int PH2 = 114;
            public const int PH3 = 115;
            public const int PH4 = 116;
            public const int PH5 = 117;
            public const int PH6 = 118;
            public const int PH7 = 119;
            public const int PH8 = 120;
            public const int PH9 = 121;
            public const int PH10 = 122;
            public const int PH11 = 123;
            public const int PH12 = 124;
            public const int PH13 = 125;
            public const int PH14 = 126;
            public const int PH15 = 127;
            public const int PI0 = 128;
            public const int PI1 = 129;
            public const int PI2 = 130;
            public const int PI3 = 131;
            public const int PI4 = 132;
            public const int PI5 = 133;
            public const int PI6 = 134;
            public const int PI7 = 135;
            public const int PI8 = 136;
            public const int PI9 = 137;
            public const int PI10 = 138;
            public const int PI11 = 139;
            public const int PI12 = 140;
            public const int PI13 = 141;
            public const int PI14 = 142;
            public const int PI15 = 143;
            public const int PJ0 = 144;
            public const int PJ1 = 145;
            public const int PJ2 = 146;
            public const int PJ3 = 147;
            public const int PJ4 = 148;
            public const int PJ5 = 149;
            public const int PJ6 = 150;
            public const int PJ7 = 151;
            public const int PJ8 = 152;
            public const int PJ9 = 153;
            public const int PJ10 = 154;
            public const int PJ11 = 155;
            public const int PJ12 = 156;
            public const int PJ13 = 157;
            public const int PJ14 = 158;
            public const int PJ15 = 159;
            public const int PK0 = 160;
            public const int PK1 = 161;
            public const int PK2 = 162;
            public const int PK3 = 163;
            public const int PK4 = 164;
            public const int PK5 = 165;
            public const int PK6 = 166;
            public const int PK7 = 167;
            public const int PK8 = 168;
            public const int PK9 = 169;
            public const int PK10 = 170;
            public const int PK11 = 171;
            public const int PK12 = 172;
            public const int PK13 = 173;
            public const int PK14 = 174;
            public const int PK15 = 175;
        }
    }

    public class STM32H7B3I_DK
    {
        public class ArduinoConnector
        {
            // Arduino A0 - ADC1 - channel 18
           public const int A0 = PinNameValue.PA4;
            // Arduino A1 - ADC12 - channel 4
           public const int  A1 = PinNameValue.PC4;
            // Arduino A2 - ADC1 Channel 0
           public const int  A2 = PinNameValue.PA0_C;
            // Arduino A3 - ADC1 - channel 1
           public const int  A3 = PinNameValue.PA1_C;
            // Arduino A4 - ADC2 - channel 0
           public const int  A4 = PinNameValue.PC2_C;
            // Arduino A5 - ADC2 - channel 1
           public const int  A5 = PinNameValue.PC3_C;

            // Arduino D0- D15
           public const int  D0 = PinNameValue.PH14;
           public const int  D1 = PinNameValue.PH13;
           public const int  D2 = PinNameValue.PI9;
           public const int  D3 = PinNameValue.PH9;
           public const int  D4 = PinNameValue.PE2;
           public const int  D5 = PinNameValue.PH11;
           public const int  D6 = PinNameValue.PH10;
           public const int  D7 = PinNameValue.PI10;
           public const int  D8 = PinNameValue.PF10;
           public const int  D9 = PinNameValue.PI7;
           public const int  D10 = PinNameValue.PI0;
           public const int  D11 = PinNameValue.PB15;
           public const int  D12 = PinNameValue.PB14;
           public const int  D13 = PinNameValue.PA12;
           public const int  D14 = PinNameValue.PD13;
           public const int  D15 = PinNameValue.PD12;
        }
        public static class CN16
        {
           public const int  Pin1 = PinNameValue.NC;
           public const int  Pin2 = PinNameValue.GND;
           public const int  Pin3 = PinNameValue.NC;
           public const int  Pin4 = PinNameValue.VDD;
           public const int  Pin5 = PinNameValue.PB6;
           public const int  Pin6 = PinNameValue.PD12;
           public const int  Pin7 = PinNameValue.NC;
           public const int  Pin8 = PinNameValue.PD13;
        };
        public static class CN3
        {
           public const int  Pin1 = PinNameValue.GND;
           public const int  Pin2 = PinNameValue.VCC;
           public const int  Pin3 = PinNameValue.PB0;
           public const int  Pin4 = PinNameValue.PB0;
           public const int  Pin5 = PinNameValue.PB9;
           public const int  Pin6 = PinNameValue.PB12;
           public const int  Pin7 = PinNameValue.PC7;
           public const int  Pin8 = PinNameValue.NC;
           public const int  Pin9 = PinNameValue.NC;
           public const int  Pin10 = PinNameValue.PI6;
           public const int  Pin11 = PinNameValue.NC;
           public const int  Pin12 = PinNameValue.PH15;
           public const int  Pin13 = PinNameValue.NC;
           public const int  Pin14 = PinNameValue.NC;
           public const int  Pin15 = PinNameValue.NC;
           public const int  Pin16 = PinNameValue.NC;
           public const int  Pin17 = PinNameValue.NC;
           public const int  Pin18 = PinNameValue.NC;
           public const int  Pin19 = PinNameValue.VCC;
           public const int  Pin20 = PinNameValue.GND;
        };
        public static  class CN1
        {
           public const int  Pin1 = PinNameValue.GND;
           public const int  Pin2 = PinNameValue.GND;
           public const int  Pin3 = PinNameValue.PI15;
           public const int  Pin4 = PinNameValue.PJ7;
           public const int  Pin5 = PinNameValue.PJ0;
           public const int  Pin6 = PinNameValue.PJ8;
           public const int  Pin7 = PinNameValue.PJ1;
           public const int  Pin8 = PinNameValue.PJ9;
           public const int  Pin9 = PinNameValue.PJ2;
           public const int  Pin10 = PinNameValue.PJ10;
           public const int  Pin11 = PinNameValue.PJ3;
           public const int  Pin12 = PinNameValue.PJ11;
           public const int  Pin13 = PinNameValue.PJ4;
           public const int  Pin14 = PinNameValue.PK0;
           public const int  Pin15 = PinNameValue.PJ5;
           public const int  Pin16 = PinNameValue.PK1;
           public const int  Pin17 = PinNameValue.PJ6;
           public const int  Pin18 = PinNameValue.PK2;
           public const int  Pin19 = PinNameValue.GND;
           public const int  Pin20 = PinNameValue.GND;
           public const int  Pin21 = PinNameValue.PJ12;
           public const int  Pin22 = PinNameValue.PK7;
           public const int  Pin23 = PinNameValue.PJ13;
           public const int  Pin24 = PinNameValue.PA2;
           public const int  Pin25 = PinNameValue.PJ14;
           public const int  Pin26 = PinNameValue.PI12;
           public const int  Pin27 = PinNameValue.PJ15;
           public const int  Pin28 = PinNameValue.PI13;
           public const int  Pin29 = PinNameValue.PK3;
           public const int  Pin30 = PinNameValue.GND;
           public const int  Pin31 = PinNameValue.PK4;
           public const int  Pin32 = PinNameValue.PI14;
           public const int  Pin33 = PinNameValue.PK5;
           public const int  Pin34 = PinNameValue.GND;
           public const int  Pin35 = PinNameValue.PK6;
           public const int  Pin36 = PinNameValue.NRST;
           public const int  Pin37 = PinNameValue.GND;
           public const int  Pin38 = PinNameValue.PD13;
           public const int  Pin39 = PinNameValue.PH2;
           public const int  Pin40 = PinNameValue.PD12;
           public const int  Pin41 = PinNameValue.NC;
           public const int  Pin42 = PinNameValue.NC;
           public const int  Pin43 = PinNameValue.PA1;
           public const int  Pin44 = PinNameValue.PB6;
           public const int  Pin45 = PinNameValue.V5V;
           public const int  Pin46 = PinNameValue.NC;
           public const int  Pin47 = PinNameValue.GND;
           public const int  Pin48 = PinNameValue.NC;
           public const int  Pin49 = PinNameValue.GND;
           public const int  Pin50 = PinNameValue.VCC;
        };
        /// <summary>
        // Note: 
        // For I2C4 -
        // The following addresses are already used
        // TFT LCD touch panel - 0x71, 0x70    - 400 KHz
        // Audio Codex         - 0x95,0x94     - 100 KHz
        // Camera              - 0x61,0x60     - 400 KHz
        /// </summary>
        public static class I2C
        {
            public enum I2CControllers
            {
                I2C4 = 0
            }
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
        }
        /// <summary>
        /// </summary>
        public static class Adc
        {
            public enum ADCControllers
            {
                ADC1 = 0,
                ADC2 = 1
            }
            public enum AdcMode
            {
                RoundRobinSampling = 0,
            }
        }
        /// <summary>
        /// </summary>
        public static class PWM
        {
        }
        public static class SPI
        {
        }
        public static class ClockOut
        {
        }
        /// <summary>
        /// </summary>
        public static class USART
        {
            //  USART1/2/3/6/10
            //   UART4/5/7/8/9
            public const int NumberOfUSARTs = 2;
            public enum USARTControllers
            {
                USART0 = 0
            }
            public enum USARTBaudRate
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
    }
    public static class SDCard
    {
        public static class SD1
        {
           public const int  D0 = PinNameValue.PC8;     // AF12
           public const int  D1 = PinNameValue.PC9;     // AF12
           public const int  D2 = PinNameValue.PC10;    // AF12
           public const int  D3 = PinNameValue.PC11;    // AF12
           public const int  CLK = PinNameValue.PC12;   // AF12
           public const int  CMD = PinNameValue.PD2;    // AF12
           public const int  DETECT = PinNameValue.PI8;  
        }
        public static class SD2
        {
           public const int  D0 = PinNameValue.PB14;      // AF9
           public const int  D1 = PinNameValue.PB15;      // AF9
           public const int  D2 = PinNameValue.PB3;       // AF9
           public const int  D3 = PinNameValue.PB4;       // AF9 
           public const int  CLK = PinNameValue.PC1;      // AF9
           public const int  CMD = PinNameValue.PD7;      // AF11
           public const int  DETECT = PinNameValue.NONE;  // Select a GPIO? 
        }
    }
}
