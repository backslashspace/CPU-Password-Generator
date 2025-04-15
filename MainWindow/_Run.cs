using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

internal static partial class MainWindow
{
    [LibraryImport("user32.dll", SetLastError = false)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial Boolean SetProcessDPIAware();

    /********************************************************************/

    internal static FontFamily? FontFamily;

    /********************************************************************/

    internal unsafe static void Run()
    {
        SetProcessDPIAware();

        Form mainForm = new()
        {
            AutoScaleMode = AutoScaleMode.Dpi,
            Text = "CPU Password Generator",
            Width = 500,
            Height = 166,
            StartPosition = FormStartPosition.CenterScreen,
            AllowTransparency = false,
            MaximizeBox = false,
            FormBorderStyle = FormBorderStyle.FixedSingle,
            ShowInTaskbar = true,
            Icon = Resources.MainIcon,
            HelpButton = false,
        };

        FontFamily = mainForm.Font.FontFamily;

        AddControls(mainForm);
        
        if (!Settings.Initialized)
        {
            MessageBox.Show("Failed to initialize Settings", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DwmInterop.SetTheme(mainForm.Handle, true);
        Application.Run(mainForm);
    }
}