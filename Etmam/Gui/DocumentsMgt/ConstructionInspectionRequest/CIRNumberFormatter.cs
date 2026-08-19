using Core;

namespace Etmam
{
    /// <summary>Formats a Construction Inspection Request's reference code as
    /// "CIR-{Discipline}-{SecondaryDiscipline}-{Num:D3}-R{Rev}" (e.g. "CIR-ST-FND-001-R0"), or
    /// without the secondary segment when the record has none (e.g. "CIR-ST-001-R0") — shared
    /// wherever the request number is shown to a user (ucCIR's grid, frmCIRAddEdit's title),
    /// independent of the raw stored Num/Rev values used for numbering/saving logic. Note: Num
    /// itself is sequential per (Project, Discipline) only — the secondary discipline is purely a
    /// display segment and does not get its own sub-sequence (see CIRReissuer / GenerateNextNum).</summary>
    public static class CIRNumberFormatter
    {
        public static string Format(ConstructionInspectionRequestList? record) =>
            record == null ? "" : Format(record.Num, record.DisciplineCode, record.SecondaryDisciplineCode, record.Rev);

        public static string Format(int? num, string? discipline, string? secondaryDiscipline, int? rev)
        {
            var parts = new System.Collections.Generic.List<string> { "CIR", discipline ?? "-" };
            if (!string.IsNullOrEmpty(secondaryDiscipline))
                parts.Add(secondaryDiscipline);
            parts.Add(num?.ToString("D3") ?? "---");
            return string.Join("-", parts) + $"-R{rev ?? 0}";
        }
    }
}
