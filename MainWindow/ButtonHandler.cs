using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

internal static partial class MainWindow
{
    private static String? _generatorOutput;

    // # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

    private static void Generate(Object? sender, EventArgs e)
    {
        Tuple<Boolean, UInt16> lengthTuple = (Tuple<Boolean, UInt16>)Length!.Tag!;
        Boolean isValid = lengthTuple.Item1;
        UInt16 length = lengthTuple.Item2;

        if (length == 0) return;

        if (!isValid)
        {
            MessageBox.Show("Invalid Input", "Only numbers (UInt16) are allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        //

        UInt64 counter = (UInt64)_counter!.Tag!;
        ++counter;
        _counter.Tag = counter;
        _counter.Text = counter.ToString();

        //

        _generatorOutput = Generator.Generate(length);
        if (_generatorOutput == null) return;

        if (_generatorOutput!.Length > 1024)
        {
            _output!.ForeColor = Color.OrangeRed;
            _output!.BackColor = _output!.BackColor; // required to set ForeColor
            _output!.Text = "Output is longer than 1024 chars, use copy button";
        }
        else
        {
            _output!.ForeColor = Color.Black;
            _output!.Text = _generatorOutput;
        }

        _copyButton!.Enabled = true;
    }

    private static void CopyToClipBoard(Object? sender, EventArgs e)
    {
        if (_generatorOutput == null) return;
        Clipboard.SetText(_generatorOutput!);
    }

    private static void ShowSettings(Object? sender, EventArgs e) => Settings.Show();

    private static void LengthLabel_TextChanged(Object? sender, EventArgs e)
    {
        if (UInt16.TryParse(Length!.Text, out UInt16 number))
        {
            Length.ForeColor = Color.Black;
            Length.Tag = new Tuple<Boolean, UInt16>(true, number);
            _generateButton!.Enabled = true;

            if (Settings.PersistentSettings) Settings.ExternalSetLength(number);
        }
        else
        {
            Length.ForeColor = Color.Red;
            Length.Tag = new Tuple<Boolean, UInt16>(false, 0);
            _generateButton!.Enabled = false;
        }
    }
}