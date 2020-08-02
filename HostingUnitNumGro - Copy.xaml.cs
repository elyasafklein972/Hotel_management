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
	/// Interaction logic for Window9.xaml
	/// </summary>
	public partial class HostingUnitNumGroup : Window
	{
		BL.IBL bl;

		public HostingUnitNumGroup()
		{
			InitializeComponent();
			bl = BL.Factory.GetInstance();
			

			this.hostingUnitListView.ItemsSource = bl.HostingUnitkey();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

			Window back = new SqrHosting();
			back.Show();
			this.Close();
		}

		private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// hostingUnitViewSource.Source = [generic data source]
		}

		
	}
}
