using System;
using Microsoft.Win32;
using System.Windows.Forms;

internal static partial class Settings
{
    private static Boolean GetLength(RegistryKey key, out UInt16 length)
    {
        length = 16;

        try
        {
            Object value = key.GetValue("Length", null)!;

            if (value == null) return true;

            if (value is not Int32)
            {
                key.DeleteValue("Length", false);
                return true;
            }

            length = (UInt16)(((Int32)value << 16) >> 16);

            return true;
        }
        catch
        {
            MessageBox.Show("Unable to read:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\Length", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return false;
        }
    }

    internal static void ExternalSetLength(UInt16 length)
    {
        RegistryKey? key = null;

        try
        {
            key = Registry.CurrentUser.OpenSubKey("Software\\BSS\\CpuPasswordGenerator", true);
            if (key == null) return;

            SetLength(key, length);
        }
        catch
        {
            MessageBox.Show("Unable to open:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator", "Registry Error", MessageBoxButtons.OK);
            key?.Close();
        }
    }

    internal static Boolean SetLength(RegistryKey key, UInt16 length)
    {
        try
        {
            key.SetValue("Length", (Int32)length, RegistryValueKind.DWord);
            return true;
        }
        catch
        {
            MessageBox.Show("Unable to write:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\Length", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return false;
        }
    }
}