using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Markup;
using Prism.Mvvm;

namespace TheDeptBook
{
    public class Deptors : BindableBase
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

        public Deptors Clone()
        {
            return this.MemberwiseClone() as Deptors;
        }


        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public double InitValue
        {
            get { return initValue; }
            set { SetProperty(ref initValue, value); }
        }
    }
}
