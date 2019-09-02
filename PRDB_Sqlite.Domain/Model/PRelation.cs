using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDB_Sqlite.Domain.Model
{
    public class PRelation
    {
        public int id { get; set; }
        public PSchema schema { get; set; }
        public string relationName { get; set; 
        public IList<PTuple> tupes { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
