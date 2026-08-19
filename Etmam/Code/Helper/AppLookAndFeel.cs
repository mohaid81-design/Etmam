using System.IO;
using System.Reflection;
using DevExpress.LookAndFeel.Design;

namespace Etmam
{
    /// <summary>
    /// The DevExpress skin/palette/font (skin "The Bezier", the custom "Custom Palette #2",
    /// default font "Cairo;8.25") is normally applied automatically by DevExpress at startup
    /// by reading the DevExpress.LookAndFeel.Design.AppSettings section from App.config.
    /// That resolution is file-based (Etmam.dll.config next to the assembly) and doesn't
    /// reliably work once the app is published as a single-file EXE, so we build the same
    /// settings in code from embedded resources and apply them directly instead.
    /// </summary>
    internal static class AppLookAndFeel
    {
        private const string CustomPalettesResourceName = "Etmam.Resources.LookAndFeel.CustomPalettes.xml";

        public static void Apply()
        {
            var settings = new NETCoreAppSettings
            {
                DefaultAppSkin = "Skin/The Bezier",
                DefaultPalette = "Custom/Custom Palette #2",
                DefaultAppFont = "Cairo;8.25",
            };

            string? customPalettesXml = ReadEmbeddedText(CustomPalettesResourceName);
            if (customPalettesXml != null)
                settings.CustomPalettes = new NETCoreAppSettingsCustomPalettes(customPalettesXml);

            ApplicationSettingsHelper.LoadSettings(settings, false, null, null);
        }

        private static string? ReadEmbeddedText(string resourceName)
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            if (stream == null)
                return null;

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
