using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TheDeptBook
{
    public class Deptors
    {
        string name;
        double initValue;

        //private ObservableCollection<Deptors> deptList;
        public Deptors() {}

        public Deptors(string dName, double dInitValue)
        {
            name = dName;
            initValue = dInitValue;

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double InitValue
        {
            get { return initValue; }
            set { initValue = value; }
        }
    }
}
