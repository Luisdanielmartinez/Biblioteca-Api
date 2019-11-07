using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime ModifiedDate{get;set;}
        public string IpAddress{get;set;}
    }
}
