using PRDB_Sqlite.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDB_Sqlite.Domain.Abtraction
{
    public abstract class ADatabase : IDatabaseUtil
    {
        #region declare Properties

        public SQLiteConnection connection { get; set; }
        public SQLiteCommand command { get; set; }
        public SQLiteDataAdapter adapter { get; set; }
        public string errorMessage { get; set; }
        public Object[] valueCollection { get; set; }
        #endregion

        public abstract bool closeConnection();
       

        public abstract bool CreateTable(string tblName);
        

        public void Dispose()
        {
            this.Dispose();
        }

        public abstract bool DropTable(string tblName);


        public abstract DataTable ExecuteQuery(string query);


        public abstract double ExecuteScalar(string query);

        public abstract bool openConnection();
       
    }
}
