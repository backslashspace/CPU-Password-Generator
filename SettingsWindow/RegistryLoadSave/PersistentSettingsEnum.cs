using System;
using Microsoft.Win32;
using System.Windows.Forms;

internal static partial class Settings
{
    private enum PersistentSettingsEnum : Int32
    {
        False = 0,
        True = 1,
        None = 2,
        Error = 3
    }

    private static PersistentSettingsEnum GetPersistentSettings(RegistryKey key)
    {
        try
        {
            Object value = key.GetValue("PersistentSettings", null)!;

            if (value == null) return PersistentSettingsEnum.None;

            if (value is not Int32)
            {
                key.DeleteValue("PersistentSettings", false);
                return PersistentSettingsEnum.None;
            }

            return ((Int32)value) == 1 ? PersistentSettingsEnum.True : PersistentSettingsEnum.False;
        }
        catch
        {
            MessageBox.Show("Unable to read:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\PersistentSettings", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return PersistentSettingsEnum.Error;
        }
    }

    private static Boolean SetPersistentSettings(RegistryKey key, PersistentSettingsEnum outputType)
    {
        try
        {
            key.SetValue("PersistentSettings", (Int32)outputType, RegistryValueKind.DWord);
            return true;
        }
        catch
        {
            MessageBox.Show("Unable to write:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\PersistentSettings", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return false;
        }
    }
}