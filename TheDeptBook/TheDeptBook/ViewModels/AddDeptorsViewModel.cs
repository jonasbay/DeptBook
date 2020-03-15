using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;


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

        ICommand _addNewDeptorCommand;

        public ICommand AddNewDeptorCommand
        {
            get
            {
                return _addNewDeptorCommand ?? (_addNewDeptorCommand = new DelegateCommand(() =>
                {
                
                }));
            }
        }
    }
}
