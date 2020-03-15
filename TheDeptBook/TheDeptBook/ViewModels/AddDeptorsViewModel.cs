﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;


namespace TheDeptBook.ViewModels
{
    public class AddDeptorsViewModel : BindableBase
    {
        public AddDeptorsViewModel()
        {

        }

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
    }
}
