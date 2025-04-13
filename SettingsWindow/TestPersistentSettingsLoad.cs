using System;
using Microsoft.Win32;
using System.Windows.Forms;

internal static partial class Settings
{
    private unsafe static void CheckAndLoadPersistentSettings()
    {
        RegistryKey? key = null;

        try
        {
            key = Registry.CurrentUser.OpenSubKey("Software\\BSS\\CpuPasswordGenerator", false);

            if (key == null)
            {
                SetDefaultSelection(false);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator", "PersistentSettings", 0, RegistryValueKind.DWord);
                return;
            }
        }
        catch
        {
            MessageBox.Show("Unable to open:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\n\nUsing defaults", "Registry Error", MessageBoxButtons.OK);
            SetDefaultSelection(false);
            key?.Close();
            return;
        }

        //

        switch (GetPersistentSettings(key))
        {
            case PersistentSettingsEnum.True:
                _persistentSettings!.Checked = true;
                break;

            case PersistentSettingsEnum.False:
                SetDefaultSelection(false);
                key!.Close();
                return;

            case PersistentSettingsEnum.None:
                SetDefaultSelection(false);
                key!.Close();
                return;

            case PersistentSettingsEnum.Error:
                SetDefaultSelection(false);
                return;
        }

        if (!GetCharMap(key, out Byte[] charMap))
        {
            SetDefaultSelection(false);
        }
        else
        {
            fixed (Byte* ptr = charMap)
            {
                for (Int32 i = 0; i < 256; ++i)
                {
                    CheckBoxes[i].Checked = *(Boolean*)&ptr[i];
                }
            }
        }

        switch (GetOutputType(key))
        {
            case OutputTypeEnum.Raw:
                _encoding_raw!.Checked = true;
                break;

            case OutputTypeEnum.Base64:
                _encoding_base64!.Checked = true;
                break;

            case OutputTypeEnum.Error:
                return;
        }

        switch (GetTrim(key))
        {
            case TrimEnum.True:
                _encoding_base64_trim!.Checked = true;
                break;

            case TrimEnum.False:
                _encoding_base64_trim!.Checked = false;
                break;

            case TrimEnum.Error:
                return;
        }

        switch (GetExactLength(key))
        {
            case ExactLengthEnum.True:
                _exactLength!.Checked = true;
                break;

            case ExactLengthEnum.False:
                _exactLength!.Checked = false;
                break;

            case ExactLengthEnum.Error:
                return;
        }

        if (GetLength(key, out UInt16 length)) MainWindow.Length.Text = length.ToString();
        else return;
    }
}