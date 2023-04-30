using System;


/*
ST7789 is a 262,144-color single-chip SOC driver for a-TFT liquid crystal
display with resolution of up to 240RGBx320 dots, comprising a 720-channel source
driver, a 320-channel gate driver, 172,800 bytes GRAM for graphic display data
of 240RGBx320 dots, and power supply circuit.


NOTE: This code is a display for 240x132 which does not match the controller
240x320 For PORTRAIT and LANDSCAPE180 there are no problems because the
remaining (320-240), 80 pixels are not displayed For Portrait180 and LANDSCAPE
the (320-240), 80 Pixels are at the start and are visible. This causes an 80
pixel offset that must be programmed for.
*/

/*
 Using the default endian order for transferring bytes
 Normal (MSB first, default)
  */


namespace nanoFramework.UI.Displays
{
    internal class Pico_LCD_114V2_ST7789VW : DisplayController.DisplayController
    {
        #region ST7789 commands
        const byte Nop = 0x00;
        const byte Software_Reset = 0x01;
        const byte Sleep_IN = 0x10;
        const byte Sleep_Out = 0x11;
        const byte ST7789_PTLON = 0x12;
        const byte Normal_Display_On = 0x13;
        const byte Display_Inversion_Off = 0x20;
        const byte Display_Inversion_On = 0x21;
        const byte Display_Off = 0x28;
        const byte Display_On = 0x29;
        const byte Column_Address_Set = 0x2A;
        const byte Row_Address_Set = 0x2B;
        const byte Memory_Write = 0x2C;
        const byte Memory_Read = 0x2E;
        const byte Partial_Area = 0x30;
        const byte Vertical_Scroll = 0x33;
        const byte Memory_Access_Control = 0x36;
        const byte Pixel_Format_Set = 0x3A;
        const byte Memory_Write_Continue = 0x3C;
        const byte Write_Display_Brightness = 0x51;
        const byte Porch_Setting = 0xB2;
        const byte Gate_Control = 0xB7;
        const byte VCOMS_Setting = 0xBB;
        const byte LCM_Control = 0xC0;
        const byte VDV_VRH_Command_Enable = 0xC2;
        const byte VRH_Set = 0xC3;
        const byte VDV_Set = 0xC4;
        const byte Frame_Rate_Control = 0xC6;
        const byte Power_Control_1 = 0xD0;
        const byte Positive_Voltage_Gamma = 0xE0;
        const byte Negative_Voltage_Gamma = 0xE1;
        #endregion

        #region ST7789 Orientation codes
        public const byte MADCTL_MH = 0x04;  // sets the Horizontal Refresh, 0=Left-Right and 1=Right-Left
        public const byte MADCTL_BGR = 0x08; // Blue-Green-Red pixel order
        public const byte MADCTL_ML = 0x10;  // sets the Vertical Refresh, 0=Top-Bottom and 1=Bottom-Top
        public const byte MADCTL_MV = 0x20;  // sets the Row/Column Swap, 0=Normal and 1=Swapped
        public const byte MADCTL_MX = 0x40;  // sets the Column Order, 0=Left-Right and 1=Right-Left
        public const byte MADCTL_MY = 0x80;  // sets the Row Order, 0=Top-Bottom and 1=Bottom-Top
        #endregion

        const byte DelayCode = 255;

        // Ordered initialization codes and delays necessary to 
        public byte[][] ControllerInitializationCodes = new byte[][]
            {
                new byte[] {Software_Reset},
                new byte[] {Pixel_Format_Set, 0x55},
                new byte[] {DelayCode, 20},
                new byte[] {Porch_Setting, 0x0c, 0x0c, 0x00, 0x33, 0x33},
                new byte[] {Gate_Control, 0x35},
                new byte[] {VCOMS_Setting, 0x19},
                new byte[] {LCM_Control, 0x2C},
                new byte[] {VDV_VRH_Command_Enable, 0x01},
                new byte[] {VRH_Set, 0x12},
                new byte[] {VDV_Set, 0x20},
                new byte[] {Frame_Rate_Control, 0x0F},
                new byte[] {Power_Control_1, 0xA4, 0xA1},
                new byte[] {Positive_Voltage_Gamma, 0xD0, 0x04, 0x0D, 0x11, 0x13, 0x2B, 0x3F, 0x54, 0x4C, 0x18, 0x0D, 0x0B, 0x1F, 0x23},
                new byte[] {Negative_Voltage_Gamma, 0xD0, 0x04, 0x0C, 0x11, 0x13, 0x2C, 0x3F, 0x44, 0x51, 0x2F, 0x1F, 0x1F, 0x20, 0x23},
                new byte[] {Display_Inversion_On},
                new byte[] {Sleep_Out},
                new byte[] {DelayCode, 20},
                new byte[] {Normal_Display_On},
                new byte[] {Nop},
                new byte[] {DelayCode, 10}
            };

        void Initialize()
        {
            base.Intialize(ControllerInitializationCodes);

        }
    }
}
