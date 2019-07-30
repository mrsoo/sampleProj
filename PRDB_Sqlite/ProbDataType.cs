using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRDB_Sqlite.BLL
{
   public class ProbDataType
    {
        #region Properties

        public string TypeName { get; set; } // TypeName != DataType if DataType == "User-Defined"

        public string DataType { get; set; }

        public string DomainString { get; set; }

        public List<string> Domain { get; set; }

        #endregion
        #region Methods

        public ProbDataType()
        {
            this.TypeName = "No Name";
            this.DataType = "No Type";
            this.DomainString = "No Domain String";
            Domain = new List<string>();
        }

       
        public void GetDomain(string str)
        {
            try
            {
                this.DomainString = str;
                if (this.TypeName == "UserDefined")
                {
                    str = str.Replace("{", "");
                    str = str.Replace("}", "");
                    char[] seperator = { ',' };
                    string[] temp = str.Split(seperator);
                    this.Domain = new List<string>();
                    foreach (string value in temp)
                        this.Domain.Add(value.Trim());
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public bool CheckDomain(string value)
        {
            string tmp = this.DomainString;

            tmp = tmp.Replace("{", "");
            tmp = tmp.Replace("}", "");
            char[] seperator = { ',' };
            string[] temp = tmp.Split(seperator);
            this.Domain = new List<string>();
            foreach (string v in temp)
                this.Domain.Add(v.Trim());
            return this.Domain.Contains(value);

        }


        private bool isBinaryType(object V)
        {
            try
            {
                foreach (char i in V.ToString())
                    if (i != '0' && i != '1')
                        return false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            return true;
        }

        private bool isCurrencyType(object V)
        {
            try
            {
                double MINCURRENCY = 1.0842021724855044340074528008699e-19;
                double MAXCURRENCY = 9223372036854775807.0;
                double temp = Convert.ToDouble(V);
                if (temp - MINCURRENCY >= 0)
                    if (temp - MAXCURRENCY <= 0)
                        return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            return false;
        }

        public bool CheckDataType(string V)
        {
            try
            {
               
                List<object> values = new List<object>();

                V = V.Replace(" ", "");
                string[] seperator = { "||" };
                string[] temp = V.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                int j1, j2;
                for (int i = 0; i < temp.Length; i++)
                {
                    j1 = temp[i].IndexOf('{');
                    j2 = temp[i].IndexOf('}');
                    values.Add(temp[i].Substring(j1 + 1, j2 - j1 - 1).Trim());
                }
                
                this.GetDataType();

           

                foreach (object value in values)
                {
                    switch (this.DataType)
                    {
                        case "Int16": Convert.ToInt16(value); break;
                        case "Int32": Convert.ToInt32(value); break;
                        case "Int64": Convert.ToInt64(value); break;
                        case "Byte": Convert.ToByte(value); break;
                        case "String": Convert.ToString(value); break;
                        case "DateTime": Convert.ToDateTime(value); break;
                        case "Decimal": Convert.ToDecimal(value); break;
                        case "Single": Convert.ToSingle(value); break;
                        case "Double": Convert.ToDouble(value); break;
                        case "Boolean": Convert.ToBoolean(value); break;
                        case "Binary": return (isBinaryType(value));
                        case "Currency": return (isCurrencyType(value));
                        case "UserDefined":
                               return CheckDomain(value.ToString().Trim());
                                
                    }
                }
            }
            catch 
            { 
                return false; 
            }
            return true;
        }

        // Lấy DataType từ TypeName
        public void GetDataType()
        {
            try
            {
                this.DataType = "UserDefined";

                switch (this.TypeName)
                {
                    case "Int16": this.DataType = "Int16"; break;
                    case "Int64": this.DataType = "Int64"; break;
                    case "Int32": this.DataType = "Int32"; break;
                    case "Byte": this.DataType = "Byte"; break;
                    case "Decimal": this.DataType = "Decimal"; break;
                    case "Currency": this.DataType = "Currency"; break;
                    case "String": this.DataType = "String"; break;
                    case "DateTime": this.DataType = "DateTime"; break;
                    case "Binary": this.DataType = "Binary"; break;
                    case "Single": this.DataType = "Single"; break;
                    case "Double": this.DataType = "Double"; break;
                    case "Boolean": this.DataType = "Boolean"; break;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion
    }
}
