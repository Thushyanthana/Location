using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Entity
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
