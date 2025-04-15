using System;
using System.Windows.Forms;

internal static partial class Settings
{
    private unsafe static void CheckBoxChanged(Object? sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender!;
        Int32 index = (Int32)checkBox.Tag!;

        if (!(Boolean)_encoding_raw!.Tag! && (index < 32 || index > 126))
        {
            _encoding_base64!.Checked = true;
        }

        fixed (Byte* ptr = CharMap)
        {
            Boolean intermediate = checkBox.Checked;
            CharMap[index] = *(Byte*)&intermediate;
        }
    }
}