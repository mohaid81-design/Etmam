namespace Etmam
{
    public partial class ucDocumentsMgt : BaseUserControl
    {

        private Dictionary<string, DevExpress.XtraBars.Navigation.NavigationPage> _pages = new Dictionary<string, DevExpress.XtraBars.Navigation.NavigationPage>();
        private bool _isSyncing = false;

        public ucDocumentsMgt()
        {
            InitializeComponent();
            this.Load += UcDocumentsMgt_Load;
            
            // Register click events
            this.nbDailyReport.ElementClick += (s, e) => ShowPage("DailyReport", nbDailyReport);
            this.nbCIR.ElementClick += (s, e) => ShowPage("CIR", nbCIR);
            this.nbMAR.ElementClick += (s, e) => ShowPage("MAR", nbMAR);
            this.nbMIR.ElementClick += (s, e) => ShowPage("MIR", nbMIR);
            this.nvDwgAR.ElementClick += (s, e) => ShowPage("Drawings", nvDwgAR);
            this.nbTransmittals.ElementClick += (s, e) => ShowPage("Transmittals", nbTransmittals);
            this.nbDashboard.ElementClick += (s, e) => ShowPage("Dashboard", nbDashboard);
        }

        private void UcDocumentsMgt_Load(object? sender, EventArgs e)
        {
            ShowPage("DailyReport", nbDailyReport);
        }

        private void ShowPage(string moduleName, DevExpress.XtraBars.Navigation.NavButton senderButton)
        {
            if (_isSyncing) return;
            _isSyncing = true;
            try
            {
                // Manual highlighting of the selected button
                foreach (DevExpress.XtraBars.Navigation.NavButton button in tileNavPane1.Buttons)
                {
                    if (button == nbTitle) continue; // Skip branding title

                    if (button == senderButton)
                    {
                        button.Appearance.BackColor = Color.White;
                        button.Appearance.ForeColor = Color.FromArgb(13, 131, 135);
                        button.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        button.Appearance.Options.UseBackColor = true;
                        button.Appearance.Options.UseForeColor = true;
                        button.Appearance.Options.UseFont = true;
                    }
                    else
                    {
                        button.Appearance.Options.UseBackColor = false;
                        button.Appearance.Options.UseForeColor = false;
                        button.Appearance.Options.UseFont = false;
                    }
                }

                if (!_pages.ContainsKey(moduleName))
                {
                    var page = new DevExpress.XtraBars.Navigation.NavigationPage();
                    UserControl? control = CreateModule(moduleName);
                    if (control != null)
                    {
                        control.Dock = DockStyle.Fill;
                        page.Controls.Add(control);
                        page.Name = "page" + moduleName;
                        navigationFrame1.Pages.Add(page);
                        _pages.Add(moduleName, page);
                    }
                }

                if (_pages.ContainsKey(moduleName))
                {
                    navigationFrame1.SelectedPage = _pages[moduleName];
                }
            }
            finally
            {
                _isSyncing = false;
            }
        }

        private UserControl? CreateModule(string name)
        {
            try
            {
                switch (name)
                {
                    case "DailyReport": return new ucDailyReports();
                    case "Dashboard":   return new ucDashboard();
                    case "Drawings":    return new ucDwgMgt();
                    case "MAR":         return new ucMAR();
                    case "MIR":         return new ucMIR();
                    case "CIR":         return new ucCIR();
                    case "Transmittals": return new ucTransmittalsMgt();
                    default:            return null;
                }
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show($"عذراً، حدث خطأ أثناء تحميل الشاشة: {name}\n{ex.Message}", "خطأ في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public override void OnProjectChanged()
        {
            base.OnProjectChanged();
            
            // Propagate to all initialized pages within this module
            foreach (var page in _pages.Values)
            {
                foreach (Control ctrl in page.Controls)
                {
                    if (ctrl is BaseUserControl baseCtrl)
                    {
                        baseCtrl.OnProjectChanged();
                    }
                }
            }
        }
    }
}
