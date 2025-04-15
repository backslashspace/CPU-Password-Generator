using System;
using BSS.Random;
using System.Runtime.InteropServices;

internal static partial class Generator
{
    [StructLayout(LayoutKind.Explicit)]
    private ref struct UIntByteView
    {
        [FieldOffset(0)]
        internal UInt64 UInt64;

        [FieldOffset(0)]
        internal unsafe fixed Byte Bytes[8];
    }

    private unsafe static Boolean FillBuffer(ref readonly Span<Byte> buffer, UInt16 length, Byte* charMapPtr)
    {
        UIntByteView byteSplitter;
        byteSplitter.UInt64 = 0;

        Int32 i = 0;

    TOP:
        if (!HWRandom.ReadSeed64(in byteSplitter.UInt64)) return false;

        if (*(Boolean*)&charMapPtr[byteSplitter.Bytes[0]])
        {
            buffer[i++] = byteSplitter.Bytes[0];
            if (i == length) return true;
        }

        if (*(Boolean*)&charMapPtr[byteSplitter.Bytes[1]])
        {
            buffer[i++] = byteSplitter.Bytes[1];
            if (i == length) return true;
        }

        if (*(Boolean*)&charMapPtr[byteSplitter.Bytes[2]])
        {
            buffer[i++] = byteSplitter.Bytes[2];
            if (i == length) return true;
        }

        if (*(Boolean*)&charMapPtr[byteSplitter.Bytes[3]])
        {
            buffer[i++] = byteSplitter.Bytes[3];
            if (i == length) return true;
        }

        if (*(Boolean*)&charMapPtr[byteSplitter.Bytes[4]])
        {
            buffer[i++] = byteSplitter.Bytes[4];
            if (i == length) return true;
        }

        if (*(Boolean*)&charMapPtr[byteSplitter.Bytes[5]])
        {
            buffer[i++] = byteSplitter.Bytes[5];
            if (i == length) return true;
        }

        if (*(Boolean*)&charMapPtr[byteSplitter.Bytes[6]])
        {
            buffer[i++] = byteSplitter.Bytes[6];
            if (i == length) return true;
        }

        if (*(Boolean*)&charMapPtr[byteSplitter.Bytes[7]])
        {
            buffer[i++] = byteSplitter.Bytes[7];
            if (i == length) return true;
        }

        goto TOP;
    }
}