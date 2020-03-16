using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Prism.Commands;
using Prism.Mvvm;
using TheDeptBook;

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
            set { SetProperty(ref currentDeptor, value); }
        }

        ICommand _addValueCommand;

        public ICommand AddValueCommand
        {
            get
            {
                return _addValueCommand ?? (_addValueCommand = new DelegateCommand(addValue_Execute)
                           .ObservesProperty(() => CurrentDeptor.newDeptValue)
                           .ObservesProperty(() => CurrentDeptor.Sum)); // Burde denne ikke holde øje om noget bliver ændret og lave sum om?
            }
        }

        private void addValue_Execute()
        {
            //CurrentDeptor.Sum += currentDeptor.newDeptValue;    // Enten her eller i addDeptValue
            CurrentDeptor.Date = DateTime.Now.ToString("dd/MM/yyyy");
            currentDeptor.AddDeptToPerson(CurrentDeptor.Date, currentDeptor.newDeptValue);
        }
    }
}

