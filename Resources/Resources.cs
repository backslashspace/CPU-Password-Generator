using System;
using System.IO;
using System.Drawing;

internal static partial class Resources
{
    internal static readonly Boolean Initialized = false;

    internal static readonly Byte[] NativeDLL;
    internal static readonly Icon MainIcon;

    static Resources()
    {
        NativeDLL = Initialize_native();

        MemoryStream memoryStream = new(Initialize_shell32_48(), false);
        MainIcon = new Icon(memoryStream);
        memoryStream.Close();

        Initialized = true;
    }
}