using System;

namespace nanoFramework.DeviceIOBase
{
    public partial class I2C
    {
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
}
