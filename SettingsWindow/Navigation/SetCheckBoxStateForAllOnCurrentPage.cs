using System;

internal static partial class Settings
{
    private static void SetCheckBoxStateForAllOnCurrentPage(Boolean state)
    {
        Int32 from;
        Int32 to;

        switch (_currentPage)
        {
            case Page.ControlCharacters:
                from = 0;
                to = 32;
                break;

            case Page.PrintableCharacters:
                from = 32;
                to = 128;
                break;

            case Page.ExtendedCharacters:
                from = 128;
                to = 256;
                break;

            default: throw new Exception("Not Implemented");
        }

        for (Int32 i = from; i < to; ++i)
        {
            CheckBoxes[i].Checked = state;
        }
    }
}