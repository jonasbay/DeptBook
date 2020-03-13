using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;


namespace TheDeptBook.ViewModels
{
    class AddDeptorsViewModel : BindableBase
    {
        public AddDeptorsViewModel(Deptors deptor)
        {
            CurrentDeptor = deptor;
        }

        Deptors currentDeptor;

        public Deptors CurrentDeptor
        {
            get { return currentDeptor; }
            set
            {
                SetProperty(ref currentDeptor, value);
            }
        }

    }
}
