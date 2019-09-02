using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDB_Sqlite.Domain.Model
{
    public class PDatabase
    {
        #region Properties

        // Tên cơ sở dữ liệu
        public string DbName { get; set; }
        //Chuổi kết nối
        public string ConnectString { get; set; }
        // Đường dẫn đến CSDL
        public string DBPath { get; set; }
        // Tập các lược đồ cơ sở dữ liệu
        public List<PSchema> Schemes { get; set; }

        // Tập các quan hệ cơ sở dữ liệu
        public List<PRelation> Relations { get; set; }
        // Tập các truy vấn cơ sở dữ liệu
        //  public List<ProbQuery> Queries { get; set; }
        //DataSet
        public DataSet DataSet { get; set; }
        #endregion


    }
}
