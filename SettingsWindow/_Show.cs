using System.Windows.Forms;

internal static partial class Settings
{
    private static readonly ToolTip _toolTip = new()
    {
        Active = true,
        AutoPopDelay = 0,
        ShowAlways = true,
        UseAnimation = true,
        UseFading = true,
        ReshowDelay = 0,
    };

    private static readonly Form _mainForm = new()
    {
        AutoScaleMode = AutoScaleMode.Dpi,
        Text = "Generator Settings",
        Width = 706,
        Height = 485,
        StartPosition = FormStartPosition.CenterScreen,
        AllowTransparency = false,
        MaximizeBox = false,
        FormBorderStyle = FormBorderStyle.FixedSingle,
        ShowInTaskbar = true,
        Icon = Resources.MainIcon,
        HelpButton = false,
    };

    internal static void Show()
    {
        _currentPage = Page.PrintableCharacters;
        _nextPage!.Enabled = true;
        _previousPage!.Enabled = true;

        SetBoxContent(Page.PrintableCharacters);
        SetPageCaption(Page.PrintableCharacters);

        // yellow border
        DwmInterop.SetBorderColor(_mainForm.Handle, 42495u);
        _mainForm.ShowDialog();
    }
}