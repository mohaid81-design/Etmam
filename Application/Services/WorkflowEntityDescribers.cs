using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>Mirrors Etmam/Program.cs's PurchaseRequestList registration - same fields
    /// (FormattedNum-equivalent, Purpose), simplified the same "not a pixel-match" way
    /// PurchaseRequestsService.ToDtoAsync's own FormattedNum already is (no PurchaseRequestPrinter
    /// dependency reachable from here).</summary>
    public sealed class PurchaseRequestEntityDescriber : IWorkflowEntityDescriber
    {
        public string EntityName => "PurchaseRequestList";

        private readonly IApplicationDbContext _db;
        public PurchaseRequestEntityDescriber(IApplicationDbContext db) => _db = db;

        public async Task<(string Number, string Subject)> DescribeAsync(int entityRecordId, CancellationToken ct = default)
        {
            var pr = await _db.PurchaseRequestList.FirstOrDefaultAsync(p => p.Id == entityRecordId, ct);
            if (pr is null) return (entityRecordId.ToString(), "");
            var number = pr.Num is int n ? $"{n}/{pr.RequestDate?.Year}" : entityRecordId.ToString();
            return (number, pr.Purpose ?? "");
        }
    }

    /// <summary>Mirrors Etmam/Program.cs's PurchaseOrderList registration (Number/Description).</summary>
    public sealed class PurchaseOrderEntityDescriber : IWorkflowEntityDescriber
    {
        public string EntityName => "PurchaseOrderList";

        private readonly IApplicationDbContext _db;
        public PurchaseOrderEntityDescriber(IApplicationDbContext db) => _db = db;

        public async Task<(string Number, string Subject)> DescribeAsync(int entityRecordId, CancellationToken ct = default)
        {
            var po = await _db.PurchaseOrderList.FirstOrDefaultAsync(p => p.Id == entityRecordId, ct);
            if (po is null) return (entityRecordId.ToString(), "");
            var number = po.Num is int n ? $"{n}/{po.OrderDate?.Year}" : entityRecordId.ToString();
            return (number, po.Description ?? "");
        }
    }

    /// <summary>Mirrors Etmam/Program.cs's ConstructionInspectionRequestList registration
    /// (CIRNumberFormatter output/Description) - same RegisterNo-first fallback already used by
    /// ConstructionInspectionRequestsService's own FormattedNum.</summary>
    public sealed class ConstructionInspectionRequestEntityDescriber : IWorkflowEntityDescriber
    {
        public string EntityName => "ConstructionInspectionRequestList";

        private readonly IApplicationDbContext _db;
        public ConstructionInspectionRequestEntityDescriber(IApplicationDbContext db) => _db = db;

        public async Task<(string Number, string Subject)> DescribeAsync(int entityRecordId, CancellationToken ct = default)
        {
            var cir = await _db.ConstructionInspectionRequestList.FirstOrDefaultAsync(c => c.Id == entityRecordId, ct);
            if (cir is null) return (entityRecordId.ToString(), "");
            var number = !string.IsNullOrWhiteSpace(cir.RegisterNo)
                ? cir.RegisterNo
                : (cir.Num is int n ? $"CIR-{n:D3}-R{cir.Rev ?? 0}" : entityRecordId.ToString());
            return (number, cir.Description ?? "");
        }
    }
}
