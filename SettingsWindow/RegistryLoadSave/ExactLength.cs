using System;
using Microsoft.Win32;
using System.Windows.Forms;

internal static partial class Settings
{
    private enum ExactLengthEnum : Int32
    {
        False = 0,
        True = 1,
        None = 2,
        Error = 3
    }

    private static ExactLengthEnum GetExactLength(RegistryKey key)
    {
        try
        {
            Object value = key.GetValue("ExactLength", null)!;

            if (value == null) return ExactLengthEnum.None;

            if (value is not Int32)
            {
                key.DeleteValue("ExactLength", false);
                return ExactLengthEnum.None;
            }

            return ((Int32)value) == 1 ? ExactLengthEnum.True : ExactLengthEnum.False;
        }
        catch
        {
            MessageBox.Show("Unable to read:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\ExactLength", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return ExactLengthEnum.Error;
        }
    }

    private static Boolean SetExactLength(RegistryKey key, ExactLengthEnum outputType)
    {
        try
        {
            key.SetValue("ExactLength", (Int32)outputType, RegistryValueKind.DWord);
            return true;
        }
        catch
        {
            MessageBox.Show("Unable to write:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\ExactLength", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return false;
        }
    }
}