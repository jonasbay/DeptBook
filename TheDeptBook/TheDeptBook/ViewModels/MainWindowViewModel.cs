using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Serialization;
using TheDeptBook;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Path = System.IO.Path;
using TheDeptBook.ViewModels;

namespace TheDeptBook
{
    public partial class MainWindowViewModel : BindableBase
    {
        ObservableCollection<Deptors> deptors;

        public MainWindowViewModel()
        {
            deptors = new ObservableCollection<Deptors>
            {
                new Deptors("Jonas Bay", 800.15),
                new Deptors("Alexander Smith", 152.54)
            };
            CurrentDeptor = deptors[0];
        }

        #region properties
        Deptors currentDeptor = null;

        public Deptors CurrentDeptor
        {
            get { return currentDeptor; }
            set
            {
                SetProperty(ref currentDeptor, value);
            }
        }

        public ObservableCollection<Deptors> Deptors
        {
            get { return deptors; }
            set { SetProperty(ref deptors, value); }
        }
        int currentIndex = -1;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                SetProperty(ref currentIndex, value);
            }
        }



        #endregion


        #region AddDeptorCommand
        private ICommand _addDeptorCommand;

        public ICommand AddDeptorCommand
        {
            get
            {
                return _addDeptorCommand ?? (_addDeptorCommand = new DelegateCommand(() =>
                {
                    var newDeptor = new Deptors();
                    var vm = new AddDeptorsViewModel();
                    var dlg = new AddDeptors();
                    //dlg.Datacontext = vm;

                }));
            }
        }
        #endregion
    }
}
