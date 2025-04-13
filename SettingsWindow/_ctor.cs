using System;

internal static partial class Settings
{
    internal static Boolean Initialized { get => _initialized; }
    internal static Boolean _initialized = false;

    static Settings()
    {
        for (Int32 i = 0; i < 256; ++i)
        {
            CheckBoxes[i] = new()
            {
                Width = 56,
                UseMnemonic = false,
                Tag = i,
                Text = Characters[i, 0],
                Font = new(MainWindow.FontFamily!, 9)
            };
            CheckBoxes[i].CheckedChanged += CheckBoxChanged;

            if (Characters[i, 1] != null)
            {
                _toolTip.SetToolTip(CheckBoxes[i], Characters[i, 1]);
            }
        }

        //

        AddPageNavigation(_mainForm);
        AddCharSelection(_mainForm);

        CheckAndLoadPersistentSettings();

        _mainForm.FormClosing += FormClosing;

        _initialized = true;
    }
}