using System;
using System.Windows.Forms;

internal static partial class Settings
{
    private static readonly RadioButton? _encoding_raw = new()
    {
        Text = "Raw",
        Checked = true,
        Location = new(11, 20),
        Width = 72,
        Height = 20,
        Tag = false,
        Font = new(MainWindow.FontFamily!, 9),
    };

    private static readonly RadioButton? _encoding_base64 = new()
    {
        Text = "Base64",
        Location = new(11, 40),
        Width = 72,
        Height = 20,
        Font = new(MainWindow.FontFamily!, 9),
    };

    private static readonly CheckBox? _encoding_base64_trim = new()
    {
        Text = "Trim",
        Location = new(11, 60),
        Enabled = false,
        Checked = true,
        Width = 72,
        Height = 20,
        Font = new(MainWindow.FontFamily!, 9)
    };

    // # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

    private static void AddEncodingOptions(Form mainForm)
    {
        GroupBox encoding = new()
        {
            Text = "Output",
            Location = new(470, 329),
            Width = 110,
            Height = 98,
            Font = new(MainWindow.FontFamily!, 10)
        };
        mainForm.Controls.Add(encoding);

        //

        _toolTip.SetToolTip(_encoding_raw!, "Maps the random output 1:1 to text.\n" +
            "This might produce unreadable / invisible text when used with nonprintable characters, for that you can use Base64.\n" +
            "Keep in mind that Base64 has an overhead of 33–37%.");
        _encoding_raw!.CheckedChanged += Encoding_Raw_CheckedChanged;
        encoding.Controls.Add(_encoding_raw);

        _toolTip.SetToolTip(_encoding_base64!, "Creates a Base64 view of the random bytes.\n" +
            "Keep in mind that Base64 has an overhead of 33–37%,\n" +
            "this means the output will be 33–37% longer for the same amount of random bytes.\n\n" +
            "Length is applied before Base64 encoding, you can use the 'Exact Length' option to cut the\n" +
            "output after the specified length.");
        encoding.Controls.Add(_encoding_base64);

        _toolTip.SetToolTip(_encoding_base64_trim!, "Removes the padding, if present.");
        encoding.Controls.Add(_encoding_base64_trim);
    }

    // # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #
    private static void Encoding_Raw_CheckedChanged(Object? sender, EventArgs e)
    {
        _encoding_raw!.Tag = true;

        if (_encoding_raw!.Checked)
        {
            _encoding_base64_trim!.Enabled = false;
            _exactLength!.Enabled = false;
        }
        else
        {
            _encoding_base64_trim!.Enabled = true;
            _exactLength!.Enabled = true;
        }
    }
}