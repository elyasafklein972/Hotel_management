using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLWPF
{
	/// <summary>
	/// Interaction logic for GetOptions.xaml
	/// </summary>
	public partial class GetOptions : Window
	{
		BL.IBL bl;
		DateTime t;
		int i;
		public GetOptions()
		{
			InitializeComponent();
			//(DateTime)this.entryDateDatePicker.SelectedDate;
			t = (DateTime)date.SelectedDate;
			i = int.Parse(numday.Text);
			this.DataContext=bl.GetoptionHost(t, i);
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// orderViewSource.Source = [generic data source]
			System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// hostingUnitViewSource.Source = [generic data source]
		}
	}
}
