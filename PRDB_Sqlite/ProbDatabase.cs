using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using PRDB_Sqlite.DAL;
using System.Windows.Forms;


namespace PRDB_Sqlite.BLL
{
    public class ProbDatabase
    {
        #region Properties

        // Tên cơ sở dữ liệu
        public string DBName { get; set; }
        //Chuổi kết nối
        public string ConnectString { get; set; }
        // Đường dẫn đến CSDL
        public string DBPath { get; set; }
        // Tập các lược đồ cơ sở dữ liệu
        public List<ProbScheme> Schemes { get; set; }

        // Tập các quan hệ cơ sở dữ liệu
        public List<ProbRelation> Relations { get; set; }
        // Tập các truy vấn cơ sở dữ liệu
        public List<ProbQuery> Queries { get; set; }
        //DataSet
        public DataSet DataSet { get; set; }
        #endregion

        #region methods
        public ProbDatabase(string path)
        {
            // Lấy đường dẫn cho CSDL 
            this.DBPath = path;
            this.DBName = "";

            for (int i = path.Length - 1; i >= 0; i--)
            {
                if (path[i] == '\\') break;
                else this.DBName = path[i] + DBName;
            }
            // Đặt chuỗi kết nối
            this.ConnectString = "Data Source=" + DBPath + ";Version=3;";
        
            this.DBName = CutExtension(DBName);
            this.Relations = new List<ProbRelation>();
            this.Queries = new List<ProbQuery>();
            this.Schemes = new List<ProbScheme>();
        }
        public ProbDatabase(ProbDatabase probDatabase)
        {
            this.DBPath = probDatabase.DBPath;
            this.DBName = probDatabase.DBName;
            this.ConnectString = probDatabase.ConnectString;
            this.DataSet = probDatabase.DataSet;
            this.Relations = probDatabase.Relations;
            this.Queries = probDatabase.Queries;
            this.Schemes = probDatabase.Schemes;
            
        }
                
        public bool CreateNewDatabase()
        {
            return DALProbDatabase.CreateNewDatabase(this);
        }
        internal ProbDatabase OpenExistingDatabase()
        {
            return DALProbDatabase.OpenExistingDatabase(this);
        }
        private string CutExtension(string name)
        {
            for (int i = name.Length - 1; i >= 0; i--)
                if (name[i] == '.')
                {
                    name = name.Remove(i);
                    break;
                }
            return name;
        }

        //public void RenameProbDatabase(string newProbDatabaseName)
        //{
        //    this.DBName = newProbDatabaseName + ".pdb";
        //    int pos = this.DBPath.LastIndexOf('\\');
        //    this.DBPath = this.DBPath.Remove(pos + 1);
        //    this.DBPath += DBName;
        //    this.ConnectString = "Data Source=" + DBPath + ";Version=3;";
        //}






        public List<string> ListOfSchemeName()
        {
            List<string> List = new List<string>();
            foreach (ProbScheme schema in this.Schemes)
                List.Add(schema.SchemeName);
            return List;
        }

        public List<string> ListOfRelationName()
        {
            List<string> List = new List<string>();
            foreach (ProbRelation relation in this.Relations)
                List.Add(relation.RelationName);
            return List;
        }

        public List<string> ListOfQueryName()
        {
            List<string> List = new List<string>();
            foreach (ProbQuery query in this.Queries)
                List.Add(query.QueryName);
            return List;
        }

        //public ProbRelation FindRelation(string relname)
        //{
        //    foreach (ProbRelation relation in this.Relations)
        //        if (relation.RelationName.CompareTo(relname) == 0)
        //            return relation;
        //    return null;
        //}
        //public ProbQuery FindQuery(string queryname)
        //{
        //    foreach (ProbQuery query in this.Queries)
        //        if (query.QueryName.CompareTo(queryname) == 0)
        //            return query;
        //    return null;
        //}

        //public ProbScheme FindScheme(string schemename)
        //{
        //    foreach (ProbScheme scheme in this.Schemes)
        //        if (scheme.SchemeName.Equals(schemename))
        //            return scheme;
        //    return null;
        //}

        //public bool isProbTripleValue(string V)
        //{
        //    V = V.Replace(" ", "");
        //    string[] seperator = { "||" };
        //    string[] value = V.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

        //    int j1, j2, j3, j4, j5;
        //    for (int i = 0; i < value.Length; i++)
        //    {
        //        j1 = value[i].IndexOf('{');
        //        j2 = value[i].IndexOf('}');
        //        j3 = value[i].IndexOf('[');
        //        j4 = value[i].IndexOf(',');
        //        j5 = value[i].IndexOf(']');
        //        if (j1 < 0 || j2 < 0 || j3 < 0 || j4 < 0 || j5 < 0) return false;
        //        if (j1 >= j2 - 1) return false;
        //        if (j2 >= j3) return false;
        //        if (j3 >= j4 - 1) return false;
        //        if (j4 >= j5 - 1) return false;
        //    }
        //    return true;
        //}

        #endregion

        
        
        internal bool SaveDatabase()
        {
            return DALProbDatabase.SaveDatabase(this);
        }

        
    }
}
