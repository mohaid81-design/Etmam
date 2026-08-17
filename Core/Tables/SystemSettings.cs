using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    [Table("SystemSettings")]
    public class SystemSettings
    {
        [Key]
        public int Id { get; set; }
        public string? SettingKey { get; set; }
        public string? SettingValue { get; set; }
        public string? Description { get; set; }
    }
}
