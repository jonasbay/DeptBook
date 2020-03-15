using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDeptBook
{
    class Dept
    {
        private string date;
        private double value;

        public Dept(string dDate, double dValue)
        {
            date = dDate;
            value = dValue;
        }

        public string Date
        {
            get { return date; }
        }

        public double Value
        {
            get { return value; }
        }
    }
}
