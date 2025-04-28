using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Counter
    {
        public string Id { get; set; } = string.Empty;
        public int SequenceValue { get; set; }
    }
}
