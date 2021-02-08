using System;
using System.Collections.Generic;

#nullable disable

namespace InvoiceApp.Entities.Entities
{
    public partial class InvoiceHeader
    {
        public InvoiceHeader()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int InvoiceId { get; set; }
        public string InvocieNo { get; set; }
        public int InvoiceStatus { get; set; }
        public int LanguageId { get; set; }
        public int CurrencyId { get; set; }
        public string InvoiceFrom { get; set; }
        public int CompanyId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceDue { get; set; }
        public string InvoicePon { get; set; }
        public decimal InvoiceSubTotal { get; set; }
        public string DiscountCode { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal InvoiceTotal { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual MasterCompany Company { get; set; }
        public virtual MasterCurrency Currency { get; set; }
        public virtual MasterInvoiceStatus InvoiceStatusNavigation { get; set; }
        public virtual MasterLanguage Language { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
