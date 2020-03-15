﻿using System;
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
using TheDeptBook.Views;

namespace TheDeptBook
{
    public partial class MainWindowViewModel : BindableBase
    {

        ObservableCollection<Deptors> deptors;

        public MainWindowViewModel()
        {
            deptors = new ObservableCollection<Deptors>
            {
                new Deptors("Jonas Bay", 124.56),
                new Deptors("Alexander Smith", 194.51)
            };
            CurrentDeptor = deptors[0];
        }


        #region Properties

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
        ICommand _addDeptorCommand;
        public ICommand AddDeptorCommand
        {
            get
            {
                return _addDeptorCommand ?? (_addDeptorCommand = new DelegateCommand(() =>
                {
                    var newDeptor = new Deptors();
                    var vm = new AddDeptorsViewModel(newDeptor);
                    var dlg = new AddDeptors();
                    dlg.ShowDialog();
                    dlg.DataContext = vm;
                    if (dlg.ShowDialog() == true)
                    {
                        Deptors.Add(newDeptor);
                        CurrentDeptor = newDeptor;
                    }
                }));
            }
        }
        #endregion

        #region AddDeptCommand
        ICommand _addDeptCommand;
        public ICommand AddDeptCommand
        {
            get
            {
                return _addDeptCommand ?? (_addDeptCommand = new DelegateCommand(() =>
                {
                    var tempDeptor = new Deptors();
                    var vm = new AddDeptViewModel(tempDeptor);
                    var dlg = new AddDept();
                    dlg.ShowDialog();
                    //dlg.DataContext = vm;
                    //if (dlg.ShowDialog() == true)
                    //{
                    //    Deptors.Add(newDeptor);
                    //    CurrentDeptor = newDeptor;
                    //}
                }));
            }
        }
        #endregion
    }
}
