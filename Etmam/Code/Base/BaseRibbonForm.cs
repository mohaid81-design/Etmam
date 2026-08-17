using System;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using Data;

namespace Etmam
{
    /// <summary>
    /// Base class for forms using the DevExpress Ribbon control.
    /// Provides consistent branding and access to shared services.
    /// </summary>
    public class BaseRibbonForm : RibbonForm
    {
        /// <summary>
        /// Central data context for the application.
        /// </summary>
        protected Data.DataContext DC => Data.DataContext.Shared;

        public BaseRibbonForm()
        {
            this.Load += BaseRibbonForm_Load;
        }

        private void BaseRibbonForm_Load(object sender, EventArgs e)
        {
            DesignSystem.ApplyFormBranding(this);
            OnFormReady();
        }

        /// <summary>
        /// Override this method to perform initialization once the form is ready and branded.
        /// </summary>
        protected virtual void OnFormReady() { }

        /// <summary>
        /// Helper to show an overlay splash screen.
        /// </summary>
        protected DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle ShowOverlay()
        {
            return DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(this);
        }

        /// <summary>
        /// Helper to close an overlay splash screen.
        /// </summary>
        protected void CloseOverlay(DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(handle);
        }

        /// <summary>
        /// Executes an asynchronous task with an overlay splash screen.
        /// </summary>
        protected async System.Threading.Tasks.Task ExecuteAsync(System.Func<System.Threading.Tasks.Task> task)
        {
            var handle = ShowOverlay();
            try
            {
                await task();
            }
            finally
            {
                CloseOverlay(handle);
            }
        }
    }
}
