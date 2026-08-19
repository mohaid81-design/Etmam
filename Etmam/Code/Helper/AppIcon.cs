using System.Drawing;
using System.Windows.Forms;

namespace Etmam
{
    /// <summary>
    /// DevExpress forms (XtraForm/RibbonForm) don't inherit the executable's icon at runtime
    /// the way a plain Form title bar would, so each top-level form must set it explicitly.
    /// </summary>
    public static class AppIcon
    {
        public static Icon Default { get; } = Icon.ExtractAssociatedIcon(Application.ExecutablePath)!;
    }
}
