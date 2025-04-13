using System;
using Microsoft.Win32;
using System.Windows.Forms;

internal static partial class Settings
{
    private unsafe static Boolean GetCharMap(RegistryKey key, out Byte[] charMap)
    {
        charMap = null!;

        try
        {
            Object value = key.GetValue("CharMap", null)!;

            if (value == null) return false;

            if (value is not Byte[])
            {
                key.DeleteValue("CharMap", false);
                return false;
            }

            charMap = (Byte[])value;

            if (charMap.Length != 256) key.DeleteValue("CharMap", false);
            
            return true;
        }
        catch
        {
            MessageBox.Show("Unable to read:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\CharMap\n\nUsing defaults", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return false;
        }
    }

    private unsafe static Boolean SetCharMap(RegistryKey key)
    {
        Byte[] data = new Byte[256];
        for (Int32 i = 0; i < 256; ++i)
        {
            Boolean checkBoxState = CheckBoxes[i].Checked;
            data[i] = *(Byte*)&checkBoxState;
        }

        try
        {
            key.SetValue("CharMap", data, RegistryValueKind.Binary);
            return true;
        }
        catch
        {
            MessageBox.Show("Unable to set:\nHKEY_CURRENT_USER\\Software\\BSS\\CpuPasswordGenerator\\CharMap", "Registry Error", MessageBoxButtons.OK);
            key!.Close();
            return false;
        }
    }
}