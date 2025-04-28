using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
