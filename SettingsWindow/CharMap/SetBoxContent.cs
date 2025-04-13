using System;

internal static partial class Settings
{
    private static void SetBoxContent(Page page)
    {
        const Int32 BASE_OFFSET_X = 16;
        const Int32 BASE_OFFSET_Y = 20;

        Int32 from;
        Int32 to;

        switch (page)
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

        //

        _groupBox!.Controls.Clear();

        Int32 x = BASE_OFFSET_X;
        Int32 y = BASE_OFFSET_Y;
        Int32 verticalCount = 0;

        for (Int32 i = from; i < to; ++i)
        {
            if (verticalCount == 13)
            {
                verticalCount = 0;
                x += 64;
                y = BASE_OFFSET_Y;
            }

            CheckBoxes[i].Location = new(x, y);
            _groupBox!.Controls.Add(CheckBoxes[i]);

            y += 21;
            ++verticalCount;
        }
    }
}