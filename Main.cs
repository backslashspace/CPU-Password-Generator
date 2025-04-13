using System;
using BSS.Random;
using System.Windows.Forms;
using System.Runtime.InteropServices;

internal static partial class Program
{
    [STAThread]
    private static void Main()
    {
        ComWrappers.RegisterForMarshalling(WinFormsComInterop.WinFormsComWrappers.Instance);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        if (!Resources.Initialized)
        {
            MessageBox.Show("Failed to initialize resources", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!DwmInterop.Initialize())
        {
            MessageBox.Show("Failed to initialize DwmInterop", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!HandleNativeDll()) return;

        if (HWRandom.GetSupportedInstructions() != HWRandom.SupportedInstructions.All)
        {
            MessageBox.Show("RDSEED and or RDRAND not supported!", "Environment Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        MainWindow.Run();
    }
}