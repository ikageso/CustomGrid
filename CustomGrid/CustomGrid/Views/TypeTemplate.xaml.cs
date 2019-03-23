using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomGrid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TypeTemplate : Grid
    {
        public TypeTemplate()
        {
            InitializeComponent();
        }

        public TypeTemplate(object item)
        {
            InitializeComponent();
            BindingContext = item;
        }

    }
}