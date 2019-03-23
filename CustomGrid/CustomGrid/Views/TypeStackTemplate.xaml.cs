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
	public partial class TypeStackTemplate : Grid
    {
        public TypeStackTemplate()
        {
            InitializeComponent();
        }

        public TypeStackTemplate(object item)
        {
            InitializeComponent();
            BindingContext = item;
        }

    }
}