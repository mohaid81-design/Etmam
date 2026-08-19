using Data;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class ucDrawingsMgt : DevExpress.XtraEditors.XtraUserControl
    {
        private int _Status = 0;
        private readonly ucDrawingsLog _ucDrawingsLog;
        private readonly ucDrawingsDahboard _ucDrawingsDahboard;

        public ucDrawingsMgt()
        {
            _ucDrawingsLog = new ucDrawingsLog();
            _ucDrawingsDahboard = new ucDrawingsDahboard();

            InitializeComponent();
        }

        private void MainDrawingsControl_Load(object sender, EventArgs e)
        {
            // تضمين لوحة التحكم في الصفحة الأولى
            EmbedControl(navigationPage1, _ucDrawingsDahboard);

            // تضمين سجل المخططات في الصفحة الثانية
            EmbedControl(navigationPage2, _ucDrawingsLog);

            // عرض الصفحة الأولى (لوحة التحكم) عند الفتح
            navigationFrameMain.SelectedPage = navigationPage1;
            _Status = 0;
            simpleButtonMain.Text = "فتح سجل المخططات";

            _ucDrawingsDahboard.LoadDashboardData();
        }

        private void simpleButtonMain_Click(object sender, EventArgs e)
        {
            if (_Status == 0)
            {
                // الانتقال من لوحة التحكم إلى سجل المخططات
                simpleButtonMain.Text = "عودة الى لوحة التحكم في المخططات";
                navigationFrameMain.SelectedPage = navigationPage2;
                _Status = 1;
                simpleButtonMain.ImageOptions.ImageIndex = 0;
                _ucDrawingsLog.LoadData();
            }
            else
            {
                // العودة إلى لوحة التحكم
                simpleButtonMain.Text = "فتح سجل المخططات";
                navigationFrameMain.SelectedPage = navigationPage1;
                _Status = 0;
                simpleButtonMain.ImageOptions.ImageIndex = 1;
                _ucDrawingsDahboard.LoadDashboardData();
            }
        }

        /// <summary>
        /// يضمّن عنصر تحكم داخل صفحة التنقل مع التأكد من عدم التكرار.
        /// </summary>
        private static void EmbedControl(NavigationPage page, UserControl control)
        {
            if (page.Controls.Contains(control)) return;
            control.Dock = DockStyle.Fill;
            page.Controls.Add(control);
        }

        private void simpleButtonNew_Click(object sender, EventArgs e)
        {
            if (!PermissionService.HasPermission(PermNames.DrawingsApprovalRequest))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("ليس لديك صلاحية إدارة طلبات اعتماد المخططات.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmDrawingsAddEdit form;
            try { form = new frmDrawingsAddEdit(); }
            finally { CloseOverlay(handle); }

            using (form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _ucDrawingsLog.LoadData();
                }
            }
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
