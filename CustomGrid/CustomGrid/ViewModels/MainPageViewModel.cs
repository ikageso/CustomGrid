using CustomGrid.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CustomGrid.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";


            var list = new List<DataModel>()
            {
                new DataModel(){Name = "aaa"},
                new DataModel(){Name = "bbb"},
                new DataModel(){Name = "ccc"},
                new DataModel(){Name = "ddd"},
                new DataModel(){Name = "eee"},
                new DataModel(){Name = "fff"},
                new DataModel(){Name = "ggg"},
                new DataModel(){Name = "hhh"},
                new DataModel(){Name = "iii"},
                new DataModel(){Name = "jjj"},
            };

            var list2 = new List<DataModel>()
            {
                new DataModel(){Name = "111"},
                new DataModel(){Name = "222"},
                new DataModel(){Name = "333"},
                new DataModel(){Name = "444"},
                new DataModel(){Name = "555"},
                new DataModel(){Name = "666"},
                new DataModel(){Name = "777"},
                new DataModel(){Name = "888"},
                new DataModel(){Name = "999"},
            };

            ListOfData = new ObservableCollection<DataModel>(list);
            ListOfDataStack = new ObservableCollection<DataModel>(list2);

        }

        private ObservableCollection<DataModel> _ListOfData;
        /// <summary>
        /// ListOfData
        /// </summary>
        public ObservableCollection<DataModel> ListOfData
        {
            get { return _ListOfData; }
            set { SetProperty(ref _ListOfData, value); }
        }

        private ObservableCollection<DataModel> _ListOfDataStack;
        /// <summary>
        /// ListOfData
        /// </summary>
        public ObservableCollection<DataModel> ListOfDataStack
        {
            get { return _ListOfDataStack; }
            set { SetProperty(ref _ListOfDataStack, value); }
        }

        private DelegateCommand<DataModel> _ClickCommand;
        /// <summary>
        /// ClickCommand
        /// </summary>
        public DelegateCommand<DataModel> ClickCommand
        {
            get
            {
                if (_ClickCommand == null)
                {
                    _ClickCommand = new DelegateCommand<DataModel>((s) =>
                    {
                        Debug.WriteLine($"{s.Name}");
                    },
                    (s) =>
                    {
                        return true;
                    });
                }

                return _ClickCommand;
            }
        }

        private DelegateCommand<DataModel> _ClickCommandStack;
        /// <summary>
        /// ClickCommand
        /// </summary>
        public DelegateCommand<DataModel> ClickCommandStack
        {
            get
            {
                if (_ClickCommandStack == null)
                {
                    _ClickCommandStack = new DelegateCommand<DataModel>((s) =>
                    {
                        Debug.WriteLine($"{s.Name}");
                    },
                    (s) =>
                    {
                        return true;
                    });
                }

                return _ClickCommandStack;
            }
        }


    }
}
