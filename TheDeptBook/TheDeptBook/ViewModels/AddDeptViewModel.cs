using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace TheDeptBook.ViewModels
{
    class AddDeptViewModel : BindableBase
    {
        public AddDeptViewModel(Deptors deptor)
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
