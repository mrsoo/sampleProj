using PRDB_Sqlite.Domain.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDB_Sqlite.Domain.Model
{
    public class PAttribute
    {
        public bool primaryKey { get; set; }
        public int id { get; set; }
        public string AttributeName { get; set; }
        public PDataType Type { get; set; }
        public string Description { get; set; }
        public PSchema PSchema { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
