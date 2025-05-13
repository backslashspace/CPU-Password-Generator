using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

internal static partial class Generator
{
    private unsafe static Boolean CharMapIsNotAllZero(Byte* charMapPtr)
    {
        if (Avx2.X64.IsSupported) return IsNotAllZeroAVX2(charMapPtr);
        else return IsNotAllZero(charMapPtr);
    }

    /********************************************************************/

    private static readonly Vector256<Byte> MASK = Vector256.Create((Byte)0);

    private unsafe static Boolean IsNotAllZeroAVX2(Byte* charMapPtr)
    {
        //if (length < 1 || buffer == null) throw new Exception("buffer was null or length was less than 1");

        Int32 counter = 0;

        do
        {
            Vector256<Byte> vector = Avx.LoadVector256(charMapPtr + counter);
            Vector256<Byte> result = Avx2.CompareEqual(MASK, vector);

            if (result.ExtractMostSignificantBits() != UInt32.MaxValue) return true;

            counter += 32;
        }
        while (counter < 256);

        return false;
    }

    /********************************************************************/

    private static unsafe Boolean IsNotAllZero(Byte* charMapPtr)
    {
        Int32 counter = -1;

    TOP:
        if (charMapPtr[++counter] != 0) return true;

        if (counter < 256) goto TOP;
        else return false;
    }
}