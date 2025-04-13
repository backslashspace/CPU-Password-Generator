using System;
using System.IO;
using System.Windows.Forms;

internal static partial class Program
{
    private static Boolean HandleNativeDll()
    {
        try
        {
            String file = AppContext.BaseDirectory + "native.dll";

            Int32 length = Resources.NativeDLL.Length;

            if (!File.Exists(file)) return WriteNativeDll(file, Resources.NativeDLL, length);

            //

            Span<Byte> buffer = stackalloc Byte[length];
            FileStream fileStream = new(file, FileMode.Open, FileAccess.Read, FileShare.Read, length, FileOptions.WriteThrough);

            if (fileStream.Length != length)
            {
                fileStream.Close();
                return WriteNativeDll(file, Resources.NativeDLL, length);
            }

            fileStream.ReadExactly(buffer);
            fileStream.Close();

            Boolean isValid = true;
            for (Int32 i = 0; i < length; ++i)
            {
                if (buffer[i] != Resources.NativeDLL[i])
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid) return true;

            return WriteNativeDll(file, Resources.NativeDLL, length);
        }
        catch (Exception exception)
        {
            MessageBox.Show("Failed to verify native.dll:\n\n" + exception.Message, "Environment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    private static Boolean WriteNativeDll(String path, Byte[] nativeDll, Int32 length)
    {
        try
        {
            FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.Read, length, FileOptions.WriteThrough);
            fileStream.Write(nativeDll, 0, length);
            fileStream.Close();
            return true;
        }
        catch (Exception exception)
        {
            MessageBox.Show("Failed to write native.dll:\n\n" + exception.Message, "Environment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}