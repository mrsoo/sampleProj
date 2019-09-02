using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDB_Sqlite.Domain.Model
{
    public class PTuple
    {
        public IDictionary<string, Object> valueSet { get; set; }
        public ElemProb Ps { get; set; }
    }
}
