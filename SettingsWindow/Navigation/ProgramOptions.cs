using System.Windows.Forms;

internal static partial class Settings
{
    private static readonly CheckBox? _persistentSettings = new()
    {
        Text = "Persistent Settings",
        Location = new(11, 21),
        Checked = false,
        Width = 140,
        Height = 20,
        Font = new(MainWindow.FontFamily!, 9)
    };

    private static readonly CheckBox? _exactLength = new()
    {
        Text = "Exact Length",
        Location = new(11, 41),
        Checked = false,
        Enabled = false,
        Width = 140,
        Height = 20,
        Font = new(MainWindow.FontFamily!, 9)
    };

    /********************************************************************/

    private static void AddProgramOptions(Form mainForm)
    {
        GroupBox selector = new()
        {
            Text = "Program",
            Location = new(304, 329),
            Width = 156,
            Height = 98,
            Font = new(MainWindow.FontFamily!, 10)
        };
        mainForm.Controls.Add(selector);

        //

        _toolTip.SetToolTip(_persistentSettings!, "Remember selection across application starts.\nSaves on settings close.");
        selector.Controls.Add(_persistentSettings);

        _toolTip.SetToolTip(_exactLength!, "Applies the specified length to the output rather than the input.\nThis is only relevant for Base64 encoding, due to the overhead.");
        selector.Controls.Add(_exactLength);

        ComboBox comboBox = new()
        {
            Height = 32,
            Width = 128,
            FlatStyle = FlatStyle.System,
            Font = new(MainWindow.FontFamily!, 9),
            Location = new(11, 63),
            Enabled = false,
        };
        comboBox.Items.Add("Windows-1252");
        comboBox.SelectedIndex = 0;

        selector.Controls.Add(comboBox);
    }
}