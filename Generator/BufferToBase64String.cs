using System;

internal static partial class Generator
{
    private static readonly Int32[] PaddingLengthMap = [0, 2, 1];

    private unsafe static String BufferToBase64String(ref readonly Span<Byte> buffer, Int32 length, Boolean exactLength, Boolean trim)
    {
        String base64 = Convert.ToBase64String(buffer, Base64FormattingOptions.None);

        if (exactLength)
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

        if (trim)
        {
            Int32 base64Length = base64.Length - PaddingLengthMap[length % 3];

            String output = new('\0', base64Length);

            fixed (Char* ptr = &output.GetPinnableReference())
            {
                for (Int32 i = 0; i < base64Length; ++i)
                {
                    ptr[i] = base64[i];
                }
            }

            return output;
        }

        return Convert.ToBase64String(buffer, Base64FormattingOptions.None);
    }
}