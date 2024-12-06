using nanoFramework.Presentation;
using nanoFramework.UI.Input;
using nanoFramework.UI.Threading;
using System;
using System.Device.Gpio;
using nanoFramework.Mcu;

namespace nf_SimpleNPF
{
    public sealed class GPIOButtonInputProvider
    {
        public readonly Dispatcher Dispatcher;
        private ButtonPad[] buttons;
        private DispatcherOperationCallback callback;
        private InputProviderSite site;
        private PresentationSource source;

        public static GpioController gpioController;
        /// <summary>
        /// Maps GPIOs to Buttons that can be processed by 
        /// </summary>
        /// <param name="source"></param>
        public GPIOButtonInputProvider(PresentationSource source)
        {
            var gpioController = new GpioController();

            // Set the input source.
            this.source = source;

            // Register our object as an input source with the input manager and 
            // get back an InputProviderSite object which forwards the input 
            // report to the input manager, which then places the input in the 
            // staging area.
            site = InputManager.CurrentInputManager.RegisterInputProvider(this);

            // Create a delegate that refers to the InputProviderSite object's 
            // ReportInput method.
            callback = new DispatcherOperationCallback(delegate (object report)
            {
                InputReportArgs args = (InputReportArgs)report;
                return site.ReportInput(args.Device, args.Report);
            });
            Dispatcher = Dispatcher.CurrentDispatcher;

            // Create the pins that are needed for the buttons.

            PinValue joyStickUp = McuRP2040.GPIO.Gpio2;
            PinValue joyStickDown = McuRP2040.GPIO.Gpio18;
            PinValue joyStickLeft = McuRP2040.GPIO.Gpio16;
            PinValue joyStickRight = McuRP2040.GPIO.Gpio20;
            PinValue joyStickSelect = McuRP2040.GPIO.Gpio3;
            PinValue KeyASelect = McuRP2040.GPIO.Gpio15;
            PinValue KeyBSelect = McuRP2040.GPIO.Gpio17;

            // Allocate button pads and assign the hardware pins as 
            // input from specific buttons.
            ButtonPad[] buttons = new ButtonPad[]
            {
                new ButtonPad(this, Button.VK_LEFT  , joyStickLeft),
                new ButtonPad(this, Button.VK_RIGHT , joyStickRight),
                new ButtonPad(this, Button.VK_UP    , joyStickUp),
                new ButtonPad(this, Button.VK_SELECT, joyStickSelect),
                new ButtonPad(this, Button.VK_DOWN  , joyStickDown),
                new ButtonPad(this, Button.VK_HOME  , KeyASelect),
                new ButtonPad(this, Button.VK_HELP  , KeyBSelect),
            };
            this.buttons = buttons;
        }

        /// <summary>
        /// Represents a button pad on the emulated device, containing five 
        /// buttons for user input. 
        /// </summary>
        internal class ButtonPad : IDisposable
        {
            private Button button;
            private GPIOButtonInputProvider sink;
            private ButtonDevice buttonDevice;

            /// <summary>
            /// Constructs a ButtonPad object that handles the emulated 
            /// hardware's button interrupts.
            /// </summary>
            /// <param name="sink"></param>
            /// <param name="button"></param>
            /// <param name="pin"></param>
            public ButtonPad(GPIOButtonInputProvider sink, Button button, PinValue pin)
            {
                this.sink = sink;
                this.button = button;

                GpioPin buttonPin = gpioController.OpenPin((int)pin, PinMode.InputPullUp);
                buttonPin.ValueChanged += ButtonPin_ValueChanged;
            }


            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    // dispose managed resources
                    gpioController.Dispose();
                }
                // free native resources
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            private void ButtonPin_ValueChanged(object sender, PinValueChangedEventArgs e)
            {
                DateTime time = DateTime.UtcNow;
                RawButtonActions action = (e.ChangeType == PinEventTypes.Rising) ? RawButtonActions.ButtonUp : RawButtonActions.ButtonDown;
                RawButtonInputReport report = new RawButtonInputReport(sink.source, time, button, action);
                // Queue the button press to the input provider site.
                sink.Dispatcher.BeginInvoke(sink.callback, new InputReportArgs(buttonDevice, report));
            }
        }
    }
}
