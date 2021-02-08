using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp.Models.Models.Invoices.InputModel.Detail
{
    public class InvoiceDetailInputModel
    {
        public string ItemName { get; set; }
        public int ItemQty { get; set; }
        public decimal ItemRate { get; set; }
        public int MetricId { get; set; }
        public decimal ItemAmount { get; set; }
    }
}
