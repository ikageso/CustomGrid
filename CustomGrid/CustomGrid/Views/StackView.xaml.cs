using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomGrid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StackView : ScrollView
    {
		public StackView ()
		{
			InitializeComponent ();

            this.BackgroundColor = Color.LightBlue;

        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(StackView));
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(StackView));
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<object>), typeof(StackView), null, BindingMode.OneWay, null, (bindable, oldValue, newValue) => { ((StackView)bindable).BuildTiles((IEnumerable<object>)newValue); });

        public Type ItemTemplate { get; set; } = typeof(TypeStackTemplate);

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public void BuildTiles(IEnumerable<object> tiles)
        {
            try
            {
                if (tiles == null || tiles.Count() == 0)
                    this.stackView.Children?.Clear();


                var enumerable = tiles as IList ?? tiles.ToList();


                for (var index = 0; index < enumerable.Count; index++)
                {

                    var tile = BuildTile(enumerable[index]);

                    this.stackView.Children?.Add(tile);
                }
            }
            catch
            { // can throw exceptions if binding upon disposal
            }
        }

        private Layout BuildTile(object item1)
        {
            var buildTile = (Layout)Activator.CreateInstance(ItemTemplate, item1);
            buildTile.InputTransparent = false;

            var tapGestureRecognizer = new TapGestureRecognizer
            {
                Command = new Command(new Action<object>(target)),
                CommandParameter = item1,
                NumberOfTapsRequired = 1
            };

            buildTile?.GestureRecognizers.Add(tapGestureRecognizer);


            return buildTile;
        }

        private void target(object arg2)
        {
            Command.Execute(arg2);
        }
    }
}
