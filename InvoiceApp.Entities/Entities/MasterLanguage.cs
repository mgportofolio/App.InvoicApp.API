using System;
using System.Collections.Generic;

#nullable disable

namespace InvoiceApp.Entities.Entities
{
    public partial class MasterLanguage
    {
        public MasterLanguage()
        {
            InvoiceHeaders = new HashSet<InvoiceHeader>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; }
    }
}
