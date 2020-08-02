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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
	/// <summary>
	/// Interaction logic for ListOrder.xaml
	/// </summary>

	public partial class ListOrder : Window
	{
		BL.IBL bl;
		public ListOrder()
		{
			InitializeComponent();
			bl = BL.Factory.GetInstance();
			this.orderDataGrid.ItemsSource =bl.GetAllOrder();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// orderViewSource.Source = [generic data source]
		}
	}
}
