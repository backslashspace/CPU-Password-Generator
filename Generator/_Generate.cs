using System;
using System.Windows.Forms;

internal static partial class Generator
{
    internal unsafe static String Generate(UInt16 length)
    {
        Span<Byte> buffer = stackalloc Byte[length];

        if (!FillBuffer(ref buffer, length))
        {
            MessageBox.Show("Failed to fill buffer with random bytes,\nthis usually only happens in very (very) rare cases.\n\nSource overloaded?", "RNG Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return null!;
        }

        if (Settings.EncodeBase64) return BufferToBase64String(ref buffer, length, Settings.ExactLength, Settings.TrimEncodeBase64);
        else return BufferToString(ref buffer, length);
    }
}