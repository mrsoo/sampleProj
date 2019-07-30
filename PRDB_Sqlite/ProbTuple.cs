using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PRDB_Sqlite.DAL;

namespace PRDB_Sqlite.BLL
{
    public  class ProbTuple
    {
        #region Properties
        // Tập các giá trị bộ ba xác suất trên một tuple
        public List<ProbTriple> Triples { get; set; }
        #endregion

        #region Methods
        public ProbTuple()
        {
            this.Triples = new List<ProbTriple>();
        }
        #endregion
        
     
        internal List<ProbTuple> getAllTypleByRelationName(string relationname, int nTriples)
        {
            return DALProbTuple.getAllTypleByRelationName(relationname,nTriples);
        }

        internal void DeleteTypeById()
        {
            DALProbTuple.DeleteTypeById(this);
        }
    }
}
