using System;
using Microsoft.Win32;
using System.Windows.Forms;

internal static partial class Settings
{
    private enum TrimEnum : Int32
    {
        False = 0,
        True = 1,
        None = 2,
        Error = 3
    }

    private static TrimEnum GetTrim(RegistryKey key)
    {
        try
        {
            Object value = key.GetValue("Trim", null)!;

            if (value == null) return TrimEnum.None;

            if (value is not Int32)
            {
                key.DeleteValue("Trim", false);
                return TrimEnum.None;
            }

            return ((Int32)value) == 1 ? TrimEnum.True : TrimEnum.False;
        }
        catch
        {
            MessageBox.Show("Unable to read:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\Trim", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return TrimEnum.Error;
        }
    }

    private static Boolean SetTrim(RegistryKey key, TrimEnum outputType)
    {
        try
        {
            key.SetValue("Trim", (Int32)outputType, RegistryValueKind.DWord);
            return true;
        }
        catch
        {
            MessageBox.Show("Unable to write:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\Trim", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return false;
        }
    }
}