internal static partial class Settings
{
    private static void SetPageCaption(Page page)
    {
        switch (page)
        {
            case Page.ControlCharacters:
                _groupBox!.Text = "Control Characters";
                break;

            case Page.PrintableCharacters:
                _groupBox!.Text = "Printable Characters";
                break;

            case Page.ExtendedCharacters:
                _groupBox!.Text = "Extended Characters";
                break;
        }
    }
}