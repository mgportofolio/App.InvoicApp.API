using System;
using System.Collections.Generic;

#nullable disable

namespace InvoiceApp.Entities.Entities
{
    public partial class MasterMetric
    {
        public MasterMetric()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int MetricId { get; set; }
        public string MetricName { get; set; }
        public string MetricCode { get; set; }
        public string MetricDescription { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
