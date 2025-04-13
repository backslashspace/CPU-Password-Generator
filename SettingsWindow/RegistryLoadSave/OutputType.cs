using System;
using Microsoft.Win32;
using System.Windows.Forms;

internal static partial class Settings
{
    private enum OutputTypeEnum : Int32
    {
        Base64 = 0,
        Raw = 1,
        None = 2,
        Error = 3
    }

    private static OutputTypeEnum GetOutputType(RegistryKey key)
    {
        try
        {
            Object value = key.GetValue("Raw", null)!;

            if (value == null) return OutputTypeEnum.None;

            if (value is not Int32)
            {
                key.DeleteValue("Raw", false);
                return OutputTypeEnum.None;
            }

            return ((Int32)value) == 1 ? OutputTypeEnum.Raw : OutputTypeEnum.Base64;
        }
        catch
        {
            MessageBox.Show("Unable to read:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\Raw", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return OutputTypeEnum.Error;
        }
    }

    private static Boolean SetOutputType(RegistryKey key, OutputTypeEnum outputType)
    {
        try
        {
            key.SetValue("Raw", (Int32)outputType, RegistryValueKind.DWord);
            return true;
        }
        catch
        {
            MessageBox.Show("Unable to write:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\Raw", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return false;
        }
    }
}