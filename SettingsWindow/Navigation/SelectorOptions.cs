using System.Windows.Forms;

internal static partial class Settings
{
    private static void AddSelectorOptions(Form mainForm)
    {
        GroupBox selector = new()
        {
            Location = new(20, 329),
            Width = 274,
            Height = 98,
            Font = new(MainWindow.FontFamily!, 10)
        };
        mainForm.Controls.Add(selector);

        //

        Button selectAllOnCurrentPage = new()
        {
            Text = "Select all",
            UseVisualStyleBackColor = true,
            FlatStyle = FlatStyle.System,
            Location = new(10, 19),
            Height = 32,
            Width = 122,
            Font = new(MainWindow.FontFamily!, 10),
        };
        _toolTip.SetToolTip(selectAllOnCurrentPage, "Select all on current page");
        selectAllOnCurrentPage.Click += (s, e) => SetCheckBoxStateForAllOnCurrentPage(true);
        selector.Controls.Add(selectAllOnCurrentPage);

        Button deselectAllOnCurrentPage = new()
        {
            Text = "Deselect all",
            UseVisualStyleBackColor = true,
            FlatStyle = FlatStyle.System,
            Location = new(10, 55),
            Height = 32,
            Width = 122,
            Font = new(MainWindow.FontFamily!, 10),
        };
        _toolTip.SetToolTip(deselectAllOnCurrentPage, "Deselect all on current page");
        deselectAllOnCurrentPage.Click += (s, e) => SetCheckBoxStateForAllOnCurrentPage(false);
        selector.Controls.Add(deselectAllOnCurrentPage);

        //

        Button reloadSettings = new()
        {
            Text = "Reload Settings",
            UseVisualStyleBackColor = true,
            FlatStyle = FlatStyle.System,
            Enabled = true,
            Location = new(136, 19),
            Height = 32,
            Width = 128,
            Font = new(MainWindow.FontFamily!, 10),
        };
        reloadSettings.Click += (s, e) => CheckAndLoadPersistentSettings();
        selector.Controls.Add(reloadSettings);

        Button setDefaultSelection = new()
        {
            Text = "Set to Defaults",
            UseVisualStyleBackColor = true,
            FlatStyle = FlatStyle.System,
            Location = new(136, 55),
            Height = 32,
            Width = 128,
            Font = new(MainWindow.FontFamily!, 10),
        };
        setDefaultSelection.Click += (s, e) => SetDefaultSelection(true);
        selector.Controls.Add(setDefaultSelection);
    }
}