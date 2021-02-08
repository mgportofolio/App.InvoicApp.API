using System;
using System.Collections.Generic;

#nullable disable

namespace InvoiceApp.Entities.Entities
{
    public partial class MasterCompany
    {
        public MasterCompany()
        {
            InvoiceHeaders = new HashSet<InvoiceHeader>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyLogo { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; }
    }
}
