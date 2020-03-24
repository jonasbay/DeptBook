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
using TheDeptBook;
using TheDeptBook.ViewModels;
using TheDeptBook.Views;

namespace TheDeptBook
{
    public partial class MainWindowViewModel : BindableBase
    {
        private string filename = "";
        ObservableCollection<Deptor> deptors;

        public MainWindowViewModel()
        {
            deptors = new ObservableCollection<Deptor>();
            //{
            //    new Deptor("Jonas Bay", -152, "20-05-2002"),
            //    new Deptor("Alexander Smith", 194.51, "17-01-2018")
            //};
            deptors.Add(new Deptor("Jonas Bay", -152, "20-05-2002"));
            deptors.Add(new Deptor("Alexander Smith", 194.51, "17-01-2018"));

            CurrentDeptor = deptors[0];
        }

        #region Properties

        Deptor currentDeptor = null;

        public Deptor CurrentDeptor
        {
            get { return currentDeptor; }
            set
            {
                SetProperty(ref currentDeptor, value);
            }
        }

        public ObservableCollection<Deptor> Deptors
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
                    var newDeptor = new Deptor("", 0, DateTime.Now.ToString("dd/MM/yyyy"));
                    var vm = new AddDeptorsViewModel(newDeptor);
                    var dlg = new AddDeptors();
                    dlg.DataContext = vm;
                    if (dlg.ShowDialog() == true)
                    {
                        Deptors.Add(newDeptor);
                        CurrentDeptor = newDeptor;
                    }
                }));
            }
        }

        private bool dirty = false;
        public bool Dirty
        {
            get { return dirty; }
            set
            {
                SetProperty(ref dirty, value);
                RaisePropertyChanged("Title");
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
                    var vm = new AddDeptViewModel(CurrentDeptor);
                    var dlg = new AddDept();
                    dlg.DataContext = vm;
                    dlg.ShowDialog();
                },
                ()=> { return CurrentIndex >= 0; }
                ).ObservesProperty(()=>CurrentIndex));
            }
        }

        #endregion

        #region CloseProgramCommand
        ICommand _closeProgramCommand;
        public ICommand CloseProgramCommand
        {
            get
            {
                return _closeProgramCommand ?? (_closeProgramCommand = new DelegateCommand(() =>
                {
                    Application.Current.MainWindow.Close();
                }));
            }
        }
        #endregion

        #region DeleteDeptorCommand
        ICommand _deleteCommand;
        public ICommand DeleteDeptorCommand => _deleteCommand ?? (_deleteCommand =
            new DelegateCommand(DeleteDeptor, DeleteDeptor_CanExecute)
                    .ObservesProperty(() => CurrentIndex));

        private void DeleteDeptor()
        {
            MessageBoxResult res = MessageBox.Show("Are you sure you want to delete debtor " + CurrentDeptor.Name +
                "?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Deptors.Remove(CurrentDeptor);
                Dirty = true;
            }
        }

        private bool DeleteDeptor_CanExecute()
        {
            if (Deptors.Count > 0 && CurrentIndex >= 0)
                return true;
            else
                return false;
        }
        #endregion


        private ICommand _openFileCommand;
        public ICommand OpenFileCommand
        {
            get
            {
                return _openFileCommand ?? (_openFileCommand = new DelegateCommand<string>(openFileCommand_Execute));
            }
        }

        public void openFileCommand_Execute(string FileNameTyped)
        {
            if (FileNameTyped == "")
            {

                MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                filename = FileNameTyped;
                var tempDeptors = new ObservableCollection<Deptor>();

                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Deptor>));

                try
                {
                    TextReader reader = new StreamReader(filename);
                    tempDeptors = (ObservableCollection<Deptor>)serializer.Deserialize(reader);
                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                Deptors = tempDeptors;
            }
        }

        private ICommand _saveAsCommand;
        public ICommand SaveAsCommand
        {
            get { return _saveAsCommand ?? (_saveAsCommand = new DelegateCommand<string>(SaveAsCommand_Execute)); }
        }

        private void SaveAsCommand_Execute(string thisIsTheFileName)
        {

            if (thisIsTheFileName == "")
            {
                MessageBox.Show("Enter a file name please. Unable to save file!", "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                filename = thisIsTheFileName;
                saveFileCommand_Execute();
            }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand =
                           new DelegateCommand(saveFileCommand_Execute, saveFileCommand_CanExecute)
                               .ObservesProperty(() => Deptors.Count));
            }
        }

        public void saveFileCommand_Execute()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Deptor>));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, Deptors);
            writer.Close();
        }

        public bool saveFileCommand_CanExecute()
        {
            return (filename != "") && (Deptors.Count > 0);
        }

        private ICommand _newFileCommand;

        public ICommand NewFileCommand
        {
            get
            {
                return _newFileCommand ?? (_newFileCommand = new DelegateCommand(newFileCommand_Execute));
            }
        }

        public void newFileCommand_Execute()
        {
            MessageBoxResult res = MessageBox.Show("Any unsaved data will be lost. Are you sure you w ant to make a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Deptors.Clear();
                filename = "";
            }
        }
    }
}
