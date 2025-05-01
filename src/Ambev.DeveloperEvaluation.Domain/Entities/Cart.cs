using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public new int Id { get; set; }
        public int SaleNumber {  get; set; }
        public string UserId { get; set; }
        public int BranchId { get; set; }
        public bool IsFinalized { get; set; } = false;
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
        public DateTime Date { get; set; }

    }
}
