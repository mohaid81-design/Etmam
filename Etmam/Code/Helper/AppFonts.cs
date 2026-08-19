using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Etmam
{
    /// <summary>
    /// Forms across the app reference the "Cairo" font by name (new Font("Cairo", ...)).
    /// That only resolves if Cairo is installed on the machine. Registering the embedded
    /// ttf with GDI via AddFontMemResourceEx makes it resolvable by name for this process
    /// only, so the app renders correctly on machines without Cairo installed.
    /// </summary>
    internal static class AppFonts
    {
        private const string ResourceName = "Etmam.Resources.Fonts.Cairo-VariableFont.ttf";

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, ref uint pcFonts);

        public static void RegisterEmbeddedFonts()
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName);
            if (stream == null)
                return;

            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            byte[] fontData = memoryStream.ToArray();

            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            try
            {
                Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                uint fontCount = 0;
                AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref fontCount);
            }
            finally
            {
                Marshal.FreeCoTaskMem(fontPtr);
            }
        }
    }
}
