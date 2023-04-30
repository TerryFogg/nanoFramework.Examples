//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace nanoFramework.UI
{

    /// <summary>
    /// Available screen orientations
    /// </summary>
    public enum DisplayOrientation : byte
    {
        /// <summary>
        /// Portrait
        /// </summary>
        PORTRAIT,
        /// <summary>
        /// Portrait 180
        /// </summary>
        PORTRAIT180,
        /// <summary>
        /// Landscape
        /// </summary>
        LANDSCAPE,
        /// <summary>
        /// Landscape 180
        /// </summary>
        LANDSCAPE180
    };

    /// <summary>
    /// 
    /// </summary>
    public enum PowerState : byte
    {
        /// <summary>
        /// 
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 
        /// </summary>
        Sleep = 1
    }

    /// <summary>
    /// 
    /// </summary>
    public class DisplayController
    {
        /// <summary>
        /// Translate jagged array to byte[] for sending to c++ code
        /// </summary>
        /// <param name="controllerInitializationCodes"></param>
        /// <param name="LongerSide"></param>
        /// <param name="ShorterSide"></param>
        /// <param name="Orientation"></param>
        /// <param name="BitsPerPixel">Only 16 bits supported although the original code base has some native 'leftover' code for 1-bit</param>
        public void Intialize(byte[][] controllerInitializationCodes, int LongerSide, int ShorterSide, DisplayOrientation Orientation, int BitsPerPixel = 16)
        {
            this.LongerSide = LongerSide;
            this.ShorterSide = ShorterSide;
            this.Orientation = Orientation;

            byte[] SingleDimensionArray = new byte[controllerInitializationCodes.Length];
            for (int i = 0; i < controllerInitializationCodes.Length; i++)
            {
                Array.Copy(controllerInitializationCodes[i], SingleDimensionArray, controllerInitializationCodes[i].Length);
            }
            InitializeDisplayController(SingleDimensionArray, LongerSide, ShorterSide, Orientation);
        }

        /// <summary>
        /// The screens number of pixels for the longer side.
        /// </summary>
        public int LongerSide;

        /// <summary>
        /// The screens number of pixels for the shorter side.
        /// </summary>
        public int ShorterSide;

        /// <summary>
        /// The displays number of pixel for the width based on the orientation.
        /// </summary>
        public int CurrentScreenWidth;

        /// <summary>
        /// The displays number of pixel for the height based on the orientation.
        /// </summary>
        public int CurrentScreenHeight;

        /// <summary>
        /// Currently 16 bits in RBG565 format. ( There is some 1 bit code available but untested )
        /// </summary>
        public int BitsPerPixel;


        /// <summary>
        /// Return the current display orientation landscape, portrait.
        /// </summary>
        public DisplayOrientation Orientation;


        #region Native calls
        /// <summary>
        /// Send device initialization codes to the DisplayController
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern static void InitializeDisplayController(byte[] IntialisationCodes, int LongerSide, int ShorterSide, DisplayOrientation Orientation);

        /// <summary>
        /// Change display orientation, not all display drivers support every orientation.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern static void ChangeOrientation(DisplayOrientation Orientation);

        /// <summary>
        /// Clears the screen.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern static void Clear();
        #endregion


    }
    /// <summary>
    /// 
    /// </summary>


    /// <summary>
    /// 
    /// </summary>
    public enum BusType
    {
        /// <summary>
        /// 
        /// </summary>
        SPI,
        /// <summary>
        /// 
        /// </summary>
        I2C,
        /// <summary>
        /// 
        /// </summary>
        VIDEO,
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public struct DisplayControllerConfiguration
    {
        /// <summary>
        /// The number of pixels of the displays longest edge 
        /// </summary>
        public int LongerSide;
        /// <summary>
        /// The number of pixels of the displays shortest edge 
        /// </summary>
        public int ShorterSide;
        /// <summary>
        /// Sets the bus type
        /// </summary>
        public BusType busType;
        /// <summary>
        /// Configuration parameters in communicating with the display controller via SPI bus
        /// </summary>
        public struct SPIConfig
        {
            /// <summary>
            ///
            /// </summary>
            public int GpioSpiBus;
            /// <summary>
            ///
            /// </summary>
            public int GpioClock;
            /// <summary>
            ///
            /// </summary>
            public int GpioMosi;
            /// <summary>
            /// 
            /// </summary>
            public int GpioMiso;
            /// <summary>
            /// 
            /// </summary>
            public int GpioChipSelect;
            /// <summary>
            /// 
            /// </summary>
            public bool GpioChipSelectActiveLow;
            /// <summary>
            /// 
            /// </summary>
            public int GpioDataCommand;
            /// <summary>
            /// 
            /// </summary>
            public bool GpioDataCommandActiveLow;
            /// <summary>
            /// 
            /// </summary>
            public int GpioDisplayReset;
            /// <summary>
            /// 
            /// </summary>
            public bool GpioDisplayResetActiveLow;
            /// <summary>
            /// 
            /// </summary>
            public int GpioBacklight;
            /// <summary>
            /// 
            /// </summary>
            public bool GpioBacklightActiveLow;
        }
        /// <summary>
        /// 
        /// </summary>
        public struct I2C
        {
            /// <summary>
            ///
            /// </summary>
            public int Address;
            /// <summary>
            ///
            /// </summary>
            public int GpioSda;
            /// <summary>
            ///
            /// </summary>
            public int GpioScl;
        }
        /// <summary>
        /// 
        /// </summary>
        public struct Video
        {
            /// <summary>
            /// 
            /// </summary>
            public int GpioEnable;
            /// <summary>
            /// 
            /// </summary>
            public int GpioControl;
            /// <summary>
            /// 
            /// </summary>
            public int GpioBacklight;
            /// <summary>
            /// 
            /// </summary>
            public int Horizontal_synchronization;
            /// <summary>
            /// 
            /// </summary>
            public int HorizontalBackPorch;
            /// <summary>
            /// 
            /// </summary>
            public int HorizontalFrontPorch;
            /// <summary>
            /// 
            /// </summary>
            public int VerticalSynchronization;
            /// <summary>
            /// 
            /// </summary>
            public int VerticalBackPorch;
            /// <summary>
            /// 
            /// </summary>
            public int VerticalFrontPorch;
        }
    }
}



