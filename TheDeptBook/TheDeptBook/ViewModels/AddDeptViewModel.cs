using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace TheDeptBook.ViewModels
{
    public class AddDeptViewModel : BindableBase
    {
        public AddDeptViewModel()
        {

        }

        public AddDeptViewModel(Deptor deptor)
        {
            CurrentDeptor = deptor;
        }

        Deptor currentDeptor;

        public Deptor CurrentDeptor
        {
            get { return currentDeptor; }
            set
            {
                SetProperty(ref currentDeptor, value);
            }
        }

        ICommand _addValueCommand;

        public ICommand AddValueCommand
        {
            get
            {
                return _addValueCommand ?? (_addValueCommand = new DelegateCommand(() =>
                           {
                               CurrentDeptor.Date = DateTime.Now.ToString("dd/mm/yyyy");
                               currentDeptor.AddDeptToPerson(CurrentDeptor.Date, 12);
                           }
                       ));
            }
        }

    }
}
