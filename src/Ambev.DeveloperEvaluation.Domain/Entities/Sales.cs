using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sales : BaseEntity
    {
        public int SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public Branch Branch { get; set; }
        public List<SaleItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Cancelled { get; set; }
        public Sales() 
        {
            Id = Guid.NewGuid();
        }
    }
}
