using System;
using System.Windows.Forms;
using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Navigation;

namespace Etmam
{
    /// <summary>
    /// إضافة أو تعديل نشاط في قائمة ActivityList.
    /// يتم تحميل navigationFrame1 بـ ucActivity و navigationFrame2 بـ ucSchedule.
    /// </summary>
    public partial class frmActivityAddEdit : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        private ActivityList _activity;
        private bool         _isNew;

        // ── Constructors ─────────────────────────────────────────────────

        public frmActivityAddEdit(string defaultCategory = "")
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _activity = new ActivityList { Category = defaultCategory };
            _isNew    = true;
            Setup();
        }

        public frmActivityAddEdit(ActivityList activity)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _activity = activity;
            _isNew    = false;
            Setup();
        }

        private void Setup()
        {
            this.KeyPreview = true;
            this.Load += FrmActivityAddEdit_Load;
        }

        private void FrmActivityAddEdit_Load(object sender, EventArgs e)
        {
            LoadNavigationFrames();
        }

        private void LoadNavigationFrames()
        {
            // تحميل ucActivity في navigationFrame1
            var ucAct = new ucActivity
            {
                Dock = DockStyle.Fill,
                FilterCategory = _activity.Category // توريث التصنيف من الشاشة الأب
            };
            ucAct.LoadData(); // تحميل الأنشطة المصفاة
            
            var page1 = new NavigationPage();
            page1.Controls.Add(ucAct);
            navigationFrame1.Pages.Add(page1);
            navigationFrame1.SelectedPage = page1;

            // تحميل ucSchedule في navigationFrame2
            var ucSch = new ucSchedule
            {
                Dock = DockStyle.Fill
            };
            ucSch.LoadData();
            ucSch.OnLinkCreated += (s, ev) => ucAct.LoadData();
            
            var page2 = new NavigationPage();
            page2.Controls.Add(ucSch);
            navigationFrame2.Pages.Add(page2);
            navigationFrame2.SelectedPage = page2;
        }
    }
}
