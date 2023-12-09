using Hotel.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain
{
    public class DocumentType : BaseDomainModel
    {
        public string? Name { get; set; }
        public bool State { get; set; }
    }
}
