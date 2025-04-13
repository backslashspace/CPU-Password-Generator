using System;

internal static partial class Generator
{
    private unsafe static String BufferToString(ref readonly Span<Byte> buffer, UInt16 length)
    {
        String output = new('\0', length);

        fixed (Char* ptr = &output.GetPinnableReference())
        {
            for (Int32 i = 0; i < length; ++i)
            {
                ptr[i] = (Char)buffer[i];
            }
        }

        return output;
    }
}