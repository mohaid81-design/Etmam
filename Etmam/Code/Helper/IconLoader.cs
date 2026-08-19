using System.IO;
using System.Reflection;
using DevExpress.Utils.Svg;

namespace Etmam
{
    /// <summary>
    /// Loads placeholder SVG icons embedded from Assets/Icons (see Etmam.csproj) for use in
    /// each screen's SvgImageCollection. File name (with extension) is the resource key.
    /// </summary>
    internal static class IconLoader
    {
        public static SvgImage Get(string fileName)
        {
            string resourceName = $"Etmam.Assets.Icons.{fileName}";
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)
                ?? throw new FileNotFoundException($"Embedded icon not found: {resourceName}");
            return SvgImage.FromStream(stream);
        }
    }
}
