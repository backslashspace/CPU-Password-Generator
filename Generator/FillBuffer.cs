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

        //

        [FieldOffset(0)]
        internal Byte Byte1;

        [FieldOffset(1)]
        internal Byte Byte2;

        [FieldOffset(2)]
        internal Byte Byte3;

        [FieldOffset(3)]
        internal Byte Byte4;

        [FieldOffset(4)]
        internal Byte Byte5;

        [FieldOffset(5)]
        internal Byte Byte6;

        [FieldOffset(6)]
        internal Byte Byte7;

        [FieldOffset(7)]
        internal Byte Byte8;
    }

    private static Boolean FillBuffer(ref readonly Span<Byte> buffer, UInt16 length)
    {
        UIntByteView byteSplitter = default;
        Int32 i = 0;

    TOP:
        if (!HWRandom.ReadSeed64(in byteSplitter.UInt64)) return false;

        if (Settings.CharMap[byteSplitter.Byte1])
        {
            buffer[i++] = byteSplitter.Byte1;
            if (i == length) return true;
        }

        if (Settings.CharMap[byteSplitter.Byte2])
        {
            buffer[i++] = byteSplitter.Byte2;
            if (i == length) return true;
        }

        if (Settings.CharMap[byteSplitter.Byte3])
        {
            buffer[i++] = byteSplitter.Byte3;
            if (i == length) return true;
        }

        if (Settings.CharMap[byteSplitter.Byte4])
        {
            buffer[i++] = byteSplitter.Byte4;
            if (i == length) return true;
        }

        if (Settings.CharMap[byteSplitter.Byte5])
        {
            buffer[i++] = byteSplitter.Byte5;
            if (i == length) return true;
        }

        if (Settings.CharMap[byteSplitter.Byte6])
        {
            buffer[i++] = byteSplitter.Byte6;
            if (i == length) return true;
        }

        if (Settings.CharMap[byteSplitter.Byte7])
        {
            buffer[i++] = byteSplitter.Byte7;
            if (i == length) return true;
        }

        if (Settings.CharMap[byteSplitter.Byte8])
        {
            buffer[i++] = byteSplitter.Byte8;
            if (i == length) return true;
        }

        goto TOP;
    }
}