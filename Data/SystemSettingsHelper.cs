using System.Linq;
using Core;

namespace Data
{
    /// <summary>Generic key/value read-modify-write helper over the (until now unused outside
    /// DatabaseInitializer's own "SchemaHash" bookkeeping) SystemSettings table, so feature toggles like
    /// separation-of-duties enforcement don't need their own bespoke table.</summary>
    public static class SystemSettingsHelper
    {
        public static bool GetBool(DataContext dc, string key, bool defaultValue)
        {
            var row = dc.SystemSettings.GetBy("SettingKey = @k", new { k = key }).FirstOrDefault();
            if (row?.SettingValue == null) return defaultValue;
            return row.SettingValue == "1";
        }

        public static void SetBool(DataContext dc, string key, bool value, string? description = null)
        {
            SetString(dc, key, value ? "1" : "0", description);
        }

        public static string? GetString(DataContext dc, string key, string? defaultValue = null)
        {
            var row = dc.SystemSettings.GetBy("SettingKey = @k", new { k = key }).FirstOrDefault();
            return row?.SettingValue ?? defaultValue;
        }

        public static void SetString(DataContext dc, string key, string? value, string? description = null)
        {
            var row = dc.SystemSettings.GetBy("SettingKey = @k", new { k = key }).FirstOrDefault();

            if (row != null)
            {
                row.SettingValue = value;
                if (description != null) row.Description = description;
                dc.SystemSettings.Edit(row.Id, row);
            }
            else
            {
                dc.SystemSettings.Add(new SystemSettings
                {
                    SettingKey = key,
                    SettingValue = value,
                    Description = description
                });
            }
        }
    }
}
