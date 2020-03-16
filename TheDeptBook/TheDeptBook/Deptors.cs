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
        double sum = 0;
        string date;
        double newValue;


        public Deptor() {}

        public Deptor(string dName, double dInitValue, string dDate)
        {
            ListOfAllDepts = new ObservableCollection<Dept>();
            name = dName;
            sum = dInitValue;
            date = dDate;
            ListOfAllDepts.Add(new Dept(dDate, dInitValue));
        }

        public void AddDeptToPerson(string dDate, double dValue)
        {
            ListOfAllDepts.Add(new Dept(dDate, dValue));
            Sum += dValue; // Skal udkommenteres, hvis den er i deletegateCommand for ADD
        }

        public Deptor Clone()
        {
            return this.MemberwiseClone() as Deptor;
        }

        public double Sum
        {
            get { return sum; }
            set { SetProperty(ref sum, value);  }
        }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public double newDeptValue
        {
            get { return newValue; }
            set { SetProperty(ref newValue, value); }
        }

        public string Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }
        
        ObservableCollection<Dept> ListOfAllDepts;
        public ObservableCollection<Dept> ListOfDepts
        {
            get { return ListOfAllDepts; }
            set { SetProperty(ref ListOfAllDepts, value); }
        }
    }
}
