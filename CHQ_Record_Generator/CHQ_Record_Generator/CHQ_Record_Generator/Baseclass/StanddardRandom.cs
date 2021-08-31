using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHQ_Record_Generator.Baseclass
{
    public class StanddardRandom
    {
        private readonly Random R = new Random();
        private readonly object syncLock = new object();
        public StanddardRandom()
            : base()
        {
        }
        public StanddardRandom(int iSeedValue)
        {
            R = new Random(iSeedValue);
        }


        public int Next(int Min, int Max)
        {
            //throw new NotImplementedException();
            lock (syncLock)
            {

                return R.Next(Min, Max);
            }

        }
        public double NextDouble(int Min, int Max)
        {
            lock (syncLock)
            {
                double dblResult = (Double)Next(Min, Max);
                double dblDecimal = R.NextDouble();
                Boolean IsAdd = true;
                if (R.Next(0, 1) == 0)
                {
                    IsAdd = false;
                }

                if (dblResult + dblDecimal > Max)
                {
                    IsAdd = false;
                }

                if (dblResult + dblResult < Min)
                {
                    IsAdd = true;
                }

                if (IsAdd)
                {
                    dblResult += dblDecimal;
                }
                else
                {
                    dblResult -= dblDecimal;
                }
                return dblResult;
            }
        }
    }
}
