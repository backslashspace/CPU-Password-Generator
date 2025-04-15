using System;
using System.Windows.Forms;

internal static partial class Settings
{
    private static readonly CheckBox[] CheckBoxes = new CheckBox[256];

    private static Page _currentPage;
    private enum Page : UInt32
    {
        ControlCharacters = 0,
        PrintableCharacters = 1,
        ExtendedCharacters = 2,
    }

    /********************************************************************/

    internal static readonly Byte[] CharMap = new Byte[256];

    /********************************************************************/

    internal static Boolean ExactLength { get => _exactLength!.Checked; }
    internal static Boolean EncodeBase64 { get => _encoding_base64!.Checked; }
    internal static Boolean TrimEncodeBase64 { get => _encoding_base64_trim!.Checked; }
    internal static Boolean PersistentSettings { get => _persistentSettings!.Checked; }
}