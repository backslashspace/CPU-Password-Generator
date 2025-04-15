using System;
using System.Drawing;
using System.Windows.Forms;

internal static partial class MainWindow
{
    private static readonly TextBox _output = new()
    {
        Width = 440,
        Height = 24,
        ReadOnly = true,
        BorderStyle = BorderStyle.Fixed3D,
        Location = new(22, 28),
    };

    private static readonly Label _counter = new()
    {
        Tag = 0ul,
        ForeColor = Color.Green,
        Width = 120,
        Height = 24,
        Text = "0",
        Location = new(3, 3),
    };

    internal static readonly TextBox Length = new()
    {
        Text = "16",
        ForeColor = Color.Black,
        Tag = new Tuple<Boolean, UInt16>(true, 16),
        Width = 56,
        Height = 24,
        ScrollBars = ScrollBars.None,
        BorderStyle = BorderStyle.Fixed3D,
        Location = new(220, 78),
    };

    private static readonly Button _generateButton = new()
    {
        Text = "Generate",
        UseVisualStyleBackColor = true,
        FlatStyle = FlatStyle.System,
        Location = new(391, 74),
        Height = 32,
        Width = 72,
    };

    private static readonly Button _copyButton = new()
    {
        Text = "", // copy icon
        Enabled = false,
        UseVisualStyleBackColor = true,
        Font = new("Segoe Fluent Icons", 10),
        FlatStyle = FlatStyle.System,
        Location = new(360, 76),
        Height = 28,
        Width = 26,
    };

    /********************************************************************/

    private static void AddControls(Form mainForm)
    {
        mainForm.Controls.Add(_counter);

        _output.Font = new(FontFamily!, 10);
        mainForm.Controls.Add(_output);

        _copyButton.Click += CopyToClipBoard;
        mainForm.Controls.Add(_copyButton);

        Length.Font = new(FontFamily!, 10);
        Length.TextChanged += LengthLabel_TextChanged;
        mainForm.Controls.Add(Length);

        _generateButton.Font = new(FontFamily!, 10);
        _generateButton.Click += Generate;
        mainForm.Controls.Add(_generateButton);

        Button settingsButton = new()
        {
            Text = "Settings",
            UseVisualStyleBackColor = true,
            FlatStyle = FlatStyle.System,
            Location = new(22, 74),
            Font = new(FontFamily!, 10),
            Height = 32,
            Width = 110,
        };
        settingsButton.Click += ShowSettings;
        mainForm.Controls.Add(settingsButton);

        Label lengthLabel = new()
        {
            Width = 56,
            Height = 24,
            Text = "Length:",
            Location = new(165, 81),
            Font = new(FontFamily!, 10)
        };
        mainForm.Controls.Add(lengthLabel);
    }
}