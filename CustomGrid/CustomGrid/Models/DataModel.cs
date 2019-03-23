using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomGrid.Models
{
    public class DataModel : BindableBase
    {
        private string _Name;
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

    }
}
