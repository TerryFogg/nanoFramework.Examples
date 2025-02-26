//using System;
//using System.Device.Gpio;
//using System.Diagnostics;
//using nanoFramework.DeviceIO;
//using nanoFramework.Mcu;
//namespace Gpio
//{
//    public class Program
//    {
//        public static void Main()
//        {
//            Debug.WriteLine("GPIO example");


//            // Gpio4  Not available for input on Pico board
//            // Gpio5  Not available for input on Pico board
//            // Gpio13 Not available for input on Pico board
//            // Gpio22 Not available for input on Pico board


//            GpioController gc = new GpioController();

//            //        InputPullupTest(gc);
//            InputPullupDown(gc);
//        }

//        private static void InputPullupTest(GpioController gc)
//        {
//            gc.OpenPin(RP2040.GPIO.Gpio0, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio1, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio2, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio3, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio6, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio7, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio8, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio9, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio10, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio11, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio12, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio14, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio15, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio16, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio17, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio18, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio19, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio20, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio21, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio25, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio26, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio27, PinMode.InputPullUp);
//            gc.OpenPin(RP2040.GPIO.Gpio28, PinMode.InputPullUp);

//            int pinValue = 0;
//            while (true)
//            {
//                if (gc.Read(RP2040.GPIO.Gpio0) == pinValue)
//                {
//                    Debug.WriteLine("Gpio0");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio1) == pinValue)
//                {
//                    Debug.WriteLine("Gpio1");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio2) == pinValue)
//                {
//                    Debug.WriteLine("Gpio2");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio3) == pinValue)
//                {
//                    Debug.WriteLine("Gpio3");
//                }
//                //if (gc.Read(McuRP2040.GPIO.Gpio4) == pinValue)
//                //{
//                //    Debug.WriteLine("Gpio4");
//                //}
//                //if (gc.Read(McuRP2040.GPIO.Gpio5) == pinValue)
//                //{
//                //    Debug.WriteLine("Gpio5");
//                //}
//                if (gc.Read(RP2040.GPIO.Gpio6) == pinValue)
//                {
//                    Debug.WriteLine("Gpio6");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio7) == pinValue)
//                {
//                    Debug.WriteLine("Gpio7");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio8) == pinValue)
//                {
//                    Debug.WriteLine("Gpio8");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio9) == pinValue)
//                {
//                    Debug.WriteLine("Gpio9");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio10) == pinValue)
//                {
//                    Debug.WriteLine("Gpio10");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio11) == pinValue)
//                {
//                    Debug.WriteLine("Gpio11");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio12) == pinValue)
//                {
//                    Debug.WriteLine("Gpio12");
//                }
//                //if (gc.Read(McuRP2040.GPIO.Gpio13) == pinValue)
//                //{
//                //    Debug.WriteLine("Gpio13");
//                //}
//                if (gc.Read(RP2040.GPIO.Gpio14) == pinValue)
//                {
//                    Debug.WriteLine("Gpio14");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio15) == pinValue)
//                {
//                    Debug.WriteLine("Gpio15");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio16) == pinValue)
//                {
//                    Debug.WriteLine("Gpio16");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio17) == pinValue)
//                {
//                    Debug.WriteLine("Gpio17");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio18) == pinValue)
//                {
//                    Debug.WriteLine("Gpio18");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio19) == pinValue)
//                {
//                    Debug.WriteLine("Gpio19");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio20) == pinValue)
//                {
//                    Debug.WriteLine("Gpio20");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio21) == pinValue)
//                {
//                    Debug.WriteLine("Gpio21");
//                }
//                //if (gc.Read(McuRP2040.GPIO.Gpio22) == pinValue)
//                //{
//                //    Debug.WriteLine("Gpio22");
//                //}
//                if (gc.Read(RP2040.GPIO.Gpio25) == pinValue)
//                {
//                    Debug.WriteLine("Gpio25");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio26) == pinValue)
//                {
//                    Debug.WriteLine("Gpio26");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio27) == pinValue)
//                {
//                    Debug.WriteLine("Gpio27");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio28) == pinValue)
//                {
//                    Debug.WriteLine("Gpio28");
//                }
//            }
//        }

//        private static void InputPullupDown(GpioController gc)
//        {
//            gc.OpenPin(RP2040.GPIO.Gpio0, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio1, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio2, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio3, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio6, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio7, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio8, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio9, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio10, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio11, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio12, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio14, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio15, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio16, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio17, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio18, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio19, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio20, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio21, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio25, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio26, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio27, PinMode.InputPullDown);
//            gc.OpenPin(RP2040.GPIO.Gpio28, PinMode.InputPullDown);


//            while (true)
//            {
//                PinValue value = gc.Read(RP2040.GPIO.Gpio0);
//                Debug.WriteLine(value.ToString());
//            }

//            int pinValue = 0;
//            while (true)
//            {
//                if (gc.Read(RP2040.GPIO.Gpio0) == pinValue)
//                {
//                    Debug.WriteLine("Gpio0");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio1) == pinValue)
//                {
//                    Debug.WriteLine("Gpio1");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio2) == pinValue)
//                {
//                    Debug.WriteLine("Gpio2");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio3) == pinValue)
//                {
//                    Debug.WriteLine("Gpio3");
//                }
//                //if (gc.Read(McuRP2040.GPIO.Gpio4) == pinValue)
//                //{
//                //    Debug.WriteLine("Gpio4");
//                //}
//                //if (gc.Read(McuRP2040.GPIO.Gpio5) == pinValue)
//                //{
//                //    Debug.WriteLine("Gpio5");
//                //}
//                if (gc.Read(RP2040.GPIO.Gpio6) == pinValue)
//                {
//                    Debug.WriteLine("Gpio6");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio7) == pinValue)
//                {
//                    Debug.WriteLine("Gpio7");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio8) == pinValue)
//                {
//                    Debug.WriteLine("Gpio8");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio9) == pinValue)
//                {
//                    Debug.WriteLine("Gpio9");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio10) == pinValue)
//                {
//                    Debug.WriteLine("Gpio10");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio11) == pinValue)
//                {
//                    Debug.WriteLine("Gpio11");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio12) == pinValue)
//                {
//                    Debug.WriteLine("Gpio12");
//                }
//                //if (gc.Read(McuRP2040.GPIO.Gpio13) == pinValue)
//                //{
//                //    Debug.WriteLine("Gpio13");
//                //}
//                if (gc.Read(RP2040.GPIO.Gpio14) == pinValue)
//                {
//                    Debug.WriteLine("Gpio14");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio15) == pinValue)
//                {
//                    Debug.WriteLine("Gpio15");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio16) == pinValue)
//                {
//                    Debug.WriteLine("Gpio16");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio17) == pinValue)
//                {
//                    Debug.WriteLine("Gpio17");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio18) == pinValue)
//                {
//                    Debug.WriteLine("Gpio18");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio19) == pinValue)
//                {
//                    Debug.WriteLine("Gpio19");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio20) == pinValue)
//                {
//                    Debug.WriteLine("Gpio20");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio21) == pinValue)
//                {
//                    Debug.WriteLine("Gpio21");
//                }
//                //if (gc.Read(McuRP2040.GPIO.Gpio22) == pinValue)
//                //{
//                //    Debug.WriteLine("Gpio22");
//                //}
//                if (gc.Read(RP2040.GPIO.Gpio25) == pinValue)
//                {
//                    Debug.WriteLine("Gpio25");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio26) == pinValue)
//                {
//                    Debug.WriteLine("Gpio26");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio27) == pinValue)
//                {
//                    Debug.WriteLine("Gpio27");
//                }
//                if (gc.Read(RP2040.GPIO.Gpio28) == pinValue)
//                {
//                    Debug.WriteLine("Gpio28");
//                }
//            }
//        }

//    }
//}
