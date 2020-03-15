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
        public AddDeptorsViewModel(Deptor deptor)
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

        public bool IsValid
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(CurrentDeptor.Name))
                    isValid = false;
                if (double.IsNaN(CurrentDeptor.InitValue))
                    isValid = false;
                return isValid;
            }
        }

        ICommand _saveBtnCommand;

        public ICommand SaveBtnCommand
        {
            get
            {
                CurrentDeptor.Date = DateTime.Now.ToString("dd/MM/yyyy");
                return _saveBtnCommand ?? (_saveBtnCommand = new DelegateCommand(
                    SaveBtnCommand_Execute, SaveBtnCommand_CanExecute)
                    .ObservesProperty(() => CurrentDeptor.Name)
                    .ObservesProperty(() => CurrentDeptor.InitValue));
            }
        }

        private void SaveBtnCommand_Execute()
        {
            //Noting to be done
        }

        private bool SaveBtnCommand_CanExecute()
        {
            return IsValid;
        }
    }
}
