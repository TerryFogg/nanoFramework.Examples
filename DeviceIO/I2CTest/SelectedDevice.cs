using nanoFramework.Device;

namespace I2CTest
{
    public enum DeviceType
    {
        RP2040,
        RP2350,
        STM32H7B3I_DK,
        STM32H735G,
    }
    public class SelectedDevice
    {
        public DeviceType SelectedDeviceType { get; set; }
        public SelectedDevice(DeviceType SelectedDeviceType)
        {
            this.SelectedDeviceType = SelectedDeviceType;
        }
        public int GetI2cBusId()
        {
            int busId = -1;
            switch (SelectedDeviceType)
            {
                case DeviceType.RP2040:
                case DeviceType.RP2350:
                    busId= RP2XXX.I2c.I2C0;
                    break;
                case DeviceType.STM32H7B3I_DK:
                    busId= STM32H7B3i_dk.I2c.I2C4;
                    break;
                default:
                    break;
            }
            return busId;
        }
    }
}