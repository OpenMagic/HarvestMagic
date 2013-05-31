using System;
using System.Linq;
using NullGuard;

namespace HarvestMagic
{
    [NullGuard(ValidationFlags.Methods)]
    public class Client
    {
        public bool active { get; set; }
        public long cache_version { get; set; }
        public DateTime created_at { get; set; }
        public string currency { get; set; }
        public object highrise_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string statement_key { get; set; }
        public DateTime updated_at { get; set; }
        public string currency_symbol { get; set; }
        public string details { get; set; }
        public string default_invoice_timeframe { get; set; }
        public string last_invoice_kind { get; set; }
    }
}
