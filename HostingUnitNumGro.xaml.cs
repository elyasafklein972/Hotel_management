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
	public partial class HostingUnitNumGro : Window
	{
		BL.IBL bl;
		
		public HostingUnitNumGro()
		{
			InitializeComponent();
			bl = BL.Factory.GetInstance();
			this.hostingUnitListView.ItemsSource = bl.HostingUnitArea();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

			Window back = new SqrHosting();
			back.Show();
			this.Close();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// hostingUnitViewSource.Source = [generic data source]
		}
	}
}
