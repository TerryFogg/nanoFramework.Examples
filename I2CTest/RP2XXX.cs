using System;
using System.Device.Gpio;
using System.Runtime.InteropServices;

namespace GPIOTest
{
    // https://pico2.pinout.xyz/
    internal class RP2XXX
    {
        public class PinFunction
        {
            public static int NONE = 100;
            public static int ADC = 101;
            public static int CAN = 102;
            public static int COUNTER = 103;
            public static int DAC = 104;
            public static int GPIO = 105;
            public static int I2C = 106;
            public static int I2S = 107;
            public static int PWM = 108;
            public static int SD = 109;
            public static int SPI = 110;
            public static int TIMER = 111;
            public static int UART = 112;
            public static int HSTX = 113;
        };
        public static class PICO
        {
            public class GP0 : object
            {
                public static int Gpio = 0;
                public static int SPI0_RX = PinFunction.SPI;
                public static int I2C0_SDA = PinFunction.I2C;
                public static int UART0_TX = PinFunction.UART;
                public static int PWM0_A = PinFunction.PWM;
            }
            public class GP1 : object
            {
                public static int Gpio = 1;
                public static int SPI0_CSn = PinFunction.SPI;
                public static int I2C0_SCL = PinFunction.I2C;
                public static int UART0_RX = PinFunction.UART;
                public static int PWM0_B = PinFunction.PWM;
            }
            public class GP2 : object
            {
                public static int Gpio = 2;
                public static int SPI0_SCK = PinFunction.SPI;
                public static int I2C1_SDA = PinFunction.I2C;
                public static int UART0_CTS = PinFunction.UART;
                public static int PWM1_A = PinFunction.PWM;
            }
            public class GP3 : object
            {
                public static int Gpio = 3;
                public static int SPI0_TX = PinFunction.SPI;
                public static int I2C1_SCL = PinFunction.I2C;
                public static int UART0_RTS = PinFunction.UART;
                public static int PWM1_B = PinFunction.PWM;
            }
            public class GP4 : object
            {
                public static int Gpio = 4;
                public static int SPI0_RX = PinFunction.SPI;
                public static int I2C0_SDA = PinFunction.I2C;
                public static int UART1_TX = PinFunction.UART;
                public static int PWM2_A = PinFunction.PWM;
            }
            public class GP5 : object
            {
                public static int Gpio = 5;
                public static int SPI0_CSn = PinFunction.SPI;
                public static int I2C0_SCL = PinFunction.I2C;
                public static int UART1_RX = PinFunction.UART;
                public static int PWM2B = PinFunction.PWM;
            }
            public class GP6 : object
            {
                public static int Gpio = 6;
                public static int SPI0_SCK = PinFunction.SPI;
                public static int I2C1_SDA = PinFunction.I2C;
                public static int UART1_CTS = PinFunction.UART;
                public static int PWM3A = PinFunction.PWM;
            }
            public class GP7 : object
            {
                public static int Gpio = 7;
                public static int SPI0_TX = PinFunction.SPI;
                public static int I2C1_SCL = PinFunction.I2C;
                public static int UART1_RTS = PinFunction.UART;
                public static int PWM3B = PinFunction.PWM;
            }
            public class GP8 : object
            {
                public static int Gpio = 8;
                public static int SPI1_RX = PinFunction.SPI;
                public static int I2C0_SDA = PinFunction.I2C;
                public static int UART1_TX = PinFunction.UART;
                public static int PWM4A = PinFunction.PWM;
            }
            public class GP9 : object
            {
                public static int Gpio = 9;
                public static int SPI1_CSn = PinFunction.SPI;
                public static int I2C0_SCL = PinFunction.I2C;
                public static int UART1_RX = PinFunction.UART;
                public static int PWM4B = PinFunction.PWM;
            }
            public class GP10 : object
            {
                public static int Gpio = 10;
                public static int SPI1_SCK = PinFunction.SPI;
                public static int I2C1_SDA = PinFunction.I2C;
                public static int UART1_CTS = PinFunction.UART;
                public static int PWM5A = PinFunction.PWM;
            }
            public class GP11 : object
            {
                public static int Gpio = 11;
                public static int SPI1_TX = PinFunction.SPI;
                public static int I2C1_SCL = PinFunction.I2C;
                public static int UART1_RTS = PinFunction.UART;
                public static int PWM5B = PinFunction.PWM;
            }
            public class GP12 : object
            {
                public static int Gpio = 12;
                public static int SPI1_RX = PinFunction.SPI;
                public static int I2C0_SDA = PinFunction.I2C;
                public static int UART0_TX = PinFunction.UART;
                public static int PWM6A = PinFunction.PWM;
            }
            public class GP13 : object
            {
                public static int Gpio = 13;
                public static int SPI1_CSn = PinFunction.SPI;
                public static int I2C0_SCL = PinFunction.I2C;
                public static int UART0_RX = PinFunction.UART;
                public static int PWM6B = PinFunction.PWM;
            }
            public class GP14 : object
            {
                public static int Gpio = 14;
                public static int SPI1_SCK = PinFunction.SPI;
                public static int I2C1_SDA = PinFunction.I2C;
                public static int UART0_CTS = PinFunction.UART;
                public static int PWM7A = PinFunction.PWM;
            }
            public class GP15 : object
            {
                public static int Gpio = 15;
                public static int SPI1_TX = PinFunction.SPI;
                public static int I2C1_SCL = PinFunction.I2C;
                public static int UART0_RTS = PinFunction.UART;
                public static int PWM7B = PinFunction.PWM;
            }
            public class GP16 : object
            {
                public static int Gpio = 16;
                public static int SPI0_RX = PinFunction.SPI;
                public static int I2C0_SDA = PinFunction.I2C;
                public static int UART0_TX = PinFunction.UART;
                public static int PWM0A = PinFunction.PWM;
            }
            public class GP17 : object
            {
                public static int Gpio = 17;
                public static int SPI0_CSn = PinFunction.SPI;
                public static int I2C0_SCL = PinFunction.I2C;
                public static int UART0_RX = PinFunction.UART;
                public static int PWM0B = PinFunction.PWM;
            }
            public class GP18 : object
            {
                public static int Gpio = 18;
                public static int SPI0_SCK = PinFunction.SPI;
                public static int I2C1_SDA = PinFunction.I2C;
                public static int UART0_CTS = PinFunction.UART;
                public static int PWM1A = PinFunction.PWM;
            }
            public class GP19 : object
            {
                public static int Gpio = 19;
                public static int SPI0_TX = PinFunction.SPI;
                public static int I2C1_SCL = PinFunction.I2C;
                public static int UART0_RTS = PinFunction.UART;
                public static int PWM1B = PinFunction.PWM;
            }
            public class GP20 : object
            {
                public static int Gpio = 20;
                public static int SPI0_RX = PinFunction.SPI;
                public static int I2C0_SDA = PinFunction.I2C;
                public static int UART1_TX = PinFunction.UART;
                public static int PWM2A = PinFunction.PWM;
            }
            public class GP21 : object
            {
                public static int Gpio = 21;
                public static int SPI0_CSn = PinFunction.SPI;
                public static int I2C0_SCL = PinFunction.I2C;
                public static int UART1_RX = PinFunction.UART;
                public static int PWM2B = PinFunction.PWM;
            }
            public class GP22 : object
            {
                public static int Gpio = 22;
                public static int SPI0_SCK = PinFunction.SPI;
                public static int I2C1_SDA = PinFunction.I2C;
                public static int UART1_CTS = PinFunction.UART;
                public static int PWM3A = PinFunction.PWM;
            }
            public class GP26 : object
            {
                public static int Gpio = 26;
                public static int SPI1_SCK = PinFunction.SPI;
                public static int I2C1_SDA = PinFunction.I2C;
                public static int UART1_CTS = PinFunction.UART;
                public static int PWM5A = PinFunction.PWM;
                public static int ADC0 = PinFunction.ADC;
            }
            public class GP27 : object
            {
                public static int Gpio = 27;
                public static int SPI1_TX = PinFunction.SPI;
                public static int I2C1_SCL = PinFunction.I2C;
                public static int UART1_RTS = PinFunction.UART;
                public static int PWM5B = PinFunction.PWM;
                public static int ADC1 = PinFunction.ADC;
            }
            public class GP28 : object
            {
                public static int Gpio = 28;
                public static int SPI1_RX = PinFunction.SPI;
                public static int I2C0_SDA = PinFunction.I2C;
                public static int UART0_TX = PinFunction.UART;
                public static int PWM6A = PinFunction.PWM;
                public static int ADC2 = PinFunction.ADC;
            }

            public class I2C
            {
                public static int I2C0=0;
                public static int I2C1=0;
            }
        }
        public static class PICO2
        {
            public class GP0 : object
            {
                public static int Gpio = 0;
                public static int SPI0_RX = PinFunction.SPI;
                public static int I2C0_SDA = PinFunction.I2C;
                public static int UART0_TX = PinFunction.UART;
                public static int PWM0_A = PinFunction.PWM;
            }
            public class GP1 : object
            {
                public static int Gpio = 1;
                public static int SPI0_CSn = PinFunction.SPI;
                public static int I2C0_SCL = PinFunction.I2C;
                public static int UART0_RX = PinFunction.UART;
                public static int PWM0_B = PinFunction.PWM;
            }
            public class I2C
            {
                public static int I2C0 = 0;
                public static int I2C1 = 0;
            }
        }
    }
}
