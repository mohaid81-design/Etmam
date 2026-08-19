using Core;

namespace Data
{
    /// <summary>Toggleable (default OFF — see Etmam.SettingsForm) rule preventing a user from
    /// approving or rejecting a Purchase Request/Purchase Order they created themselves. Lives in the Data
    /// project (not Etmam) so both workflow sync classes can call it directly — checked at the actual
    /// approval choke points: frmPurchaseOrderAddEdit.ActOnWorkflowStep, frmPurchaseRequestAddEdit's
    /// equivalent, and the shared ucMyWorkflowTasks call sites.</summary>
    public static class SeparationOfDutiesHelper
    {
        public const string SettingKey = "EnforceApprovalSeparationOfDuties";

        public static bool IsEnabled(DataContext dc) =>
            SystemSettingsHelper.GetBool(dc, SettingKey, defaultValue: false);

        /// <summary>True if the setting is on, the current user isn't the superuser, and they created the
        /// record (<paramref name="createdBy"/>) they're trying to approve/reject.</summary>
        public static bool BlocksSelfApproval(DataContext dc, int createdBy)
        {
            if (Session.CurrentUser?.Id == 1) return false;
            if (createdBy <= 0) return false;
            if (!IsEnabled(dc)) return false;
            return createdBy == (Session.CurrentUser?.Id ?? -1);
        }

        public const string SelfApprovalMessage =
            "لا يمكنك اعتماد أو رفض مستند أنشأته بنفسك — خاصية فصل المهام مفعّلة من إعدادات النظام.";
    }
}
