using System;
using Microsoft.Win32;
using System.Windows.Forms;

internal static partial class Settings
{
    private static void FormClosing(Object? sender, FormClosingEventArgs e)
    {
        if (_persistentSettings!.Checked)
        {
            SaveToRegistry();
            return;
        }

        ClearRegistrySettings();
    }

    // # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

    private unsafe static void ClearRegistrySettings()
    {
        RegistryKey? key = null;

        try
        {
            key = Registry.CurrentUser.OpenSubKey("Software\\BSS\\CpuPasswordGenerator", true);

            if (key == null) return;
        }
        catch
        {
            MessageBox.Show("Unable to open:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator", "Registry Error", MessageBoxButtons.OK);
            key?.Close();
            return;
        }

        try
        {
            key.DeleteValue("PersistentSettings", false);
            key.DeleteValue("CharMap", false);
            key.DeleteValue("ExactLength", false);
            key.DeleteValue("Length", false);
            key.DeleteValue("Raw", false);
            key.DeleteValue("Trim", false);
        }
        catch (Exception exception)
        {
            MessageBox.Show("Unable to remove values in:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\\n\n" + exception.Message, "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return;
        }
    }

    private unsafe static void SaveToRegistry()
    {
        RegistryKey? key = null;

        try
        {
            key = Registry.CurrentUser.OpenSubKey("Software\\BSS\\CpuPasswordGenerator", true);

            if (key == null) return;
        }
        catch
        {
            MessageBox.Show("Unable to open:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator", "Registry Error", MessageBoxButtons.OK);
            key?.Close();
            return;
        }

        if (!SetCharMap(key)) return;
        if (!SetOutputType(key, _encoding_raw!.Checked ? OutputTypeEnum.Raw : OutputTypeEnum.Base64)) return;
        if (!SetTrim(key, _encoding_base64_trim!.Checked ? TrimEnum.True : TrimEnum.False)) return;
        if (!SetExactLength(key, _exactLength!.Checked ? ExactLengthEnum.True : ExactLengthEnum.False)) return;

        Tuple<Boolean, UInt16> lengthTuple = (Tuple<Boolean, UInt16>)MainWindow.Length!.Tag!;
        if (!SetLength(key, lengthTuple.Item1 ? lengthTuple.Item2 : (UInt16)16)) return;

        SetPersistentSettings(key, PersistentSettingsEnum.True);

        key?.Close();
    }
}