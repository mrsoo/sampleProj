using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using PRDB_Sqlite.DAL;

namespace PRDB_Sqlite.BLL
{
    public class ProbScheme
    {
        #region Declare Properties

        //ID lược đồ quan hệ

        public int IDScheme { get; set; }

        //Tên lược đồ quan hệ
        public string SchemeName { get; set; }
        //Danh sách các thuộc tính của lược đồ
        public List<ProbAttribute> Attributes { get; set; }        
        #endregion

        #region Methods
        public ProbScheme()
        {
            this.IDScheme = -1;
            this.SchemeName = "No Name";
            this.Attributes = new List<ProbAttribute>();
        }

        public ProbScheme(int IDScheme)
        {
            this.IDScheme = IDScheme;
            this.SchemeName = "No Name";
            this.Attributes = new List<ProbAttribute>();
        }

        public ProbScheme(string schemename)
        {
            this.IDScheme = -1;
            this.SchemeName = schemename;
            this.Attributes = new List<ProbAttribute>();
        }

        public ProbScheme(int IDScheme,string schemename, List<ProbAttribute> Attributes)
        {
            this.IDScheme = IDScheme;
            this.SchemeName = schemename;
            this.Attributes = Attributes;
        }

       #endregion


        public bool isInherited(List<ProbRelation> Relations)
        {
            try
            {
                   foreach (ProbRelation relation in Relations)
                        if ( this.SchemeName.Equals(relation.Scheme.SchemeName))
                             return true;
                
            }
            catch
            {
                
            }

            return false;
        }


        internal List<ProbScheme> getAllScheme()
        {
            return DALProbScheme.getAllScheme();
        }
        
        internal ProbScheme getSchemeById()
        {
            return DALProbScheme.getSchemeById(this);
        }
        

        internal void DeleteAllScheme()
        {
            DALProbScheme.DeleteAllScheme();
        }

      

        internal void Insert()
        {
            DALProbScheme.Insert(this);
        }



        internal int getMaxIdinTable()
        {
            return DALProbScheme.getMaxIdinTable();
        }

        internal void Update()
        {
            DALProbScheme.Update(this);
        }

        internal void DeleteSchemeById()
        {
            DALProbScheme.DeleteSchemeById(this);
        }
    }

}
