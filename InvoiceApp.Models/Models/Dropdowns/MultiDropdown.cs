using InvoiceApp.Models.Models.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp.Models.Models.Dropdowns
{
    public class MultiDropdown
    {
        public MultiDropdown()
        {
            this.Currency = new List<DropdownModel>();
            this.Language = new List<DropdownModel>();
            this.Metrics = new List<DropdownModel>();
        }

        public List<DropdownModel> Currency { set; get; }
        public List<DropdownModel> Language { set; get; }
        public List<DropdownModel> Metrics { set; get; }
    }
}
