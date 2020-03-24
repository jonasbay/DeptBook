using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace TheDeptBook
{
    public class Dept : BindableBase
    {
        private string date_;
        private double value_;

        public Dept()
        { }

        public Dept(string dDate, double dValue)
        {
            date_ = dDate;
            value_ = dValue;
        }

        public string Date
        {
            get { return date_; }
            set { SetProperty(ref date_, value); }

        }

        public double Value
        {
            get { return value_; }
            set { SetProperty(ref value_, value); }
        }
    }
}
