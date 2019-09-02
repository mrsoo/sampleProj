using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDB_Sqlite.Domain.Interface
{
    public interface IDatabaseUtil : IDisposable
    {
        bool openConnection();
        bool closeConnection();
        double ExecuteScalar(string query);
        DataTable ExecuteQuery(string query);
        bool DropTable(string tblName);
        bool CreateTable(string tblName);

    }
}
