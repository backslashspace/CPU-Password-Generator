using System;
using System.Windows.Forms;

internal static partial class Settings
{
    private static readonly Button? _nextPage = new()
    {
        Text = "", // >
        UseVisualStyleBackColor = true,
        FlatStyle = FlatStyle.System,
        Location = new(639, 348),
        Height = 32,
        Width = 32,
        Font = new("Segoe Fluent Icons", 11),
    };

    private static readonly Button? _previousPage = new()
    {
        Text = "", // <
        UseVisualStyleBackColor = true,
        FlatStyle = FlatStyle.System,
        Location = new(589, 348),
        Height = 32,
        Width = 32,
        Font = new("Segoe Fluent Icons", 11),
    };

    // # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

    private static void AddPageNavigation(Form mainForm)
    {
        _toolTip.SetToolTip(_nextPage!, "Next Page");
        _nextPage!.Click += NextPage;
        mainForm.Controls.Add(_nextPage);

        _toolTip.SetToolTip(_previousPage!, "Previous Page");
        _previousPage!.Click += PreviousPage;
        mainForm.Controls.Add(_previousPage);

        Button close = new()
        {
            Text = "Close",
            UseVisualStyleBackColor = true,
            FlatStyle = FlatStyle.System,
            Location = new(589, 384),
            Height = 32,
            Width = 82,
            Font = new(MainWindow.FontFamily!, 11)
        };
        close.Click += (s, e) => mainForm.Close();
        mainForm.Controls.Add(close);

        AddEncodingOptions(mainForm);
        AddSelectorOptions(mainForm);
        AddProgramOptions(mainForm);
    }

    // # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

    private static void PreviousPage(Object? sender, EventArgs e)
    {
        if (_currentPage == 0) return;

        --_currentPage;

        SetBoxContent(_currentPage);
        SetPageCaption(_currentPage);

        if (_currentPage == 0) _previousPage!.Enabled = false;
        else _nextPage!.Enabled = true;
    }

    private static void NextPage(Object? sender, EventArgs e)
    {
        if ((UInt32)_currentPage == 2) return;

        ++_currentPage;
        SetBoxContent(_currentPage);
        SetPageCaption(_currentPage);

        if ((UInt32)_currentPage == 2) _nextPage!.Enabled = false;
        else _previousPage!.Enabled = true;
    }
}