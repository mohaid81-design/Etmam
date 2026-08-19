using System;
using System.ComponentModel;
using DevExpress.XtraEditors;
using Microsoft.Data.SqlClient;
using Data;

namespace Etmam
{
    /// <summary>
    /// Base class for all UserControls to provide consistent context and access to shared services.
    /// </summary>
    public class BaseUserControl : XtraUserControl
    {
        /// <summary>
        /// Central data context for the application.
        /// </summary>
        protected DataContext DC => Data.DataContext.Shared;

        /// <summary>
        /// Triggered when data is modified within the control.
        /// </summary>
        public event Action? DataChanged;

        /// <summary>
        /// Helper to safely invoke the DataChanged event.
        /// </summary>
        protected virtual void OnDataChanged() => DataChanged?.Invoke();

        // ─── Shared State ──────────────────────────────────────────────────
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentDailyReportId { get; protected set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentProjectId { get; protected set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime CurrentReportDate { get; protected set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool _isInitialized = false;

        /// <summary>
        /// Common initialization method to be called by parent forms.
        /// </summary>
        public virtual void Initialize(int dailyReportId, int projectId, DateTime reportDate)
        {
            CurrentDailyReportId = dailyReportId;
            CurrentProjectId     = projectId;
            CurrentReportDate    = reportDate;
            
            OnInitialized();
        }

        /// <summary>
        /// Override to perform logic after properties are set.
        /// </summary>
        protected virtual void OnInitialized() { }

        /// <summary>
        /// Standard entry point for copying data from a previous report.
        /// Returns the number of records added.
        /// </summary>
        public virtual int CopyFromPrevious(int lastReportId) => 0;

        /// <summary>
        /// Standard entry point for saving data. An optional transaction lets the parent form
        /// (frmDailyReport) wrap the header save and every sub-control's save in one
        /// connection/transaction instead of each opening its own.
        /// </summary>
        public virtual void SaveData(int dailyReportId, SqlTransaction? transaction = null) { }

        /// <summary>
        /// Standard entry point for loading data.
        /// </summary>
        public virtual void LoadData() { }

        /// <summary>
        /// Called when the global SelectedProjectId changes in the Session.
        /// Override this to refresh control data based on the new project context.
        /// </summary>
        public virtual void OnProjectChanged() 
        {
            // Update the local tracker if applicable
            if (Core.Session.SelectedProjectId.HasValue)
            {
                CurrentProjectId = Core.Session.SelectedProjectId.Value;
            }
        }
    }
}

