// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Device.I2c;
using System.Diagnostics;
using System.Threading;


public struct ScanResultStruct
{
    public bool Success;
    public uint bytesTransferred;
}

public class I2CScanner
{
    public ScanResultStruct[] ScanResult { get; set; }
    public int BusID { get; set; }
    public const int UnimportantantValue = 0x07;
    public I2CScanner(int busId)
    {
        BusID = busId;
        ScanResult = new ScanResultStruct[256];
    }
    public void Scan(int LastAddressToScan)
    {
        Debug.WriteLine("Hello from I2C Scanner!");
        SpanByte span = new byte[1];
        // Scan the 
        for (int i = 0; i <= LastAddressToScan; i++)
        {
            I2cDevice i2c = new(new I2cConnectionSettings(BusID, i));

            I2cTransferResult result = i2c.WriteByte(UnimportantantValue);

            // A successfull write will be return a status of I2cTransferStatus.FullTransfer
            ScanResult[i].Success = (result.Status ==  I2cTransferStatus.FullTransfer);
            ScanResult[i].bytesTransferred = result.BytesTransferred;
            i2c.Dispose();
        }
    }
    internal void Finish()
    {
        // Nothing to do
    }
}