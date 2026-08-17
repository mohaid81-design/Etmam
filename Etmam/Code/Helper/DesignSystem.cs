using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System;

namespace Etmam
{
    /// <summary>
    /// Centralized Design System for Etmam project to ensure visual consistency.
    /// </summary>
    public static class DesignSystem
    {
        // ─── Colors ──────────────────────────────────────────────────────────
        public static class Colors
        {
            public static readonly Color Primary     = Color.FromArgb(30, 70, 130);   // Modern Blue
            public static readonly Color Secondary   = Color.FromArgb(70, 85, 100);   // Slate
            public static readonly Color Background  = Color.FromArgb(248, 249, 251); // Light Gray
            public static readonly Color Surface     = Color.White;
            public static readonly Color Border      = Color.FromArgb(220, 225, 232);
            public static readonly Color TextPrimary = Color.FromArgb(25, 25, 35);
            public static readonly Color Accent      = Color.FromArgb(0, 120, 215);
            
            // Category Accents (from ucWorkDoneToday)
            public static readonly Color CategoryStructural = Color.FromArgb(204, 102, 0);
            public static readonly Color CategoryArchitect   = Color.FromArgb(23, 96, 158);
            public static readonly Color CategoryMechanical  = Color.FromArgb(30, 140, 80);
            public static readonly Color CategoryElectrical  = Color.FromArgb(120, 50, 160);
            public static readonly Color CategoryOther       = Color.FromArgb(70, 85, 100);
        }

        // ─── Typography ──────────────────────────────────────────────────────
        public static class Fonts
        {
            private const string DefaultFontName = "Cairo";

            public static Font Regular(float size = 8.5F) => new Font(DefaultFontName, size, FontStyle.Regular);
            public static Font Bold(float size = 8F)    => new Font(DefaultFontName, size, FontStyle.Bold);
            public static Font Header(float size = 8.5F)  => new Font(DefaultFontName, size, FontStyle.Regular);
        }

        // ─── Grid Utilities ──────────────────────────────────────────────────
        public static void ApplyProfessionalStyle(GridView gv)
        {
            // Appearance
            gv.Appearance.HeaderPanel.Font = Fonts.Bold();
            gv.Appearance.HeaderPanel.ForeColor = Colors.Primary;
            gv.Appearance.HeaderPanel.Options.UseFont = true;
            gv.Appearance.HeaderPanel.Options.UseForeColor = true;
            gv.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

            gv.Appearance.Row.Font = Fonts.Regular(8.5F);
            gv.Appearance.Row.Options.UseFont = true;
            gv.Appearance.Row.ForeColor = Colors.TextPrimary;

            gv.Appearance.EvenRow.BackColor = Color.FromArgb(242, 246, 252);
            gv.Appearance.EvenRow.Options.UseBackColor = true;

            gv.Appearance.FocusedRow.BackColor = Colors.Primary;
            gv.Appearance.FocusedRow.ForeColor = Color.White;
            gv.Appearance.FocusedRow.Options.UseBackColor = true;
            gv.Appearance.FocusedRow.Options.UseForeColor = true;

            gv.Appearance.FocusedCell.BackColor = Color.FromArgb(50, 100, 170);
            gv.Appearance.FocusedCell.ForeColor = Color.White;
            gv.Appearance.FocusedCell.Options.UseBackColor = true;
            gv.Appearance.FocusedCell.Options.UseForeColor = true;

            // Options
            gv.OptionsView.EnableAppearanceEvenRow = true;
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsView.ShowIndicator = true;
            gv.OptionsView.ColumnAutoWidth = false;
            gv.OptionsView.RowAutoHeight = false;
            gv.RowHeight = 30;

            gv.OptionsNavigation.EnterMoveNextColumn = true;
            gv.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDownFocused;
            
            gv.OptionsSelection.MultiSelect = true;
            gv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            
            gv.OptionsClipboard.CopyColumnHeaders = DefaultBoolean.False;
        }

        public static void ApplyGridStyle(DevExpress.XtraGrid.GridControl gc, GridView gv)
        {
            ApplyProfessionalStyle(gv);
            gc.EmbeddedNavigator.Visible = false;
        }

        public static void SetColumnCentered(DevExpress.XtraGrid.Columns.GridColumn col)
        {
            if (col == null) return;
            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
        }

        public static void HideAuditColumns(GridView gv)
        {
            string[] auditCols = { 
                "Id", "CreatedBy", "CreatedDate", "CreatedMachine", 
                "UpdateBy", "UpdateDate", "UpdateMachine", 
                "IsDelete", "DeletionBy", "DeletionDate", "DeletionMachine",
                "DailyReportId" // Usually FKs are hidden too
            };
            
            foreach (var colName in auditCols)
            {
                var col = gv.Columns[colName];
                if (col != null) col.Visible = false;
            }
        }

        /// <summary>
        /// Applies professional color coding to status columns, inspired by Aconex.
        /// </summary>
        public static void ApplyStatusColoring(GridView gv, string statusColumnName)
        {
            gv.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName == statusColumnName)
                {
                    string status = e.CellValue?.ToString() ?? "";
                    Color backColor = Color.Transparent;
                    Color foreColor = Color.White;

                    // Support both Arabic and English statuses
                    if (status.Contains("Approved") || status.Contains("معتمد") || status.Contains("ناجح"))
                    {
                        backColor = Color.FromArgb(46, 125, 50); // Deep Green
                    }
                    else if (status.Contains("Pending") || status.Contains("قيد") || status.Contains("Review") || status.Contains("مراجعة"))
                    {
                        backColor = Color.FromArgb(251, 192, 45); // Deep Amber
                        foreColor = Colors.TextPrimary;
                    }
                    else if (status.Contains("Rejected") || status.Contains("مرفوض") || status.Contains("فشل"))
                    {
                        backColor = Color.FromArgb(198, 40, 40); // Deep Red
                    }
                    else if (status.Contains("Comment") || status.Contains("ملاحظات") || status.Contains("تعديل"))
                    {
                        backColor = Color.FromArgb(21, 101, 192); // Blue
                    }

                    if (backColor != Color.Transparent)
                    {
                        e.Appearance.BackColor = backColor;
                        e.Appearance.ForeColor = foreColor;
                        e.Appearance.Font = Fonts.Bold(e.Appearance.Font.Size);
                        e.Appearance.Options.UseBackColor = true;
                        e.Appearance.Options.UseForeColor = true;
                        e.Appearance.Options.UseFont = true;
                    }
                }
            };
        }

        // ─── TreeList Utilities ──────────────────────────────────────────────
        
        /// <summary>
        /// Applies professional styling to a TreeList control.
        /// </summary>
        public static void ApplyTreeListStyle(DevExpress.XtraTreeList.TreeList tl)
        {
            tl.Appearance.HeaderPanel.Font = Fonts.Header();
            tl.Appearance.HeaderPanel.ForeColor = Colors.Primary;
            tl.Appearance.HeaderPanel.Options.UseFont = true;
            tl.Appearance.HeaderPanel.Options.UseForeColor = true;
            tl.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

            tl.Appearance.Row.Font = Fonts.Regular(8F);
            tl.Appearance.Row.Options.UseFont = true;
            tl.Appearance.Row.ForeColor = Colors.TextPrimary;

            tl.OptionsView.ShowIndicator = false;
            tl.OptionsView.AutoWidth = false;
            tl.OptionsBehavior.Editable = false;
            
            // Zebra striping
            tl.OptionsView.EnableAppearanceEvenRow = true;
            tl.Appearance.EvenRow.BackColor = Color.FromArgb(245, 247, 250);
            tl.Appearance.EvenRow.Options.UseBackColor = true;
            
            tl.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            tl.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
            
            // Focused Styling
            tl.Appearance.FocusedCell.BackColor = Colors.Primary;
            tl.Appearance.FocusedCell.ForeColor = Color.White;
            tl.Appearance.FocusedCell.Options.UseBackColor = true;
            tl.Appearance.FocusedCell.Options.UseForeColor = true;
            
            tl.Appearance.FocusedRow.BackColor = Colors.Primary;
            tl.Appearance.FocusedRow.ForeColor = Color.White;
            tl.Appearance.FocusedRow.Options.UseBackColor = true;
            tl.Appearance.FocusedRow.Options.UseForeColor = true;
        }

        public static void HideTreeListAuditColumns(DevExpress.XtraTreeList.TreeList tl)
        {
            string[] auditCols = { 
                "Id", "CreatedBy", "CreatedDate", "CreatedMachine", 
                "UpdateBy", "UpdateDate", "UpdateMachine", 
                "IsDelete", "DeletionBy", "DeletionDate", "DeletionMachine",
                "DailyReportId", "PrjId", "ScheduleId", "IdParent"
            };
            
            foreach (var colName in auditCols)
            {
                var col = tl.Columns[colName];
                if (col != null) col.Visible = false;
            }
        }

        /// <summary>
        /// Applies consistent styling to SimpleButtons.
        /// </summary>
        public static void ApplyButtonStyle(DevExpress.XtraEditors.SimpleButton button, bool isPrimary = false)
        {
            button.Appearance.Font = new Font("Cairo", 9, isPrimary ? FontStyle.Bold : FontStyle.Regular);
            if (isPrimary)
            {
                button.Appearance.ForeColor = Color.White;
                button.AllowFocus = false;
            }
        }

        // ─── TileBar Icon Recoloring ─────────────────────────────────────────
        // TileBar's own coloring knobs (AllowGlyphSkinning, SvgImageColorizationMode) only ever
        // produce two results in practice: the icon's original artwork, or a fixed color picked
        // by the active DevExpress skin — neither lets us force an arbitrary color like white.
        // So instead we clone each icon's SVG and rewrite every shape's fill/stroke directly.

        private static readonly System.Reflection.PropertyInfo SvgFillProp =
            typeof(DevExpress.Utils.Svg.SvgElement).GetProperty("Fill")!;
        private static readonly System.Reflection.PropertyInfo SvgStrokeProp =
            typeof(DevExpress.Utils.Svg.SvgElement).GetProperty("Stroke")!;

        /// <summary>
        /// Forces every tile's SVG icon in a TileBar to render as a single solid color,
        /// regardless of whether the icon was assigned directly (ImageOptions.SvgImage)
        /// or referenced by index into a shared SvgImageCollection.
        /// </summary>
        public static void RecolorTileBarIcons(DevExpress.XtraBars.Navigation.TileBar tileBar, Color color)
        {
            string hex = ColorTranslator.ToHtml(color);

            foreach (DevExpress.XtraBars.Navigation.TileBarGroup group in tileBar.Groups)
            {
                foreach (DevExpress.XtraBars.Navigation.TileBarItem item in group.Items)
                {
                    foreach (DevExpress.XtraEditors.TileItemElement el in item.Elements)
                    {
                        DevExpress.Utils.Svg.SvgImage? svg = null;
                        if (el.ImageOptions.HasSvgImage)
                        {
                            svg = el.ImageOptions.SvgImage;
                        }
                        else if (el.ImageOptions.ImageIndex >= 0
                            && el.ImageOptions.Images is DevExpress.Utils.SvgImageCollection svgCollection
                            && el.ImageOptions.ImageIndex < svgCollection.Count)
                        {
                            // Text-only elements (e.g. the "0" counter labels) never set ImageIndex,
                            // which defaults to -1 — indexing the collection with that crashes the
                            // whole control's constructor, so both conditions above must hold first.
                            svg = svgCollection[el.ImageOptions.ImageIndex];
                        }

                        if (svg == null) continue;

                        var recolored = svg.Clone();
                        RecolorSvgElements(recolored.Root.Elements, hex);
                        el.ImageOptions.SvgImage = recolored;
                    }
                }
            }
        }

        private static void RecolorSvgElements(System.Collections.Generic.IList<DevExpress.Utils.Svg.SvgElement> elements, string hex)
        {
            foreach (var el in elements)
            {
                if (!string.IsNullOrEmpty(el.Fill) && el.Fill != "none")
                    SvgFillProp.SetValue(el, hex);
                if (!string.IsNullOrEmpty(el.Stroke) && el.Stroke != "none")
                    SvgStrokeProp.SetValue(el, hex);

                RecolorSvgElements(el.Elements, hex);
            }
        }

        // ─── Form Branding ──────────────────────────────────────────────────
        public static void ApplyFormBranding(Form form)
        {
            form.Font = Fonts.Regular(9);
            ApplyCairoFontRecursively(form);
        }

        public static void ApplyCairoFont(Control control)
        {
            ApplyCairoFontRecursively(control);
        }

        private static void ApplyCairoFontRecursively(Control parent)
        {
            if (parent == null) return;
            
            // Set font if not already Cairo (optimization)
            if (parent.Font.Name != "Cairo")
            {
                parent.Font = Fonts.Regular(parent.Font.Size);
            }

            // Special handling for DevExpress editors
            if (parent is BaseEdit edit)
            {
                edit.Properties.Appearance.Font = Fonts.Regular(edit.Properties.Appearance.Font.Size);
                edit.Properties.Appearance.Options.UseFont = true;
            }

            foreach (Control ctrl in parent.Controls)
            {
                ApplyCairoFontRecursively(ctrl);
            }
        }
    }
}

