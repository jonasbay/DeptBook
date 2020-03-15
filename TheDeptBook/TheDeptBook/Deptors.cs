using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Markup;
using Prism.Mvvm;

namespace TheDeptBook
{
    public class Deptor : BindableBase
    {
        string name;
        double initValue;
        string date;
        private List<Dept> ListOfAllDepts;

        public Deptor() {}

        public Deptor(string dName, double dInitValue, string dDate)
        {
            ListOfAllDepts = new List<Dept>();
            name = dName;
            initValue = dInitValue;
            date = dDate;
            ListOfAllDepts.Add(new Dept(dDate, initValue));
        }

        public void AddDeptToPerson(string dDate, double dValue)
        {
            ListOfAllDepts.Add(new Dept(dDate, dValue));
        }

        public Deptor Clone()
        {
            return this.MemberwiseClone() as Deptor;
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

        public string Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }
    }
}
