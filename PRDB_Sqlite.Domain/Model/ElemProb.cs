using System;

namespace PRDB_Sqlite.Domain.Model
{
    public class ElemProb
    {
        private float upperBound
        {
            get => upperBound;
          
            set
            {
                if (upperBound > 1 || upperBound < 0) throw new Exception("Invalid Prod");
                upperBound = value;
            }
        }
        private float lowerBound
        {
            get => lowerBound;

            set
            {
                if (lowerBound > 1 || lowerBound < 0) throw new Exception("Invalid Prod");
                upperBound = value;
            }
        }
        public ElemProb()
        {

        }
        public ElemProb (float lowerBound,float upperBound)
        {
            if (upperBound - lowerBound < 0) throw new Exception("Lower Bound must be smaller than Upper Bound");
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
        }
        public ElemProb (ElemProb ps)
        {
            if (upperBound - lowerBound < 0) throw new Exception("Lower Bound must be smaller than Upper Bound");
            this.lowerBound = ps.lowerBound;
            this.upperBound = ps.upperBound;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}