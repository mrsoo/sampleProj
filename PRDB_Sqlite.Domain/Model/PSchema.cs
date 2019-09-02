using System.Collections.Generic;

namespace PRDB_Sqlite.Domain.Model
{
    public class PSchema
    {
        public int id { get; set; }
        public string SchemaName { get; set; }
        public List<PAttribute> Attributes { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}