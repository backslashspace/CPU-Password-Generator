using System;
using System.Windows.Forms;

internal static partial class Settings
{
    private static readonly GroupBox _groupBox = new()
    {
        Text = "Printable Characters",
        Location = new(20, 12),
        Width = 650,
        Height = 307,
        Font = new(MainWindow.FontFamily!, 10)
    };

    private static void AddCharSelection(Form mainForm)
    {
        mainForm.Controls.Add(_groupBox);

        _currentPage = Page.PrintableCharacters;
        SetBoxContent(Page.PrintableCharacters);
    }
}