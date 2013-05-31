using System;
using System.Linq;
using NullGuard;

namespace HarvestMagic
{
    [NullGuard(ValidationFlags.Methods)]
    public class Client
    {
        public bool Active { get; set; }
        public long CacheVersion { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Currency { get; set; }
        public object HighRiseId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string StatementKey { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CurrencySymbol { get; set; }
        public string Details { get; set; }
        public string DefaultInvoiceTimeFrame { get; set; }
        public string LastInvoiceKind { get; set; }
    }
}
