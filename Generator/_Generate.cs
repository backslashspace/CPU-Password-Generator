using System;
using System.Windows.Forms;

internal static partial class Generator
{
    internal unsafe static String Generate(UInt16 length)
    {
        Span<Byte> buffer = stackalloc Byte[length];

        fixed (Byte* charMapPtr = Settings.CharMap)
        {
            if (!CharMapIsNotAllZero(charMapPtr))
            {
                MessageBox.Show("Failed to generate password, no characters selected!\n" +
                    "Select at least one character in the settings.", "Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null!;
            }

            if (!FillBuffer(ref buffer, length, charMapPtr))
            {
                MessageBox.Show("Failed to fill buffer with random bytes,\n" +
                    "this usually only happens in very (very) rare cases.\n\n" +
                    "Source overloaded?", "RNG Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null!;
            }
        }

        if (Settings.EncodeBase64) return BufferToBase64String(ref buffer, length, Settings.ExactLength, Settings.TrimEncodeBase64);
        else return BufferToString(ref buffer, length);
    }
}